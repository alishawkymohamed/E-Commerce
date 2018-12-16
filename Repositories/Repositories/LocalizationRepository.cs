using DbContexts.DatabaseExtensions;
using IHelperServices;
using Models.DbModels;

namespace Repositories.Repositories
{
    public class LocalizationRepository : _GenericRepository<Localization>
    {
        public LocalizationRepository(MainDbContext mainDbContext, ISessionServices sessionServices) : base(mainDbContext, sessionServices)
        {

        }
    }
}
