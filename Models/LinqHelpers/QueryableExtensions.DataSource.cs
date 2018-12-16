using LinqHelper;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace HelperServices.LinqHelpers
{
    public static partial class QueryableExtensions
    {
        /// <summary>
        /// Applies data processing (paging, sorting and filtering) over IQueryable using Dynamic Linq.
        /// </summary>
        /// <typeparam name="T">The type of the IQueryable</typeparam>
        /// <param name="queryable">The IQueryable which should be processed.</param>
        /// <param name="take">Specifies how many items to take. Configurable via the pageSize setting of the Kendo DataSource.</param>
        /// <param name="skip">Specifies how many items to skip.</param>
        /// <param name="sort">Specifies the current sort order.</param>
        /// <param name="filter">Specifies the current filter.</param>
        /// <returns>A DataSourceResult object populated from the processed IQueryable.</returns>
        public static DataSourceResult<T> ToDataSourceResult<T>(this IQueryable<T> queryable, int take, int skip, IEnumerable<Sort> sort, Filter filter, bool countless)
        {
            // Filter the data first
            queryable = Filter(queryable, filter);

            //Get count before paging data
            var count = countless ? -1 : queryable.Count();

            // Sort the data
            queryable = Sort(queryable, sort);

            // Finally page the data
            queryable = Page(queryable, take, skip);

            return new DataSourceResult<T>
            {
                Data = queryable,
                Count = count
            };
        }

        public static DataSourceResult<T> ToDataSourceResult<T>(this IQueryable<T> queryable, DataSourceRequest dataSourceRequest, bool? countless = null)
        {
            dataSourceRequest = dataSourceRequest ?? new DataSourceRequest();
            return ToDataSourceResult(queryable, dataSourceRequest.Take, dataSourceRequest.Skip, dataSourceRequest.Sort, dataSourceRequest.Filter, countless ?? dataSourceRequest.Countless);
        }
    }
}