using Models.DbModels;
using Models.DTOs;

namespace IBusinessServices
{
    public interface ICategoryService : _IBusinessService<Category, CategoryDTO, CategoryDTO>
    {
    }
}
