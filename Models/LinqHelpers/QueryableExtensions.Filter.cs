using System.Linq;
using System.Linq.Dynamic.Core;

namespace HelperServices.LinqHelpers
{
    public static partial class QueryableExtensions
    {
        public static IQueryable<T> Filter<T>(this IQueryable<T> queryable, Filter filter)
        {
            if (filter != null && (!string.IsNullOrEmpty(filter.Field) || (filter.Filters != null && filter.Filters.Any())))
            {
                // Collect a flat list of all filters
                var filters = filter.All();

                // Create a predicate expression e.g. Field1 = @0 And Field2 > @1
                string predicate = filter.ToExpression(filters);

                // Get all filter values as array (needed by the Where method of Dynamic Linq)
                var values = filters.Select(f => f.Value).ToArray();

                // Use the Where method of Dynamic Linq to filter the data
                queryable = queryable.Where(predicate, values);
            }

            return queryable;
        }
    }
}