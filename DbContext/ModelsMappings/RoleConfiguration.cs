using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.DbModels;

namespace DbContexts.ModelsMappings
{
    public class RoleConfiguration : _IGlobalMapping<Role>
    {
        public void Configure(EntityTypeBuilder<Role> entity)
        {
            entity.HasIndex(e => e.RoleNameEn).IsUnique();
            entity.HasIndex(e => e.RoleNameAr).IsUnique();

            entity.HasData(
                new Role { RoleId = 1, RoleNameAr = "مدير النظام", RoleNameEn = "Administrator" }
                );
        }
    }
}
