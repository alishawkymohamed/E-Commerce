using DbContexts.DatabaseExtensions;
using IHelperServices;
using IRepositories.IRepositories;
using Models.DbModels;

namespace Repositories.Repositories
{
    public class ProductRepository : _GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(MainDbContext mainDbContext, ISessionServices sessionServices) : base(mainDbContext, sessionServices)
        {
        }
    }
}
