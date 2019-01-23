using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.DbModels;

namespace DbContexts.ModelsMappings
{
    public class SubCategoryConfiguration : _IGlobalMapping<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> entity)
        {
            entity.HasKey(x => x.SubCategoryId);
            entity.HasIndex(x => x.SubCategoryNameAr).IsUnique();
            entity.HasIndex(x => x.SubCategoryNameEn).IsUnique();
            entity.HasIndex(x => x.Code).IsUnique();
        }
    }
}
