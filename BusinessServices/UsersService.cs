using AutoMapper;
using BusinessServices.ExtensionMethods;
using HelperServices;
using IBusinessServices;
using IHelperServices;
using IRepositories;
using IRepositories.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Models;
using Models.DbModels;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BusinessServices.AuthenticationServices
{
    public class UsersService : _BusinessService<User, UserSummaryDTO, UserDetailsDTO>, IUsersService
    {
        private readonly IUnitOfWork _uow;
        private readonly IUserRepository _users;
        private readonly IUserRoleRepository _userRoles;
        private readonly ISecurityService _securityService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IEncryptionServices _encryptionServices;
        private readonly ICompatibleFrontendEncryption _compatibleFrontendEncryption;
        private readonly AppSettings _AppSettings;

        //private readonly ISignalRServices _signalRServices;

        public UsersService(IUnitOfWork unitOfWork,
            IMapper mapper,
            IStringLocalizer stringLocalizer,
            ISecurityService securityService,
            IOptions<AppSettings> appSettings,
            IEncryptionServices encryptionServices,
            IHttpContextAccessor contextAccessor,
            ICompatibleFrontendEncryption CompatibleFrontendEncryption,
            ISessionServices sessionServices/*, ISignalRServices signalRServices*/) : base(unitOfWork, mapper, stringLocalizer, sessionServices)
        {
            _AppSettings = appSettings.Value;

            _uow = base._UnitOfWork;
            _uow.CheckArgumentIsNull(nameof(_uow));

            _users = _uow.Repository<User>() as IUserRepository;
            _userRoles = _uow.Repository<UserRole>() as IUserRoleRepository;

            _securityService = securityService;
            _securityService.CheckArgumentIsNull(nameof(_securityService));

            _compatibleFrontendEncryption = CompatibleFrontendEncryption;
            _compatibleFrontendEncryption.CheckArgumentIsNull(nameof(_compatibleFrontendEncryption));

            _encryptionServices = encryptionServices;
            _encryptionServices.CheckArgumentIsNull(nameof(_encryptionServices));

            //_signalRServices = signalRServices;
            //_signalRServices.CheckArgumentIsNull(nameof(_signalRServices));

            _contextAccessor = contextAccessor;
            _contextAccessor.CheckArgumentIsNull(nameof(_contextAccessor));
        }

        public async Task<User> FindUserAsync(int userId)
        {
            return await _users.FindAsync(userId);
        }

        public async Task<User> FindUserPasswordAsync(string username, string password)
        {
            string Username = _compatibleFrontendEncryption.Decrypt(username);
            string Password = _compatibleFrontendEncryption.Decrypt(password);

            string passwordHash = _encryptionServices.EncryptString(Password, _AppSettings.EncryptionSettings.SecretPassword, _AppSettings.EncryptionSettings.Salt);
            User result = await _users.FirstOrDefaultAsync(x => (x.Username.ToUpper() == Username.ToUpper() || x.Email.ToUpper() == Username.ToUpper()) && x.Password == passwordHash);
            return result;
        }

        public async Task<string> GetSerialNumberAsync(int userId)
        {
            User user = await FindUserAsync(userId);
            return user.SerialNumber;
        }

        public async Task UpdateUserLastActivityDateAsync(int userId)
        {
            User user = await FindUserAsync(userId);
            if (user.LastLoggedIn != null)
            {
                TimeSpan updateLastActivityDate = TimeSpan.FromMinutes(20);
                DateTimeOffset currentUtc = DateTimeOffset.UtcNow;
                TimeSpan timeElapsed = currentUtc.Subtract(user.LastLoggedIn.Value);
                if (timeElapsed < updateLastActivityDate)
                {
                    return;
                }
            }
            user.LastLoggedIn = DateTimeOffset.UtcNow;
            await _uow.SaveChangesAsync();
        }

        public int GetCurrentUserId()
        {
            ClaimsIdentity claimsIdentity = _contextAccessor.HttpContext.User.Identity as ClaimsIdentity;
            Claim userDataClaim = claimsIdentity?.FindFirst(ClaimTypes.UserData);
            string userId = userDataClaim?.Value;
            return string.IsNullOrWhiteSpace(userId) ? 0 : int.Parse(userId);
        }

        public Task<User> GetCurrentUserAsync()
        {
            int userId = GetCurrentUserId();
            return FindUserAsync(userId);
        }

        public async Task<(bool Succeeded, string Error)> ChangePasswordAsync(User user, string currentPassword, string newPassword)
        {
            string currentPasswordHash = _securityService.GetSha256Hash(currentPassword);
            if (user.Password != currentPasswordHash)
            {
                return (false, "Current password is wrong.");
            }

            user.Password = _securityService.GetSha256Hash(newPassword);
            user.SerialNumber = Guid.NewGuid().ToString("N"); // To force other logins to expire.
            await _uow.SaveChangesAsync();
            return (true, string.Empty);
        }

        public AuthTicketDTO GetAuthDTO(string userName)
        {
            AuthTicketDTO AuthTicket = SessionServices.GetAuthTicket(userName);
            if (AuthTicket != null)
                return AuthTicket;

            bool IsArabic = CultureInfo.CurrentCulture.IsArabic();
            User AuthUser = _users.GetAll(x => x.Username.ToUpper() == userName.ToUpper(), false, "UserRoles").FirstOrDefault();
            if (AuthUser != null)
            {
                if (!AuthUser.Enabled)
                    throw new BusinessException(_StringLocalizer.GetString("AccountIsDisabled"));

                if (!AuthUser.IsApproved)
                    throw new BusinessException(_StringLocalizer.GetString("AccountIsNotApproved"));

                AuthTicketDTO Result = new AuthTicketDTO()
                {
                    Email = AuthUser.Email,
                    FullName = AuthUser.FullName,
                    UserName = AuthUser.Username,
                    UserId = AuthUser.UserId,
                    DefaultCulture = AuthUser.DefaultCulture,
                    RoleId = AuthUser.UserRoles.FirstOrDefault()?.RoleId,
                    RoleName = AuthUser.UserRoles.FirstOrDefault()?.Role.RoleName,
                };

                //Using Sessions Cache to Save AuthTicket
                SessionServices.SetAuthTicket(Result.UserName, Result);
                return Result;
            }
            return null;
        }

        public override IEnumerable<UserDetailsDTO> Insert(IEnumerable<UserDetailsDTO> entities)
        {
            foreach (UserDetailsDTO entity in entities)
            {
                string PasswordHash = _securityService.GetSha256Hash(entity.Password);
                if (entity.IsIndividual != true && string.IsNullOrEmpty(entity.Password))
                    return null;
                entity.Password = PasswordHash;
            }
            return base.Insert(entities);
        }

        public override IEnumerable<object> Delete(IEnumerable<object> Ids)
        {
            foreach (object Id in Ids)
            {
                _uow.RunSqlCommand("DELETE FROM UserRoles WHERE UserId = @UserId", new SqlParameter("UserId", Id));
            }
            return base.Delete(Ids);
        }

        public string GetUserName(int? userId)
        {
            return _users.Find(userId.Value.ToString())?.Username;
        }

        public string GetDefaultCulture(int? userId)
        {
            return _users.Find(userId.Value.ToString())?.DefaultCulture;
        }

        public bool RegisterUser(RegisterUserDTO registerUSerDTO)
        {
            IEnumerable<User> Inserted = _users.Insert(new List<User>
            {
                new User
                {
                    Username = registerUSerDTO.Username,
                    Email = registerUSerDTO.Email,
                    Password = _encryptionServices.EncryptString(_compatibleFrontendEncryption.Decrypt(registerUSerDTO.Password), _AppSettings.EncryptionSettings.SecretPassword,_AppSettings.EncryptionSettings.Salt),
                    FullNameAr = registerUSerDTO.FullName,
                    FullNameEn = registerUSerDTO.FullName,
                    Enabled = true,
                    SerialNumber = Guid.NewGuid().ToString()
                }
            });

            User InsertedUser = Inserted.FirstOrDefault();
            if (InsertedUser != null)
                _userRoles.Insert(new List<UserRole> { new UserRole { UserId = InsertedUser.UserId, RoleId = registerUSerDTO.RoleId } });

            return (Inserted != null && Inserted.Count() > 0);
        }

        //public UserNotificationDataDTO GetUserNotificationData(int? userId)
        //{
        //    var user = _UserManager.FindByIdAsync(userId.Value.ToString()).Result;
        //    return new UserNotificationDataDTO
        //    {
        //        UserName = user.UserName,
        //        DefaultCulture = user.DefaultCulture,
        //        NotificationByMail = user.NotificationByMail,
        //        NotificationBySMS = user.NotificationBySMS,
        //        Email = user.Email,
        //        PhoneNumber = user.PhoneNumber
        //    };
        //}

        public UserDetailsDTO GetByUserName(string Username)
        {
            int? UserId = _users.GetAll(x => x.Username.ToUpper() == Username.ToUpper(), false)?.SingleOrDefault().UserId;
            if (UserId > 0)
                return GetDetails(UserId);
            return null;
        }
    }
}
