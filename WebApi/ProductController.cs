using IBusinessServices;
using IHelperServices;
using Microsoft.AspNetCore.Mvc;
using Models.DbModels;
using Models.DTOs;
using System.Collections.Generic;

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
    }
}
