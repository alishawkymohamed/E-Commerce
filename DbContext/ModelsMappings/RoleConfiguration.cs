using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.DbModels;
using System;

namespace DbContexts.ModelsMappings
{
    public class RoleConfiguration : _IGlobalMapping<Role>
    {
        public void Configure(EntityTypeBuilder<Role> entity)
        {
            entity.HasKey(x => x.RoleId);
            entity.HasIndex(e => e.RoleNameEn).IsUnique();
            entity.HasIndex(e => e.RoleNameAr).IsUnique();

            entity.HasData(
                new Role { RoleId = 1, RoleNameAr = "مدير النظام", RoleNameEn = "Admin", CreatedOn = DateTimeOffset.Now },
                new Role { RoleId = 2, RoleNameAr = "بائع", RoleNameEn = "Seller", CreatedOn = DateTimeOffset.Now },
                new Role { RoleId = 3, RoleNameAr = "مستخدم", RoleNameEn = "User", CreatedOn = DateTimeOffset.Now }
                );
        }
    }
}
