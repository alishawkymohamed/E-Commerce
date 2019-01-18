using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.DbModels;

namespace DbContexts.ModelsMappings
{
    public class GenderConfiguration : _IGlobalMapping<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> entity)
        {
            entity.HasKey(x => x.GenderId);
            entity.HasIndex(e => e.GenderNameAr).IsUnique();
            entity.HasIndex(e => e.GenderNameEn).IsUnique();
        }
    }
}
