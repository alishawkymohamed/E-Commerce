using IBusinessServices;
using IHelperServices;
using Models.DbModels;
using Models.DTOs;

namespace WebApi
{
    public class UserRoleController : _BaseController<UserRole, UserRoleDTO, UserRoleDTO>
    {
        public UserRoleController(IUserRoleService businessService, ISessionServices sessionSevices) : base(businessService, sessionSevices)
        {
        }
    }
}
