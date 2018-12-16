using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Models.DbModels
{
    public class Role : _BaseEntity, IAuditableInsert, IAuditableUpdate
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();
        }
        public int RoleId { get; set; }

        [NotMapped]
        public string RoleName
        {
            get => CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString().StartsWith("ar") ?
                    (string.IsNullOrEmpty(RoleNameAr) ? RoleNameEn : RoleNameAr) :
                    (string.IsNullOrEmpty(RoleNameEn) ? RoleNameAr : RoleNameEn);
            private set { }
        }

        [MaxLength(100)]
        public string RoleNameAr { get; set; }

        [NotMapped]
        [MaxLength(100)]
        public string RoleNameEn { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }

        #region IAuditableInsert

        public int? CreatedBy { get; set; }
        public DateTimeOffset? CreatedOn { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual User CreatedByUser { get; set; }

        #endregion IAuditableInsert

        #region IAuditableUpdate

        public int? UpdatedBy { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }

        [ForeignKey("UpdatedBy")]
        public virtual User UpdatedByUser { get; set; }

        #endregion IAuditableUpdate

    }
}