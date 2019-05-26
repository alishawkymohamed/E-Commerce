using IBusinessServices;
using IHelperServices;
using Microsoft.AspNetCore.Mvc;
using Models.DbModels;
using Models.DTOs;

namespace WebApi
{
    [Route("api/[controller]")]
    public class SpecificationController : _BaseController<Specification, SpecificationDTO, SpecificationDTO>
    {
        private readonly ISpecificationService _SpecificationService;
        public SpecificationController(ISpecificationService businessService, ISessionServices sessionSevices) : base(businessService, sessionSevices)
        {
            _SpecificationService = businessService;
        }
    }
}
