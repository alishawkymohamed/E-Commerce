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
                  new Localization { LocalizationId = 6, Key = "Save", ValueAr = "حفظ", ValueEn = "Save" },
                  new Localization { LocalizationId = 7, Key = "SavedSuccess", ValueAr = "تم الحفظ بنجاح", ValueEn = "Saved Successfully" },
                  new Localization { LocalizationId = 8, Key = "ErrorOccured", ValueAr = "حدث خطأ ما", ValueEn = "Error Occured" },
                  new Localization { LocalizationId = 9, Key = "Seller", ValueAr = "بائع", ValueEn = "Seller" },
                  new Localization { LocalizationId = 10, Key = "User", ValueAr = "مستخدم", ValueEn = "User" },
                  new Localization { LocalizationId = 11, Key = "InvalidCredentials", ValueAr = "خطأ في إسم المستخدم أو كلمة السر", ValueEn = "Invalid Username Or Password" },
                  new Localization { LocalizationId = 12, Key = "UserName", ValueAr = "إسم المستخدم", ValueEn = "Username" },
                  new Localization { LocalizationId = 13, Key = "Password", ValueAr = "كلمة السر", ValueEn = "Password" },
                  new Localization { LocalizationId = 14, Key = "Login", ValueAr = "دخول", ValueEn = "Login" },
                  new Localization { LocalizationId = 15, Key = "ChangeLang", ValueAr = "تغيير اللغة", ValueEn = "Change Language" },
                  new Localization { LocalizationId = 16, Key = "AccountIsDisabled", ValueAr = "الحساب متوقف من قبل الإدارة", ValueEn = "Account is disabled by administration" },
                  new Localization { LocalizationId = 17, Key = "NameAr", ValueAr = "الإسم بالعربي", ValueEn = "Arabic Name" },
                  new Localization { LocalizationId = 18, Key = "NameEn", ValueAr = "الإسم بالإنجليزي", ValueEn = "English Name" },
                  new Localization { LocalizationId = 19, Key = "Code", ValueAr = "الكود", ValueEn = "Code" },
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
                  new Localization { LocalizationId = 31, Key = "DeletedFail", ValueAr = "لم يتم الحذف", ValueEn = "Deleted Failed" },
                  new Localization { LocalizationId = 32, Key = "Category", ValueAr = "تصنيف", ValueEn = "Category" },
                  new Localization { LocalizationId = 33, Key = "SubCategory", ValueAr = "تصنيف فرعي", ValueEn = "Sub Category" },

                  new Localization { LocalizationId = 34, Key = "SignIn", ValueAr = "تسجيل دخول", ValueEn = "Sign In" },
                  new Localization { LocalizationId = 35, Key = "SignUp", ValueAr = "إنشاء حساب", ValueEn = "Sign Up" },
                  new Localization { LocalizationId = 36, Key = "ForgetPassword", ValueAr = "نسيت كلمة السر ؟", ValueEn = "Forget Password ?" },
                  new Localization { LocalizationId = 37, Key = "SignUpNewAccount", ValueAr = "إنشاء حساب جديد", ValueEn = "Sign up new account" },
                  new Localization { LocalizationId = 38, Key = "EmailAddress", ValueAr = "البريد الإلكتروني", ValueEn = "Email Address" },
                  new Localization { LocalizationId = 39, Key = "SignInWithFacebook", ValueAr = "دخول بواسطة فيسبوك", ValueEn = "Sign in with Facebook" },
                  new Localization { LocalizationId = 40, Key = "SignUpWithFacebook", ValueAr = "إنشاء حساب بواسطة فيسبوك", ValueEn = "Sign up with Facebook" },
                  new Localization { LocalizationId = 41, Key = "SignInWithGmail", ValueAr = "دخول بواسطة جوجل", ValueEn = "Sign in With Gmail" },
                  new Localization { LocalizationId = 42, Key = "SignUpWithGmail", ValueAr = "إنشاء حساب بواسطة جوجل", ValueEn = "Sign up with Gmail" },
                  new Localization { LocalizationId = 43, Key = "FullName", ValueAr = "الإسم بالكامل", ValueEn = "Full Name" },
                  new Localization { LocalizationId = 44, Key = "ConfirmPassword", ValueAr = "تأكيد كلمة السر", ValueEn = "Confirm Password" },
                  new Localization { LocalizationId = 45, Key = "Back", ValueAr = "عودة", ValueEn = "Back" },
                  new Localization { LocalizationId = 46, Key = "WaitApprove", ValueAr = "تم إرسال طلب إنضمامك للموقع للمدير المسئول و سيتم إخطارك عن الموافقة علي طلبك", ValueEn = "Your request to join our website is sent to admin and you'll be notified after his approval" },
                  new Localization { LocalizationId = 47, Key = "Admin", ValueAr = "مدير النظام", ValueEn = "Admin" },
                  new Localization { LocalizationId = 48, Key = "Products", ValueAr = "المنتجات", ValueEn = "Products" },
                  new Localization { LocalizationId = 49, Key = "Product", ValueAr = "منتج", ValueEn = "Product" },
                  new Localization { LocalizationId = 50, Key = "Price", ValueAr = "السعر", ValueEn = "Price" },
                  new Localization { LocalizationId = 51, Key = "Deduction", ValueAr = "التخفيض", ValueEn = "Deduction" },
                  new Localization { LocalizationId = 52, Key = "Photo", ValueAr = "الصورة", ValueEn = "Photo" },
                  new Localization { LocalizationId = 53, Key = "RealPhotos", ValueAr = "الصور الحقيقية", ValueEn = "Real Photos" },
                  new Localization { LocalizationId = 54, Key = "MainPhoto", ValueAr = "الصورة الرئيسية", ValueEn = "Main Photo" },
                  new Localization { LocalizationId = 55, Key = "CommercialPhotos", ValueAr = "الصور التسويقية", ValueEn = "Commercial Photo" },
                  new Localization { LocalizationId = 56, Key = "Specifications", ValueAr = "المواصفات", ValueEn = "Specifications" },
                  new Localization { LocalizationId = 57, Key = "Value", ValueAr = "القيمة", ValueEn = "Value" },
                  new Localization { LocalizationId = 58, Key = "ValueAr", ValueAr = "القيمة بالعربي", ValueEn = "Arabic Value" },
                  new Localization { LocalizationId = 59, Key = "ValueEn", ValueAr = "القيمة بالإنجليزي", ValueEn = "English Value" }
                  );
        }
    }
}
