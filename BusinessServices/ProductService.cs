using AutoMapper;
using IBusinessServices;
using IHelperServices;
using IRepositories;
using Microsoft.Extensions.Localization;
using Models.DbModels;
using Models.DTOs;

namespace BusinessServices
{
    public class ProductService : _BusinessService<Product, ProductDTO, ProductDTO>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper, IStringLocalizer stringLocalizer, ISessionServices sessionServices) : base(unitOfWork, mapper, stringLocalizer, sessionServices)
        {
        }
    }
}
