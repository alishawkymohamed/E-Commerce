using Models.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Models.DbModels
{
    public class Localization : _BaseEntity, IAuditableInsert, IAuditableUpdate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LocalizationId { get; set; }

        [MaxLength(100)]
        [Required]
        public string Key { get; set; }
        [Required]
        public string ValueAr { get; set; }
        [Required]
        public string ValueEn { get; set; }
        [NotMapped]
        public string Value => CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToString().StartsWith("ar") ?
                    (string.IsNullOrEmpty(ValueAr) ? ValueEn : ValueAr) :
                    (string.IsNullOrEmpty(ValueEn) ? ValueAr : ValueEn);


        #region IAuditableUpdate

        public int? UpdatedBy { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }

        [ForeignKey("UpdatedBy")]
        public virtual User UpdatedByUser { get; set; }

        #endregion IAuditableUpdate

        #region IAuditableInseret 
        public int? CreatedBy { get; set; }
        public DateTimeOffset? CreatedOn { get; set; }

        [ForeignKey("CreatedBy")]
        public virtual User CreatedByUser { get; set; }
        #endregion
    }
}
