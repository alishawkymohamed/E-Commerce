using Models;
using Models.DbModels;
using Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IBusinessServices
{
    public interface IUsersService : _IBusinessService<User, UserSummaryDTO, UserDetailsDTO>
    {
        Task<string> GetSerialNumberAsync(int userId);
        Task<User> FindUserPasswordAsync(string username, string password);
        Task<User> FindUserAsync(int userId);
        Task UpdateUserLastActivityDateAsync(int userId);
        Task<User> GetCurrentUserAsync();
        new IEnumerable<object> Delete(IEnumerable<object> Ids);
        int GetCurrentUserId();
        Task<(bool Succeeded, string Error)> ChangePasswordAsync(User user, string currentPassword, string newPassword);
        AuthTicketDTO GetAuthDTO(string userName, int? organizationId = null, int? roleId = null);
        string GetUserName(int? userId);
        string GetDefaultCulture(int? userId);
        UserDetailsDTO GetByUserName(string Username);
    }
}
