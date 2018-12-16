using Models.Interfaces;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.DbModels
{
    public class UserRole : _BaseEntity, IAuditableInsert, IAuditableUpdate
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public DateTimeOffset? EnabledSince { get; set; }
        public DateTimeOffset? EnabledUntil { get; set; }
        public string Notes { get; set; }
        public bool? LastSelected { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

        public int? CreatedBy { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual User CreatedByUser { get; set; }

        public DateTimeOffset? CreatedOn { get; set; }

        public int? UpdatedBy { get; set; }

        [ForeignKey("UpdatedBy")]
        public virtual User UpdatedByUser { get; set; }

        public DateTimeOffset? UpdatedOn { get; set; }
    }
}