using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HelperServices.LinqHelpers
{
    public static partial class QueryableExtensions
    {
        public static IQueryable<T> CustomInclude<T>(this IQueryable<T> query, string include) where T : class
        {
            if (string.IsNullOrEmpty(include))
                return query;
            return query.Include(include);
        }

        public static IQueryable<T> CustomInclude<T>(this IQueryable<T> query, params string[] include) where T : class
        {
            if (include == null || include.Length == 0)
            {
                return query;
            }
            foreach (var inc in include)
            {
                query = query.Include(inc);
            }
            return query;
        }
    }
}