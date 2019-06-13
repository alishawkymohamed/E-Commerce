using DbContexts.DatabaseExtensions;
using IHelperServices;
using IRepositories.IRepositories;
using Models.DbModels;
using System.Linq;

namespace Repositories.Repositories
{
    public class SubCategoryRepository : _GenericRepository<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(MainDbContext mainDbContext, ISessionServices sessionServices) : base(mainDbContext, sessionServices)
        {
        }

        public override IQueryable<SubCategory> GetAll(bool WithTracking = true, params string[] Includes)
        {
            return base.GetAll(WithTracking, "Category");
        }
    }
}
