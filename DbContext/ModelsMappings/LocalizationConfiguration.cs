using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.DbModels;

namespace DbContexts.ModelsMappings
{
    public class LocalizationConfiguration : _IGlobalMapping<Localization>
    {
        public void Configure(EntityTypeBuilder<Localization> entity)
        {
            entity.HasIndex(x => new { x.Key }).IsUnique();
            entity.HasIndex(x => new { x.ValueAr }).IsUnique();
            entity.HasIndex(x => new { x.ValueEn }).IsUnique();

            entity.HasData(
                  new Localization { LocalizationId = 1, Key = "Agree", ValueAr = "موافق", ValueEn = "Ok" },
                  new Localization { LocalizationId = 2, Key = "Reject", ValueAr = "إلغاء", ValueEn = "Cancel" },
                  new Localization { LocalizationId = 3, Key = "Close", ValueAr = "إغلاق", ValueEn = "Close" },
                  new Localization { LocalizationId = 4, Key = "Yes", ValueAr = "نعم", ValueEn = "Yes" },
                  new Localization { LocalizationId = 5, Key = "No", ValueAr = "لا", ValueEn = "No" },
                  new Localization { LocalizationId = 11, Key = "InvalidCredentials", ValueAr = "خطأ في إسم المستخدم أو كلمة المرور", ValueEn = "Invalid Username Or Password" },
                  new Localization { LocalizationId = 12, Key = "UserName", ValueAr = "إسم المستخدم", ValueEn = "Username" },
                  new Localization { LocalizationId = 13, Key = "Password", ValueAr = "كلمة المرور", ValueEn = "Password" },
                  new Localization { LocalizationId = 14, Key = "Login", ValueAr = "دخول", ValueEn = "Login" },
                  new Localization { LocalizationId = 15, Key = "ChangeLang", ValueAr = "تغيير اللغة", ValueEn = "Change Language" },
                  new Localization { LocalizationId = 16, Key = "AccountIsDisabled", ValueAr = "الحساب متوقف من قبل الإدارة", ValueEn = "Account is disabled by administration" },
                  new Localization { LocalizationId = 17, Key = "CategoryNameAr", ValueAr = "الإسم التصنيف بالعربي", ValueEn = "Category Arabic Name" },
                  new Localization { LocalizationId = 18, Key = "CategoryNameEn", ValueAr = "الإسم التصنيف بالإنجليزي", ValueEn = "Category English Name" },
                  new Localization { LocalizationId = 19, Key = "CategoryCode", ValueAr = "كود التصنيف", ValueEn = "Category Code" },
                  new Localization { LocalizationId = 20, Key = "Categories", ValueAr = "التصنيفات", ValueEn = "Categories" },
                  new Localization { LocalizationId = 21, Key = "SystemComponents", ValueAr = "أجزاء الموقع", ValueEn = "System Components" },
                  new Localization { LocalizationId = 22, Key = "SubCategories", ValueAr = "التصنيفات الفرعية", ValueEn = "Sub Categories" },
                  new Localization { LocalizationId = 23, Key = "GlobalFilter", ValueAr = "بحث", ValueEn = "Search" },
                  new Localization { LocalizationId = 24, Key = "Create", ValueAr = "إضافة", ValueEn = "Create" },
                  new Localization { LocalizationId = 25, Key = "Delete", ValueAr = "حذف", ValueEn = "Delete" },
                  new Localization { LocalizationId = 26, Key = "Update", ValueAr = "تعديل", ValueEn = "Update" },
                  new Localization { LocalizationId = 27, Key = "DeleteConfirmation", ValueAr = "تأكيد الحذف", ValueEn = "Delete Confirmation" },
                  new Localization { LocalizationId = 28, Key = "WantDelete", ValueAr = "هل أنت متأكد من الحذف ؟", ValueEn = "Do you want to delete this record ?" },
                  new Localization { LocalizationId = 30, Key = "DeletedSuccess", ValueAr = "تم الحذف بنجاح", ValueEn = "Deleted Successfully" },
                  new Localization { LocalizationId = 31, Key = "DeletedFail", ValueAr = "لم يتم الحذف", ValueEn = "Deleted Failed" }
                );
        }
    }
}
