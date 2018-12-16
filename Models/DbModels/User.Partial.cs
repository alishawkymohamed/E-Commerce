using Models.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DbModels
{
    public partial class User : _BaseEntity, IAuditableInsert, IAuditableUpdate, IAuditableDelete, IAssertableConcurrencyStamp
    {
        [InverseProperty("CreatedByUser")]
        public virtual ICollection<Localization> LocalizationCreatedUser { get; set; }

        [InverseProperty("CreatedByUser")]
        public virtual ICollection<UserRole> UserRoleCreatedUser { get; set; }

        [InverseProperty("CreatedByUser")]
        public virtual ICollection<Role> RoleCreatedUser { get; set; }

        [InverseProperty("UpdatedByUser")]
        public virtual ICollection<UserRole> UserRoleUpdatedUser { get; set; }

        [InverseProperty("UpdatedByUser")]
        public virtual ICollection<Localization> LocalizationUpdatedUser { get; set; }

        [InverseProperty("UpdatedByUser")]
        public virtual ICollection<Role> RoleUpdatedUser { get; set; }
    }
}
