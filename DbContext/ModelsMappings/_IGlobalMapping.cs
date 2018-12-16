using Microsoft.EntityFrameworkCore;
using Models.DbModels;

namespace DbContexts.ModelsMappings
{
    public interface _IGlobalMapping<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : _BaseEntity
    {
    }
}
