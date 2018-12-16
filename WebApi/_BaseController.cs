using IBusinessServices;
using IHelperServices;
using LinqHelper;
using Microsoft.AspNetCore.Mvc;
using Models.DbModels;
using Models.DTOs;
using System.Collections.Generic;

namespace WebApi
{
    //[Authorize(Policy = "AuthenticatedOnlyPolicy")]
    //[AutoValidateAntiforgeryToken]
    [Route("api/[controller]")]
    public class _BaseController : Controller
    {
        protected readonly _IBusinessService _BusinessService;
        protected readonly ISessionServices _SessionServices;
        public _BaseController(_IBusinessService businessService)
        {
            _BusinessService = businessService;
        }

        public _BaseController(_IBusinessService businessService, ISessionServices sessionSevices)
        {
            _BusinessService = businessService;
            _SessionServices = sessionSevices;
        }
    }

    //[Authorize(Policy = "HasPermissionPolicy")]
    [Route("api/[controller]")]
    public class _BaseController<TDbEntity, TSummaryDTO, TDetailsDTO> : Controller where TDbEntity : _BaseEntity
    {
        protected readonly _IBusinessService<TDbEntity, TSummaryDTO, TDetailsDTO> _BusinessService;
        protected readonly ISessionServices _SessionServices;

        public _BaseController(_IBusinessService<TDbEntity, TSummaryDTO, TDetailsDTO> businessService)
        {
            _BusinessService = businessService;
        }

        public _BaseController(_IBusinessService<TDbEntity, TSummaryDTO, TDetailsDTO> businessService, ISessionServices sessionSevices)
        {
            _BusinessService = businessService;
            _SessionServices = sessionSevices;
        }

        [HttpGet, Route("GetAll")]
        public virtual DataSourceResult<TSummaryDTO> GetAll([FromQuery]DataSourceRequest dataSourceRequest)
        {
            return _BusinessService.GetAll<TSummaryDTO>(dataSourceRequest, false);
        }

        [HttpGet, Route("GetAllDetails")]
        public virtual DataSourceResult<TDetailsDTO> GetAllDetails([FromQuery]DataSourceRequest dataSourceRequest)
        {
            return _BusinessService.GetAll<TDetailsDTO>(dataSourceRequest, false);
        }

        [HttpGet, Route("GetById")]
        public virtual TDetailsDTO Get(string id)
        {
            return _BusinessService.GetDetails(id, false);
        }

        [HttpPost, Route("Insert")]
        public virtual IEnumerable<TDetailsDTO> Post([FromBody]IEnumerable<TDetailsDTO> entities)
        {
            return _BusinessService.Insert(entities);
        }

        [HttpPut, Route("Update")]
        public virtual IEnumerable<TDetailsDTO> Put([FromBody]IEnumerable<TDetailsDTO> entities)
        {
            return _BusinessService.Update(entities);
        }

        [HttpDelete, Route("Delete")]
        public virtual IEnumerable<object> Delete([FromBody]object[] ids)
        {
            return _BusinessService.Delete(ids);
        }

        [HttpPost, Route("IsExisted")]
        public virtual bool CheckIfExist([FromBody]CheckUniqueDTO checkUniqueDTO)
        {
            return _BusinessService.CheckIfExist(checkUniqueDTO);
        }
    }

    #region Remove Complex Implementation To Ensure More Simplicity
    //public class _BaseController<TBusinessService, TDbEntity, TSummaryDTO> : _BaseController<TBusinessService, TDbEntity, TSummaryDTO, TDbEntity>
    // where TDbEntity : _BaseEntity
    //where TBusinessService : _IBusinessService<TDbEntity, TSummaryDTO>
    //{
    //    public _BaseController(TBusinessService businessService) : base(businessService)
    //    {
    //    }
    //    public _BaseController(TBusinessService businessService, ISessionServices sessionSevices) : base(businessService, sessionSevices)
    //    {

    //    }
    //}

    //public class _BaseController<TBusinessService, TDbEntity> : _BaseController<TBusinessService, TDbEntity, TDbEntity, TDbEntity>
    //     where TDbEntity : _BaseEntity
    //    where TBusinessService : _IBusinessService<TDbEntity>
    //{
    //    public _BaseController(TBusinessService businessService) : base(businessService)
    //    {
    //    }
    //    public _BaseController(TBusinessService businessService, ISessionServices sessionSevices) : base(businessService, sessionSevices)
    //    {

    //    }
    //}
    #endregion
}
