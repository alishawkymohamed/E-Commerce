using Models.DbModels;
using System.Threading.Tasks;

namespace IRepositories.IRepositories
{
    public interface IUserRepository : _IGenericRepository<User>
    {
        Task<UserRole> FindLastSelectedRoleAndOrganization(int UserId);
    }
}
