using DbContexts.DatabaseExtensions;
using IHelperServices;
using IRepositories.IRepositories;
using Models.DbModels;

namespace Repositories.Repositories
{
    public class PhotoRepository : _GenericRepository<Photo>, IPhotoRepository
    {
        public PhotoRepository(MainDbContext mainDbContext, ISessionServices sessionServices) : base(mainDbContext, sessionServices)
        {
        }
    }
}
