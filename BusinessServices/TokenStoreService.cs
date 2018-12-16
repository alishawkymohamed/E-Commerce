using HelperServices;
using IBusinessServices;
using IBusinessServices.IAuthenticationServices;
using IRepositories;
using IRepositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Models.DbModels;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.AuthenticationServices
{
    public class TokenStoreService : ITokenStoreService
    {
        private readonly ISecurityService _securityService;
        private readonly IUnitOfWork _uow;
        private readonly IUserTokenRepository _tokens;
        private readonly IUserRepository _users;
        private readonly IOptionsSnapshot<BearerTokensOptions> _configuration;
        private readonly IRolesService _rolesService;

        public TokenStoreService(
            IUnitOfWork uow,
            ISecurityService securityService,
            IRolesService rolesService,
            IOptionsSnapshot<BearerTokensOptions> configuration)
        {
            _uow = uow;
            _uow.CheckArgumentIsNull(nameof(_uow));

            _securityService = securityService;
            _securityService.CheckArgumentIsNull(nameof(_securityService));

            _rolesService = rolesService;
            _rolesService.CheckArgumentIsNull(nameof(rolesService));

            _tokens = _uow.Repository<UserToken>() as IUserTokenRepository;
            _users = _uow.Repository<User>() as IUserRepository;

            _configuration = configuration;
            _configuration.CheckArgumentIsNull(nameof(configuration));
        }

        public async Task AddUserTokenAsync(UserToken userToken)
        {
            if (!_configuration.Value.AllowMultipleLoginsFromTheSameUser)
            {
                await InvalidateUserTokensAsync(userToken.UserId);
            }
            await DeleteTokensWithSameRefreshTokenSourceAsync(userToken.RefreshTokenIdHashSource);
            await _tokens.Insert(new List<UserToken> { userToken });
        }

        public async Task AddUserTokenAsync(User user, string refreshToken, string accessToken, string refreshTokenSource)
        {
            DateTimeOffset now = DateTimeOffset.UtcNow;
            UserToken token = new UserToken
            {
                UserId = user.UserId,
                // Refresh token handles should be treated as secrets and should be stored hashed
                RefreshTokenIdHash = _securityService.GetSha256Hash(refreshToken),
                RefreshTokenIdHashSource = string.IsNullOrWhiteSpace(refreshTokenSource) ?
                                           null : _securityService.GetSha256Hash(refreshTokenSource),
                AccessTokenHash = _securityService.GetSha256Hash(accessToken),
                RefreshTokenExpiresDateTime = now.AddMinutes(_configuration.Value.RefreshTokenExpirationMinutes),
                AccessTokenExpiresDateTime = now.AddMinutes(_configuration.Value.AccessTokenExpirationMinutes)
            };
            await AddUserTokenAsync(token);
        }

        public async Task DeleteExpiredTokensAsync()
        {
            DateTimeOffset now = DateTimeOffset.UtcNow;
            IQueryable<Models.DbModels.UserToken> ExpiredTokens = await _tokens.GetAllAsync(x => x.RefreshTokenExpiresDateTime < now);
            if (ExpiredTokens != null && ExpiredTokens.Count() > 0)
                await _tokens.Delete(ExpiredTokens);
        }

        public async Task DeleteTokenAsync(string refreshToken)
        {
            UserToken token = await FindTokenAsync(refreshToken);
            if (token != null)
            {
                await _tokens.Delete(new List<UserToken> { token });
            }
        }

        public async Task DeleteTokensWithSameRefreshTokenSourceAsync(string refreshTokenIdHashSource)
        {
            if (string.IsNullOrWhiteSpace(refreshTokenIdHashSource))
            {
                return;
            }
            IQueryable<Models.DbModels.UserToken> ToBeDeletedTokens = await _tokens.GetAllAsync(t => t.RefreshTokenIdHashSource == refreshTokenIdHashSource);
            if (ToBeDeletedTokens != null && ToBeDeletedTokens.Count() > 0)
                await _tokens.Delete(ToBeDeletedTokens);
        }

        public async Task RevokeUserBearerTokensAsync(string userIdValue, string refreshToken)
        {
            if (!string.IsNullOrWhiteSpace(userIdValue) && int.TryParse(userIdValue, out int userId))
            {
                if (_configuration.Value.AllowSignoutAllUserActiveClients)
                {
                    await InvalidateUserTokensAsync(userId);
                }
            }

            if (!string.IsNullOrWhiteSpace(refreshToken))
            {
                string refreshTokenIdHashSource = _securityService.GetSha256Hash(refreshToken);
                await DeleteTokensWithSameRefreshTokenSourceAsync(refreshTokenIdHashSource);
            }
            await DeleteExpiredTokensAsync();
        }

        public async Task<UserToken> FindTokenAsync(string refreshToken)
        {
            if (string.IsNullOrWhiteSpace(refreshToken))
            {
                return null;
            }
            string refreshTokenIdHash = _securityService.GetSha256Hash(refreshToken);
            IQueryable<UserToken> All = await _tokens.GetAllAsync(x => x.RefreshTokenIdHash == refreshTokenIdHash);
            return await All.Include(x => x.User).FirstOrDefaultAsync();
        }

        public async Task InvalidateUserTokensAsync(int userId)
        {
            IQueryable<Models.DbModels.UserToken> UserTokens = await _tokens.GetAllAsync(x => x.UserId == userId);
            if (UserTokens != null && UserTokens.Count() > 0)
                await _tokens.Delete(UserTokens);
        }

        public async Task<bool> IsValidTokenAsync(string accessToken, int userId)
        {
            string accessTokenHash = _securityService.GetSha256Hash(accessToken);
            UserToken userToken = await _tokens.GetAllAsync(x => x.AccessTokenHash == accessTokenHash && x.UserId == userId).Result.FirstOrDefaultAsync();
            return userToken == null ? false : userToken.AccessTokenExpiresDateTime >= DateTimeOffset.UtcNow;
        }

        public async Task<(string accessToken, string refreshToken, IEnumerable<Claim> Claims)> CreateJwtTokens(User user, string refreshTokenSource)
        {
            (string AccessToken, IEnumerable<Claim> Claims) result = await createAccessTokenAsync(user);
            string refreshToken = Guid.NewGuid().ToString().Replace("-", "");
            await AddUserTokenAsync(user, refreshToken, result.AccessToken, refreshTokenSource);

            return (result.AccessToken, refreshToken, result.Claims);
        }

        private async Task<(string AccessToken, IEnumerable<Claim> Claims)> createAccessTokenAsync(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                // Unique Id for all Jwt tokes
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString(), ClaimValueTypes.String, _configuration.Value.Issuer),
                // Issuer
                new Claim(JwtRegisteredClaimNames.Iss, _configuration.Value.Issuer, ClaimValueTypes.String, _configuration.Value.Issuer),
                // Issued at
                new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64, _configuration.Value.Issuer),
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString(), ClaimValueTypes.String, _configuration.Value.Issuer),
                new Claim(ClaimTypes.Name, user.Username, ClaimValueTypes.String, _configuration.Value.Issuer),
                new Claim("DisplayName", user.FullName, ClaimValueTypes.String, _configuration.Value.Issuer),
                // to invalidate the cookie
                new Claim(ClaimTypes.SerialNumber, user.SerialNumber, ClaimValueTypes.String, _configuration.Value.Issuer),
                // custom data
                new Claim(ClaimTypes.UserData, user.UserId.ToString(), ClaimValueTypes.String, _configuration.Value.Issuer)
            };

            // add current LoggedIn OrganizationId
            // add current LoggedIn RoleId
            UserRole LastAndCurrentLogedInUserRole = await _users.FindLastSelectedRoleAndOrganization(user.UserId);
            claims.Add(new Claim("CurrentRoleId", LastAndCurrentLogedInUserRole.RoleId.ToString(), ClaimValueTypes.String, _configuration.Value.Issuer));

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.Value.Key));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            DateTime now = DateTime.UtcNow;
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration.Value.Issuer,
                audience: _configuration.Value.Audience,
                claims: claims,
                notBefore: now,
                expires: now.AddMinutes(_configuration.Value.AccessTokenExpirationMinutes),
                signingCredentials: creds);
            return (new JwtSecurityTokenHandler().WriteToken(token), claims);
        }
    }
}