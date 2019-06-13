using IBusinessServices;
using IHelperServices;
using LinqHelper;
using Microsoft.AspNetCore.Mvc;
using Models.DbModels;
using Models.DTOs;

namespace WebApi
{
    [Route("api/[controller]")]
    public class ProductController : _BaseController<Product, ProductDTO, ProductDTO>
    {
        private readonly IProductService _productService;
        public ProductController(IProductService businessService, ISessionServices sessionSevices) : base(businessService, sessionSevices)
        {
            _productService = businessService;
        }

        [HttpGet, Route("GetAllOfSubCategory")]
        public DataSourceResult<ProductDTO> GetAllOfSubCategory([FromQuery]int subCategoryId, [FromQuery]DataSourceRequest dataSourceRequest)
        {
            var sub = HttpContext.Request;
            return _productService.GetAllOfSubCategory(subCategoryId, dataSourceRequest, false);
        }
    }
}
