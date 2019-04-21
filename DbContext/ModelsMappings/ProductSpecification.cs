using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.DbModels;

namespace DbContexts.ModelsMappings
{
    public class ProductSpecification : _IGlobalMapping<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.HasKey(x => x.ProductId);
            entity.HasIndex(x => x.Code).IsUnique();
            entity.Property(x => x.Code).HasMaxLength(50);
            entity.Property(x => x.IsApproved).HasDefaultValue(false);
        }
    }
}
