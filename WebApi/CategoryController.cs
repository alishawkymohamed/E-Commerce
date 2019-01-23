using IBusinessServices;
using IHelperServices;
using Models.DbModels;
using Models.DTOs;

namespace WebApi
{
    public class CategoryController : _BaseController<Category, CategoryDTO, CategoryDTO>
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService businessService, ISessionServices sessionSevices) : base(businessService, sessionSevices)
        {
            _categoryService = businessService;
        }
    }
}
