using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Models.DbModels
{
    public partial class User : _BaseEntity, IAuditableInsert, IAuditableUpdate, IAuditableDelete, IAssertableConcurrencyStamp
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
            UserTokens = new HashSet<UserToken>();
        }
        public int UserId { get; set; }

        [Required]
        [MaxLength(450)]
        public string Username { get; set; }

        [Required]
        [MaxLength(450)]
        public string Password { get; set; }

        [Required]
        [MaxLength(100), EmailAddress]
        public string Email { get; set; }

        public bool Enabled { get; set; }

        public DateTimeOffset? LastLoggedIn { get; set; }

        public byte[] ProfileImage { get; set; }

        public string ConcurrencyStamp { get; set; }
        /// <summary>
        /// every time the user changes his Password,
        /// or an admin changes his Roles or stat/IsActive,
        /// create a new `SerialNumber` GUID and store it in the DB.
        /// </summary>
        public string SerialNumber { get; set; }

        [MaxLength(100)]
        public string FullNameEn { get; set; }

        [MaxLength(100)]
        public string FullNameAr { get; set; }
        [NotMapped]
        public string FullName => CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString().StartsWith("ar") ?
                    (string.IsNullOrEmpty(FullNameAr) ? FullNameEn : FullNameAr) :
                    (string.IsNullOrEmpty(FullNameEn) ? FullNameAr : FullNameEn);

        public DateTimeOffset? EnabledUntil { get; set; }

        [MaxLength(50), Phone]
        public string PhoneNumber { get; set; }

        public bool? NotificationByMail { get; set; }

        public bool? NotificationBySMS { get; set; }

        [MaxLength(5)]
        public string DefaultCulture { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<UserRole> UserRoles { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<UserToken> UserTokens { get; set; }
        [InverseProperty("User")]

        [ForeignKey("Gender")]
        public int? GenderId { get; set; }
        public virtual Gender Gender { get; set; }

        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public virtual Address Address { get; set; }

        public virtual ICollection<Product> Products { get; set; }

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

        #region IAuditableDelete

        public int? DeletedBy { get; set; }
        [ForeignKey("DeletedBy")]
        public virtual User DeletedByUser { get; set; }
        public DateTimeOffset? DeletedOn { get; set; }

        #endregion IAuditableDelete
    }
}
