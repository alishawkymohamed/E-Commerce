using LinqHelper;
using Models.DTOs;
using System.Collections.Generic;

namespace IBusinessServices
{
    public interface ILookupService : _IBusinessService
    {
        IEnumerable<Lookup> Get(string Type, string SearchText, DataSourceRequest dataSourceRequest, Dictionary<string, object> args, object[] ids = null);
    }
}
