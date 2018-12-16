using HelperServices;
using IBusinessServices;
using IBusinessServices.IAuthenticationServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BusinessServices.AuthenticationServices
{
    public class TokenValidatorService : ITokenValidatorService
    {
        private readonly IUsersService _usersService;
        private readonly ITokenStoreService _tokenStoreService;

        public TokenValidatorService(IUsersService usersService, ITokenStoreService tokenStoreService)
        {
            _usersService = usersService;
            _usersService.CheckArgumentIsNull(nameof(usersService));

            _tokenStoreService = tokenStoreService;
            _tokenStoreService.CheckArgumentIsNull(nameof(_tokenStoreService));
        }

        public async Task ValidateAsync(TokenValidatedContext context)
        {
            ClaimsPrincipal userPrincipal = context.Principal;

            ClaimsIdentity claimsIdentity = context.Principal.Identity as ClaimsIdentity;
            if (claimsIdentity?.Claims == null || !claimsIdentity.Claims.Any())
            {
                context.Fail("This is not our issued token. It has no claims.");
                return;
            }

            Claim serialNumberClaim = claimsIdentity.FindFirst(ClaimTypes.SerialNumber);
            if (serialNumberClaim == null)
            {
                context.Fail("This is not our issued token. It has no serial.");
                return;
            }

            string userIdString = claimsIdentity.FindFirst(ClaimTypes.UserData).Value;
            if (!int.TryParse(userIdString, out int userId))
            {
                context.Fail("This is not our issued token. It has no user-id.");
                return;
            }

            Models.DbModels.User user = await _usersService.FindUserAsync(userId);
            if (user == null || user.SerialNumber != serialNumberClaim.Value || !user.Enabled)
            {
                // user has changed his/her password/roles/stat/IsActive
                context.Fail("This token is expired. Please login again.");
            }

            JwtSecurityToken accessToken = context.SecurityToken as JwtSecurityToken;
            if (accessToken == null || string.IsNullOrWhiteSpace(accessToken.RawData) ||
                !await _tokenStoreService.IsValidTokenAsync(accessToken.RawData, userId))
            {
                context.Fail("This token is not in our database.");
                return;
            }

            await _usersService.UpdateUserLastActivityDateAsync(userId);
        }
    }
}