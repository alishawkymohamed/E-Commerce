using Microsoft.EntityFrameworkCore.Query;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;

namespace HelperServices.LinqHelpers
{
    public static partial class QueryableExtensions
    {
        public static IQueryable<T> Page<T>(this IQueryable<T> queryable, int take, int skip)
        {
            if (!(queryable is IOrderedQueryable) && !(queryable.Expression.Type.GetTypeInfo().GetGenericTypeDefinition() == typeof(IIncludableQueryable<,>)))
                queryable = queryable.OrderBy(new Sort() { Field = "1", Dir = "" }.ToExpression());
            if (take != 0)
            {
                return queryable.Skip(skip).Take(take);
            }

            return queryable;
        }
    }
}