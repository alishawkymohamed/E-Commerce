using Models.DbModels;
using Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IBusinessServices.IAuthenticationServices
{
    public interface IRolesService : _IBusinessService<Role, RoleDTO, RoleDTO>
    {
        Task<List<Role>> FindUserRolesAsync(int userId);
        Task<bool> IsUserInRole(int userId, string roleName);
        Task<List<User>> FindUsersInRoleAsync(string roleName);
    }
}
