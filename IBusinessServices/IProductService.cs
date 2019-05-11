using Models.DbModels;
using Models.DTOs;

namespace IBusinessServices
{
    public interface IProductService : _IBusinessService<Product, ProductDTO, ProductDTO>
    {
    }
}
