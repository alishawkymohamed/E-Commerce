using Microsoft.EntityFrameworkCore;
using Models.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace DbContexts.DatabaseExtensions
{
    public static class FilterExtensions
    {
        public static void SetSoftDeleteFilter(this ModelBuilder modelBuilder, Type entityType)
        {
            SetSoftDeleteFilterMethod.MakeGenericMethod(entityType)
                .Invoke(null, new object[] { modelBuilder });
        }

        private static readonly MethodInfo SetSoftDeleteFilterMethod = typeof(FilterExtensions)
                   .GetMethods(BindingFlags.Public | BindingFlags.Static)
                   .Single(t => t.IsGenericMethod && t.Name == "SetSoftDeleteFilter");

        public static void SetSoftDeleteFilter<TEntity>(this ModelBuilder modelBuilder)
            where TEntity : class, IAuditableDelete
        {
            modelBuilder.Entity<TEntity>().HasQueryFilter(x => !x.DeletedOn.HasValue);
        }
    }
}
