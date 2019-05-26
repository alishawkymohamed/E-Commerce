using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.DbModels;

namespace DbContexts.ModelsMappings
{
    public class PhotoConfiguration : _IGlobalMapping<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> entity)
        {
            entity.HasKey(x => x.PhotoId);
            entity.HasIndex(x => x.Path).IsUnique();
            entity.HasIndex(x => x.UniqueName).IsUnique();
            entity.Property(x => x.IsMainPhoto).HasDefaultValue(false);
            entity.Property(x => x.IsRealPhoto).HasDefaultValue(false);
            entity.Property(x => x.IsCommercialPhoto).HasDefaultValue(false);
        }
    }
}
