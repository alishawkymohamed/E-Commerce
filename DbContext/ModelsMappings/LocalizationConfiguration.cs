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
                  new Localization() { LocalizationId = 1, Key = "InvalidCredentials", ValueAr = "خطأ في إسم المستخدم أو كلمة المرور", ValueEn = "Invalid Username Or Password" },
                  new Localization() { LocalizationId = 2, Key = "UserName", ValueAr = "إسم المستخدم", ValueEn = "Username" },
                  new Localization() { LocalizationId = 3, Key = "Password", ValueAr = "كلمة المرور", ValueEn = "Password" },
                  new Localization() { LocalizationId = 4, Key = "Login", ValueAr = "دخول", ValueEn = "Login" },
                  new Localization() { LocalizationId = 5, Key = "ChangeLang", ValueAr = "تغيير اللغة", ValueEn = "Change Language" },
                  new Localization() { LocalizationId = 6, Key = "AccountIsDisabled", ValueAr = "الحساب متوقف من قبل الإدارة", ValueEn = "Account is disabled by administration" },
                  new Localization() { LocalizationId = 7, Key = "AccountIsDisabledSince", ValueAr = "الحساب متوقف منذ  {0:yyyy-MM-dd}", ValueEn = "Account is disabled since {0:dd-MM-yyyy}" }
                );
        }
    }
}
