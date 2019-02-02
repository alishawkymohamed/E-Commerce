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
                  new Localization { LocalizationId = 11, Key = "InvalidCredentials", ValueAr = "خطأ في إسم المستخدم أو كلمة المرور", ValueEn = "Invalid Username Or Password" },
                  new Localization { LocalizationId = 12, Key = "UserName", ValueAr = "إسم المستخدم", ValueEn = "Username" },
                  new Localization { LocalizationId = 13, Key = "Password", ValueAr = "كلمة المرور", ValueEn = "Password" },
                  new Localization { LocalizationId = 14, Key = "Login", ValueAr = "دخول", ValueEn = "Login" },
                  new Localization { LocalizationId = 15, Key = "ChangeLang", ValueAr = "تغيير اللغة", ValueEn = "Change Language" },
                  new Localization { LocalizationId = 16, Key = "AccountIsDisabled", ValueAr = "الحساب متوقف من قبل الإدارة", ValueEn = "Account is disabled by administration" },
                  new Localization { LocalizationId = 17, Key = "CategoryNameAr", ValueAr = "الإسم التصنيف بالعربي", ValueEn = "Category Arabic Name" },
                  new Localization { LocalizationId = 18, Key = "CategoryNameEn", ValueAr = "الإسم التصنيف بالإنجليزي", ValueEn = "Category English Name" },
                  new Localization { LocalizationId = 19, Key = "CategoryCode", ValueAr = "كود التصنيف", ValueEn = "Category Code" },
                  new Localization { LocalizationId = 20, Key = "Categories", ValueAr = "التصنيفات", ValueEn = "Categories" }
                );
        }
    }
}
