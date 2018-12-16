using DbContexts.DatabaseExtensions;
using IHelperServices;
using IRepositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using Models.DbModels;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class UserRepository : _GenericRepository<User>, IUserRepository
    {
        public UserRepository(MainDbContext mainDbContext, ISessionServices sessionServices) : base(mainDbContext, sessionServices)
        {
        }

        public async Task<UserRole> FindLastSelectedRoleAndOrganization(int UserId)
        {
            return await _Context.UserRoles.Where(ur => ur.UserId == UserId).Where(ur => ur.LastSelected == true).FirstOrDefaultAsync() ?? await _Context.UserRoles.FirstOrDefaultAsync();
        }
    }
}
