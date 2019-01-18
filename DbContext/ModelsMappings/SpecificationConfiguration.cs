using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.DbModels;

namespace DbContexts.ModelsMappings
{
    public class SpecificationConfiguration : _IGlobalMapping<Specification>
    {
        public void Configure(EntityTypeBuilder<Specification> entity)
        {
            entity.HasKey(x => x.SpecificationId);
        }
    }
}
