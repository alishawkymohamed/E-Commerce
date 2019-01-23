using DbContexts.DatabaseExtensions;
using IHelperServices;
using IRepositories.IRepositories;
using Models.DbModels;

namespace Repositories.Repositories
{
    public class CategoryRepository : _GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(MainDbContext mainDbContext, ISessionServices sessionServices) : base(mainDbContext, sessionServices)
        {
        }
    }
}
