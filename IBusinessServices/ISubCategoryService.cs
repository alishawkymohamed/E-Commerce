using Models.DbModels;
using Models.DTOs;

namespace IBusinessServices
{
    public interface ISubCategoryService : _IBusinessService<SubCategory, SubCategoryDTO, SubCategoryDTO>
    {
    }
}
