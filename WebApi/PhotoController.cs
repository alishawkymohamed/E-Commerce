using IBusinessServices;
using IHelperServices;
using Microsoft.AspNetCore.Mvc;
using Models.DbModels;
using Models.DTOs;

namespace WebApi
{
    [Route("api/[controller]")]
    public class PhotoController : _BaseController<Photo, PhotoDTO, PhotoDTO>
    {
        private readonly IPhotoService _PhotoService;
        public PhotoController(IPhotoService businessService, ISessionServices sessionSevices) : base(businessService, sessionSevices)
        {
            _PhotoService = businessService;
        }
    }
}
