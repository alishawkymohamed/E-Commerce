using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace LinqHelper
{
    public static partial class DbSetExtensions
    {
        public static IQueryable<TEntity> FindQuery<TEntity>(this DbSet<TEntity> set, params object[] keyValues) where TEntity : class
        {
            var context = ((IInfrastructure<IServiceProvider>)set).GetService<ICurrentDbContext>().Context;

            var entityType = context.Model.FindEntityType(typeof(TEntity));
            var key = entityType.FindPrimaryKey();

            var entries = context.ChangeTracker.Entries<TEntity>();
            //Edit to find with the full entity object
            var i = 0;
            if (Convert.GetTypeCode(keyValues[0]) == TypeCode.Object)//is object
            {
                var newKeyValues = new object[key.Properties.Count];
                var entity = keyValues[0];
                i = 0;
                foreach (var property in key.Properties)
                {
                    newKeyValues[i] = entity.GetType().GetProperty(property.Name).GetValue(entity);
                    i++;
                }
                keyValues = newKeyValues;
            }

            i = 0;
            foreach (var property in key.Properties)
            {
                var keyValue = keyValues[i];
                entries = entries.Where(e => e.Property(property.Name).CurrentValue == keyValue);
                i++;
            }
            //var entry = entries.FirstOrDefault();
            //if (entry != null)
            //{
            //    // Return the local object if it exists.
            //    //return entry.Entity;
            //}

            // TODO: Build the real LINQ Expression
            // set.Where(x => x.Id == keyValues[0]);
            var parameter = Expression.Parameter(typeof(TEntity), "x");
            var query = set.AsQueryable();
            i = 0;
            foreach (var property in key.Properties)
            {
                var propertyName = key.Properties[i].Name;
                Type clrType = key.Properties[i].ClrType;
                var keyValue = TypeDescriptor.GetConverter(key.Properties[i].ClrType).ConvertFromInvariantString(Convert.ToString(keyValues[i]));

                query = query.Where((Expression<Func<TEntity, bool>>)
                Expression.Lambda(
                    Expression.Equal(
                        Expression.Property(parameter, propertyName),
                        Expression.Constant(keyValue)),
                    parameter));
                i++;
            }

            // Look in the database
            return query;
        }
    }
}