using LinqHelper;
using Models.DbModels;
using Models.DTOs;

namespace IBusinessServices
{
    public interface IProductService : _IBusinessService<Product, ProductDTO, ProductDTO>
    {
        DataSourceResult<ProductDTO> GetAllOfSubCategory(int subCategoryId, DataSourceRequest dataSourceRequest, bool WithTracking = true);
    }
}
