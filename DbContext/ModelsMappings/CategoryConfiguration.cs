using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.DbModels;

namespace DbContexts.ModelsMappings
{
    public class CategoryConfiguration : _IGlobalMapping<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.HasKey(x => x.CategoryId);
            entity.HasIndex(x => x.CategoryNameAr).IsUnique();
            entity.HasIndex(x => x.CategoryNameEn).IsUnique();
            entity.HasIndex(x => x.CategoryCode).IsUnique();
            entity.Property(x => x.CategoryCode).IsRequired();
            entity.Property(x => x.CategoryNameAr).IsRequired();
        }
    }
}
