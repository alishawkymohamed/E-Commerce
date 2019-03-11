using HelperServices;
using IBusinessServices;
using IBusinessServices.IAuthenticationServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Newtonsoft.Json.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApi.Filters.Models;

namespace WebApi
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IUsersService _usersService;
        private readonly ITokenStoreService _tokenStoreService;
        //private readonly ISignalRServices _signalRServices;
        //private readonly IAntiForgeryCookieService _antiforgery;

        public AccountController(
            IUsersService usersService,
            ITokenStoreService tokenStoreService)
        //ISignalRServices signalRServices)
        {
            _usersService = usersService;
            _usersService.CheckArgumentIsNull(nameof(usersService));

            _tokenStoreService = tokenStoreService;
            _tokenStoreService.CheckArgumentIsNull(nameof(tokenStoreService));

            //_signalRServices = signalRServices;
            //_signalRServices.CheckArgumentIsNull(nameof(_signalRServices));

            //_antiforgery = antiforgery;
            //_antiforgery.CheckArgumentIsNull(nameof(antiforgery));
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        [ProducesResponseType(200, Type = typeof(AccessToken))]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO loginUser)
        {
            if (loginUser == null)
                return BadRequest("User is not set.");

            Models.DbModels.User user = await _usersService.FindUserPasswordAsync(loginUser.Username, loginUser.Password);
            if (user == null || !user.Enabled)
                return Unauthorized("InvalidCredentials");

            if (!user.IsApproved)
                return Unauthorized("NotApproved");

            (string accessToken, string refreshToken, System.Collections.Generic.IEnumerable<Claim> claims) = await _tokenStoreService.CreateJwtTokens(user, refreshTokenSource: null);
            return Ok(new AccessToken { access_token = accessToken, refresh_token = refreshToken });
        }

        [AllowAnonymous]
        [HttpPost("[action]")]
        [ProducesResponseType(200, Type = typeof(AccessToken))]
        public async Task<IActionResult> RefreshToken([FromBody]JToken jsonBody)
        {
            string refreshToken = jsonBody.Value<string>("refreshToken");
            if (string.IsNullOrWhiteSpace(refreshToken))
            {
                return BadRequest("refreshToken is not set.");
            }

            Models.DbModels.UserToken token = await _tokenStoreService.FindTokenAsync(refreshToken);
            if (token == null)
            {
                return Unauthorized();
            }

            (string accessToken, string newRefreshToken, System.Collections.Generic.IEnumerable<Claim> claims) = await _tokenStoreService.CreateJwtTokens(token.User, refreshToken);

            //_antiforgery.RegenerateAntiForgeryCookies(claims);

            return Ok(new AccessToken { access_token = accessToken, refresh_token = newRefreshToken });
        }

        [AllowAnonymous]
        [HttpGet("[action]")]
        [ProducesResponseType(200, Type = typeof(bool))]
        public bool Logout(string refreshToken)
        {
            ClaimsIdentity claimsIdentity = User.Identity as ClaimsIdentity;
            string userIdValue = claimsIdentity.FindFirst(ClaimTypes.UserData)?.Value;

            // The Jwt implementation does not support "revoke OAuth token" (logout) by design.
            // Delete the user's tokens from the database (revoke its bearer token)
            _tokenStoreService.RevokeUserBearerTokens(userIdValue, refreshToken);

            //_signalRServices.SignOut(User.Identity.Name);
            return true;
        }

        [HttpGet("[action]")]
        public bool IsAuthenticated()
        {
            return User.Identity.IsAuthenticated;
        }

        [HttpGet("[action]")]
        [ProducesResponseType(200, Type = typeof(AuthTicketDTO))]
        [Authorize]
        public IActionResult GetUserAuthTicket(int? organizationId, int? roleId)
        {
            ClaimsIdentity claimsIdentity = User.Identity as ClaimsIdentity;
            string Username = claimsIdentity.Name;
            Models.DTOs.AuthTicketDTO AuthTicket = _usersService.GetAuthDTO(Username, organizationId, roleId);
            return Ok(AuthTicket != null ? AuthTicket : null);
        }

        [HttpPost("[action]")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [AllowAnonymous]
        public IActionResult Register([FromBody]RegisterUserDTO registerUSerDTO)
        {
            if (ModelState.IsValid && registerUSerDTO.Password == registerUSerDTO.ConfirmPassword)
                if (_usersService.RegisterUser(registerUSerDTO))
                    return Ok(true);
            return BadRequest(ModelState);
        }
    }
}