using IBusinessServices;
using IHelperServices;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DbModels;
using Models.DTOs;
using System.Threading.Tasks;

namespace WebApi
{
    [Route("api/[controller]")]
    public class UserController : _BaseController<User, UserSummaryDTO, UserDetailsDTO>
    {
        private readonly IUsersService _UserServices;
        public UserController(IUsersService businessService, ISessionServices sessionSevices) : base(businessService, sessionSevices)
        {
            _UserServices = businessService;
        }

        [HttpGet]
        [Route("GetByUserName")]
        [ProducesResponseType(200, Type = typeof(UserDetailsDTO))]
        public IActionResult GetByUserName(string username)
        {
            UserDetailsDTO UserDetails = _UserServices.GetByUserName(username);
            if (UserDetails != null)
                return Ok(UserDetails);
            return NotFound();
        }

        [HttpPost]
        [Route("ChangeUserPassword")]
        public async Task<IActionResult> ChangeUserPassword([FromBody]ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Models.DbModels.User user = await _UserServices.GetCurrentUserAsync();
            if (user == null)
            {
                return BadRequest("NotFound");
            }

            (bool Succeeded, string Error) result = await _UserServices.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(result.Error);
        }
    }
}
