using IBusinessServices;
using LinqHelper;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebApi
{
    public class LookupController : _BaseController
    {
        protected readonly ILookupService _LookupService;
        public LookupController(ILookupService businessService) : base(businessService)
        {
            _LookupService = businessService;
        }

        [HttpGet]
        public IEnumerable<Lookup> Get([FromQuery] string type, [FromQuery]string searchText, [FromQuery]DataSourceRequest dataSourceRequest, [FromQuery] string args = null)
        {
            Dictionary<string, dynamic> argsDictionary = args == null ? null : JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(args);
            return _LookupService.Get(type, searchText, dataSourceRequest, argsDictionary, null);
        }

        [HttpPost]
        public IEnumerable<Lookup> Post([FromQuery] string type, [FromBody] object[] ids)
        {
            return _LookupService.Get(type, null, null, null, ids);
        }
    }
}
