using DbContexts.DatabaseExtensions;
using IHelperServices;
using IRepositories.IRepositories;
using Models.DbModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class ProductRepository : _GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(MainDbContext mainDbContext, ISessionServices sessionServices) : base(mainDbContext, sessionServices)
        {
        }

        public override IEnumerable<Product> Insert(IEnumerable<Product> Entities)
        {
            Parallel.ForEach(Entities, (entity) =>
            {
                Parallel.ForEach(entity.Photos, (photo) =>
                {
                    photo.File = Convert.FromBase64String(photo.Base64String);
                });
            });
            return base.Insert(Entities);
        }
    }
}
