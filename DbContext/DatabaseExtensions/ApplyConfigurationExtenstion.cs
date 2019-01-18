using DbContexts.ModelsMappings;
using Microsoft.EntityFrameworkCore;
using Models.DbModels;

namespace DbContexts.DatabaseExtensions
{
    public static class ApplyConfigurationExtenstion
    {
        public static void ApplyModelsConfigurations(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<User>(new UserConfiguration());
            modelBuilder.ApplyConfiguration<Localization>(new LocalizationConfiguration());
            modelBuilder.ApplyConfiguration<Role>(new RoleConfiguration());
            modelBuilder.ApplyConfiguration<UserRole>(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration<Gender>(new GenderConfiguration());
            modelBuilder.ApplyConfiguration<Address>(new AddressConfiguration());
            modelBuilder.ApplyConfiguration<Product>(new ProductSpecification());
            modelBuilder.ApplyConfiguration<Specification>(new SpecificationConfiguration());
            modelBuilder.ApplyConfiguration<Photo>(new PhotoConfiguration());
        }
    }
}
