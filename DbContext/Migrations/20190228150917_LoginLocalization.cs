using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbContexts.Migrations
{
    public partial class LoginLocalization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Localizations",
                columns: new[] { "LocalizationId", "CreatedBy", "CreatedOn", "Key", "UpdatedBy", "UpdatedOn", "ValueAr", "ValueEn" },
                values: new object[,]
                {
                    { 34, null, null, "SignIn", null, null, "تسجيل دخول", "Sign In" },
                    { 35, null, null, "SignUp", null, null, "إنشاء حساب", "Sign Up" },
                    { 36, null, null, "ForgetPassword", null, null, "نسيت كلمة السر ؟", "Forget Password ?" },
                    { 37, null, null, "SignUpNewAccount", null, null, "إنشاء حساب جديد", "Sign Up New Account" },
                    { 38, null, null, "EmailAddress", null, null, "البريد الإلكتروني", "Email Address" },
                    { 39, null, null, "SignInWithFacebook", null, null, "دخول بواسطة فيسبوك", "SignIn With Facebook" },
                    { 40, null, null, "SignUpWithFacebook", null, null, "إنشاء حساب بواسطة فيسبوك", "Sign Up With Facebook" },
                    { 41, null, null, "SignInWithGmail", null, null, "دخول بواسطة جوجل", "SignIn With Gmail" },
                    { 42, null, null, "SignUpWithGmail", null, null, "إنشاء حساب بواسطة جوجل", "Sign Up With Gmail" },
                    { 43, null, null, "FullName", null, null, "الإسم بالكامل", "Full Name" },
                    { 44, null, null, "ConfirmPassword", null, null, "تأكيد كلمة المرور", "Confirm Password" },
                    { 45, null, null, "Back", null, null, "عودة", "Back" }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 2, 28, 17, 9, 17, 58, DateTimeKind.Unspecified).AddTicks(8907), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 2, 28, 17, 9, 17, 60, DateTimeKind.Unspecified).AddTicks(2672), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 2, 28, 17, 9, 17, 60, DateTimeKind.Unspecified).AddTicks(2687), new TimeSpan(0, 2, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 45);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 2, 20, 21, 50, 26, 239, DateTimeKind.Unspecified).AddTicks(5866), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 2, 20, 21, 50, 26, 240, DateTimeKind.Unspecified).AddTicks(9591), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 2, 20, 21, 50, 26, 240, DateTimeKind.Unspecified).AddTicks(9606), new TimeSpan(0, 2, 0, 0, 0)));
        }
    }
}
