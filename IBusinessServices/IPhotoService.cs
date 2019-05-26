using Models.DbModels;
using Models.DTOs;

namespace IBusinessServices
{
    public interface IPhotoService : _IBusinessService<Photo, PhotoDTO, PhotoDTO>
    {
    }
}
