using DbContexts.DatabaseExtensions;
using IHelperServices;
using IRepositories.IRepositories;
using Models.DbModels;

namespace Repositories.Repositories
{
    public class SpecificationRepository : _GenericRepository<Specification>, ISpecificationRepository
    {
        public SpecificationRepository(MainDbContext mainDbContext, ISessionServices sessionServices) : base(mainDbContext, sessionServices)
        {
        }
    }
}
