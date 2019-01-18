using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.DbModels;

namespace DbContexts.ModelsMappings
{
    public class PhotoConfiguration : _IGlobalMapping<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> entity)
        {
            entity.HasKey(x => x.PhotoId);
        }
    }
}
