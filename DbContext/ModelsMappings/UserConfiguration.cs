using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.DbModels;

namespace DbContexts.ModelsMappings
{
    public class UserConfiguration : _IGlobalMapping<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.HasIndex(e => e.Username).IsUnique();
            entity.HasIndex(e => e.Email).IsUnique();
            entity.HasIndex(e => e.PhoneNumber).IsUnique();
            entity.Property(x => x.IsApproved).HasDefaultValue(false);
        }
    }
}
