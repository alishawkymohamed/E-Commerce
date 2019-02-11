using System;
using System.Linq;
using System.Linq.Expressions;
using DbContexts.DatabaseExtensions;
using IHelperServices;
using IRepositories.IRepositories;
using Models.DbModels;

namespace Repositories.Repositories
{
    public class SubCategoryRepository : _GenericRepository<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(MainDbContext mainDbContext, ISessionServices sessionServices) : base(mainDbContext, sessionServices)
        {
        }

        public override IQueryable<SubCategory> GetAll(Expression<Func<SubCategory, bool>> expression, bool WithTracking = true, params string[] Includes)
        {
            return base.GetAll(expression, WithTracking, "Category");
        }
    }
}
