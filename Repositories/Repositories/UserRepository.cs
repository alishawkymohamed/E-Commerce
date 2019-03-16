using DbContexts.DatabaseExtensions;
using IHelperServices;
using IRepositories.IRepositories;
using Models.DbModels;

namespace Repositories.Repositories
{
    public class UserRepository : _GenericRepository<User>, IUserRepository
    {
        public UserRepository(MainDbContext mainDbContext, ISessionServices sessionServices) : base(mainDbContext, sessionServices)
        {
        }
    }
}
