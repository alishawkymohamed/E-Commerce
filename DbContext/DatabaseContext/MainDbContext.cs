using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata;
using Models.DbModels;
using Models.Interfaces;
using System.Linq;

namespace DbContexts.DatabaseExtensions
{
    public class MainDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=eCommerce;Trusted_Connection=True;ConnectRetryCount=0")
                .ConfigureWarnings(warnings => warnings.Throw(CoreEventId.IncludeIgnoredWarning));
        }

        public MainDbContext()
        {

        }
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (IMutableForeignKey relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            foreach (IMutableEntityType type in modelBuilder.Model.GetEntityTypes().Where(type => typeof(IAuditableDelete).IsAssignableFrom(type.ClrType)))
            {
                modelBuilder.SetSoftDeleteFilter(type.ClrType);
            }

            modelBuilder.ApplyModelsConfigurations();

            base.OnModelCreating(modelBuilder);

        }

        #region Database Models
        public DbSet<Localization> Localizations { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserToken> UserToken { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Specification> Specifications { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        #endregion
    }
}