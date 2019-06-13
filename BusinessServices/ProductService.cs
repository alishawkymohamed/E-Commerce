using AutoMapper;
using AutoMapper.QueryableExtensions;
using HelperServices;
using HelperServices.LinqHelpers;
using IBusinessServices;
using IHelperServices;
using IRepositories;
using LinqHelper;
using Microsoft.Extensions.Localization;
using Models.DbModels;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessServices
{
    public class ProductService : _BusinessService<Product, ProductDTO, ProductDTO>, IProductService
    {
        private readonly IFileServices _fileServices;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper, IStringLocalizer stringLocalizer, ISessionServices sessionServices, IFileServices fileServices) : base(unitOfWork, mapper, stringLocalizer, sessionServices)
        {
            _fileServices = fileServices;
            _fileServices.CheckArgumentIsNull(nameof(_fileServices));
        }

        public override IEnumerable<ProductDTO> Insert(IEnumerable<ProductDTO> entities)
        {
            try
            {
                Task.Run(() =>
                {
                    Parallel.ForEach(entities, entity =>
                    {
                        Parallel.ForEach(entity.Photos, photo =>
                        {
                            photo.UniqueName = Guid.NewGuid().ToString();
                            photo.Path = _fileServices.SaveFile(photo.UniqueName, photo.Extension, photo.Base64String);
                        });
                    });
                });

                return base.Insert(entities);
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

        public DataSourceResult<ProductDTO> GetAllOfSubCategory(int subCategoryId, DataSourceRequest dataSourceRequest, bool WithTracking = true)
        {
            return base._UnitOfWork.Repository<Product>().GetAll().Where(x => x.SubCategoryId == subCategoryId)
                .ProjectTo<ProductDTO>(_Mapper.ConfigurationProvider, _SessionServices)
                .ToDataSourceResult(dataSourceRequest);
        }
    }
}
