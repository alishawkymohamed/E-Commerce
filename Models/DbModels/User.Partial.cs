using Models.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DbModels
{
    public partial class User : _BaseEntity, IAuditableInsert, IAuditableUpdate, IAuditableDelete, IAssertableConcurrencyStamp
    {
        [InverseProperty("CreatedByUser")]
        public virtual ICollection<Localization> LocalizationCreatedUser { get; set; }
        [InverseProperty("UpdatedByUser")]
        public virtual ICollection<Localization> LocalizationUpdatedUser { get; set; }


        [InverseProperty("CreatedByUser")]
        public virtual ICollection<UserRole> UserRoleCreatedUser { get; set; }
        [InverseProperty("UpdatedByUser")]
        public virtual ICollection<UserRole> UserRoleUpdatedUser { get; set; }


        [InverseProperty("UpdatedByUser")]
        public virtual ICollection<Role> RoleUpdatedUser { get; set; }
        [InverseProperty("CreatedByUser")]
        public virtual ICollection<Role> RoleCreatedUser { get; set; }


        [InverseProperty("UpdatedByUser")]
        public virtual ICollection<Product> ProductUpdatedUser { get; set; }
        [InverseProperty("CreatedByUser")]
        public virtual ICollection<Product> ProductCreatedUser { get; set; }
        [InverseProperty("DeletedByUser")]
        public virtual ICollection<Product> ProductDeletedUser { get; set; }


        [InverseProperty("UpdatedByUser")]
        public virtual ICollection<Specification> SpecificationUpdatedUser { get; set; }
        [InverseProperty("CreatedByUser")]
        public virtual ICollection<Specification> SpecificationCreatedUser { get; set; }
        [InverseProperty("DeletedByUser")]
        public virtual ICollection<Specification> SpecificationDeletedUser { get; set; }


        [InverseProperty("UpdatedByUser")]
        public virtual ICollection<User> UserUpdatedUser { get; set; }
        [InverseProperty("CreatedByUser")]
        public virtual ICollection<User> UserCreatedUser { get; set; }
        [InverseProperty("DeletedByUser")]
        public virtual ICollection<User> UserDeletedUser { get; set; }


        [InverseProperty("DeletedByUser")]
        public virtual ICollection<Photo> PhotoDeletedUser { get; set; }
    }
}
