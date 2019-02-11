using IBusinessServices;
using IHelperServices;
using Models.DbModels;
using Models.DTOs;

namespace WebApi
{
    public class SubCategoryController : _BaseController<SubCategory, SubCategoryDTO, SubCategoryDTO>
    {
        private readonly ISubCategoryService _SubCategoryService;
        public SubCategoryController(ISubCategoryService businessService, ISessionServices sessionSevices) : base(businessService, sessionSevices)
        {
            _SubCategoryService = businessService;
        }
    }
}
