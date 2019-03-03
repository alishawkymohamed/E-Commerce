using AutoMapper;
using AutoMapper.QueryableExtensions;
using BusinessServices.ExtensionMethods;
using HelperServices;
using IBusinessServices;
using IHelperServices;
using IRepositories;
using IRepositories.IRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
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
        //private readonly ISignalRServices _signalRServices;

        public UsersService(IUnitOfWork unitOfWork, IMapper mapper, IStringLocalizer stringLocalizer, ISecurityService securityService, IHttpContextAccessor contextAccessor, ISessionServices sessionServices/*, ISignalRServices signalRServices*/) : base(unitOfWork, mapper, stringLocalizer, sessionServices)
        {
            _uow = base._UnitOfWork;
            _uow.CheckArgumentIsNull(nameof(_uow));

            _users = _uow.Repository<User>() as IUserRepository;
            _userRoles = _uow.Repository<UserRole>() as IUserRoleRepository;

            _securityService = securityService;
            _securityService.CheckArgumentIsNull(nameof(_securityService));

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
            string passwordHash = _securityService.GetSha256Hash(password);
            Models.DbModels.User result = await _users.FirstOrDefaultAsync(x => x.Username == username && x.Password == passwordHash);
            return result;
        }

        public async Task<string> GetSerialNumberAsync(int userId)
        {
            var user = await FindUserAsync(userId);
            return user.SerialNumber;
        }

        public async Task UpdateUserLastActivityDateAsync(int userId)
        {
            var user = await FindUserAsync(userId);
            if (user.LastLoggedIn != null)
            {
                TimeSpan updateLastActivityDate = TimeSpan.FromMinutes(20);
                DateTimeOffset currentUtc = DateTimeOffset.UtcNow;
                var timeElapsed = currentUtc.Subtract(user.LastLoggedIn.Value);
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

        public AuthTicketDTO GetAuthDTO(string userName, int? organizationId = null, int? roleId = null)
        {
            //bool IsArabic = CultureInfo.CurrentCulture.IsArabic();
            //var AuthUser = _users.GetUserWithRolesAndPermissions(userName);
            //if (AuthUser != null)
            //{
            //    if (!AuthUser.Enabled)
            //        throw new BusinessException(_StringLocalizer.GetString("AccountIsDisabled"));
            //    if (AuthUser.EnabledUntil.HasValue && AuthUser.EnabledUntil.Value < DateTimeOffset.Now)
            //        throw new BusinessException(_StringLocalizer.GetString("AccountIsDisabledSince", AuthUser.EnabledUntil));

            //    var EnabledUserRoles = AuthUser.UserRoles
            //        .Where(x => !x.EnabledUntil.HasValue || x.EnabledUntil.Value > DateTimeOffset.Now)
            //        .Where(x => !x.EnabledSince.HasValue || x.EnabledSince.Value < DateTimeOffset.Now);

            //    var DefaultUserRole = (organizationId.HasValue && roleId.HasValue) ?
            //        EnabledUserRoles.SingleOrDefault(x => x.OrganizationId == organizationId && x.RoleId == roleId) ?? EnabledUserRoles.FirstOrDefault()
            //        : EnabledUserRoles.SingleOrDefault(x => x.LastSelected == true) ?? EnabledUserRoles.FirstOrDefault();

            //    // To Save Last Selected Role
            //    if (roleId.HasValue && organizationId.HasValue)
            //    {
            //        Models.DbModels.UserRole DefaultToSaved = _userRoles.GetAllAsync
            //            (x => x.UserId == AuthUser.UserId && x.OrganizationId == (organizationId ?? DefaultUserRole.OrganizationId) && x.RoleId == (roleId ?? DefaultUserRole.RoleId)).Result
            //            .FirstOrDefault();
            //        if (DefaultToSaved != null)
            //        {
            //            _userRoles.GetAllAsync(x => x.UserId == AuthUser.UserId).Result.AsParallel().ForAll(e => e.LastSelected = false);
            //            DefaultToSaved.LastSelected = true;
            //            _uow.Save(true);
            //        }
            //    }

            //    var DefaultRolePermissions = DefaultUserRole.Role.RolePermissions.Where(x => x.Enabled == true).Select(x => x.Permission).ToList();

            //    var UserPermissions = DefaultUserRole.User.UserPermissions
            //        .Where(x => x.OrganizationId == DefaultUserRole.OrganizationId)
            //        .Where(x => x.RoleId == DefaultUserRole.RoleId)
            //        .ToList();

            //    UserPermissions.AsParallel().ForAll(x => x.Permission.Enabled = x.Enabled);

            //    List<Permission> ClonedDefaultRolePermissions = new List<Permission>(DefaultRolePermissions);
            //    var Intersection = DefaultRolePermissions.Intersect(UserPermissions.Select(x => x.Permission));
            //    ClonedDefaultRolePermissions.RemoveAll(x => Intersection.Contains(x));

            //    var Result = new AuthTicketDTO()
            //    {
            //        Email = AuthUser.Email,
            //        FullName = IsArabic ? AuthUser.FullNameAr : AuthUser.FullNameEn,
            //        UserName = AuthUser.Username,
            //        DefaultCulture = AuthUser.DefaultCulture,
            //        DefaultCalendar = AuthUser.DefaultCalendar,
            //        OrganizationId = DefaultUserRole.OrganizationId,
            //        OrganizationName = IsArabic ? DefaultUserRole.Organization.OrganizationNameAr : DefaultUserRole.Organization.OrganizationNameEn,
            //        RoleId = DefaultUserRole.RoleId,
            //        RoleName = IsArabic ? DefaultUserRole.Role.RoleNameAr : DefaultUserRole.Role.RoleNameEn,
            //        UserRoles = EnabledUserRoles.AsQueryable().ProjectTo<UserRoleDTO>(_Mapper.ConfigurationProvider).ToList(),
            //        Permissions = DefaultUserRole.RoleOverridesUserPermissions ? DefaultRolePermissions.Select(x => x.PermissionCode.ToUpper())
            //        : ClonedDefaultRolePermissions.Concat(UserPermissions.Select(x => x.Permission)).Where(x => x.Enabled == true).Select(x => x.PermissionCode.ToUpper())
            //    };

            //    //Using Sessions Cache to Save AuthTicket
            //    SessionServices.SetAuthTicket(Result.UserName, Result);
            //    return Result;
            //}
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
                _uow.RunSqlCommand("DELETE FROM UserEntities WHERE UserId = @UserId", new SqlParameter("UserId", Id));
                _uow.RunSqlCommand("DELETE FROM UserPermissions WHERE UserId = @UserId", new SqlParameter("UserId", Id));
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
