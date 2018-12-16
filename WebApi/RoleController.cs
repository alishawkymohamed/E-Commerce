using IBusinessServices.IAuthenticationServices;
using Microsoft.AspNetCore.Mvc;
using Models.DbModels;
using Models.DTOs;

namespace WebApi
{
    [Route("api/[controller]")]
    public class RoleController : _BaseController<Role, RoleDTO, RoleDTO>
    {
        private readonly IRolesService _rolesService;
        public RoleController(IRolesService businessService) : base(businessService)
        {
            _rolesService = businessService;
        }

    }
}
