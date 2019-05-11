using IBusinessServices;
using IHelperServices;
using Models.DbModels;
using Models.DTOs;

namespace WebApi
{
    public class ProductController : _BaseController<Product, ProductDTO, ProductDTO>
    {
        private readonly IProductService _productService;
        public ProductController(IProductService businessService, ISessionServices sessionSevices) : base(businessService, sessionSevices)
        {
            _productService = businessService;
        }
    }
}
