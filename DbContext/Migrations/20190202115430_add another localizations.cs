using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbContexts.Migrations
{
    public partial class addanotherlocalizations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 10);

            migrationBuilder.InsertData(
                table: "Localizations",
                columns: new[] { "LocalizationId", "CreatedBy", "CreatedOn", "Key", "UpdatedBy", "UpdatedOn", "ValueAr", "ValueEn" },
                values: new object[,]
                {
                    { 11, null, null, "InvalidCredentials", null, null, "خطأ في إسم المستخدم أو كلمة المرور", "Invalid Username Or Password" },
                    { 12, null, null, "UserName", null, null, "إسم المستخدم", "Username" },
                    { 13, null, null, "Password", null, null, "كلمة المرور", "Password" },
                    { 14, null, null, "Login", null, null, "دخول", "Login" },
                    { 15, null, null, "ChangeLang", null, null, "تغيير اللغة", "Change Language" },
                    { 16, null, null, "AccountIsDisabled", null, null, "الحساب متوقف من قبل الإدارة", "Account is disabled by administration" },
                    { 17, null, null, "CategoryNameAr", null, null, "الإسم التصنيف بالعربي", "Category Arabic Name" },
                    { 18, null, null, "CategoryNameEn", null, null, "الإسم التصنيف بالإنجليزي", "Category English Name" },
                    { 19, null, null, "CategoryCode", null, null, "كود التصنيف", "Category Code" },
                    { 20, null, null, "Categories", null, null, "التصنيفات", "Categories" }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 2, 2, 13, 54, 30, 144, DateTimeKind.Unspecified).AddTicks(9468), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 2, 2, 13, 54, 30, 146, DateTimeKind.Unspecified).AddTicks(6912), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 2, 2, 13, 54, 30, 146, DateTimeKind.Unspecified).AddTicks(6923), new TimeSpan(0, 2, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 20);

            migrationBuilder.InsertData(
                table: "Localizations",
                columns: new[] { "LocalizationId", "CreatedBy", "CreatedOn", "Key", "UpdatedBy", "UpdatedOn", "ValueAr", "ValueEn" },
                values: new object[,]
                {
                    { 1, null, null, "InvalidCredentials", null, null, "خطأ في إسم المستخدم أو كلمة المرور", "Invalid Username Or Password" },
                    { 2, null, null, "UserName", null, null, "إسم المستخدم", "Username" },
                    { 3, null, null, "Password", null, null, "كلمة المرور", "Password" },
                    { 4, null, null, "Login", null, null, "دخول", "Login" },
                    { 5, null, null, "ChangeLang", null, null, "تغيير اللغة", "Change Language" },
                    { 6, null, null, "AccountIsDisabled", null, null, "الحساب متوقف من قبل الإدارة", "Account is disabled by administration" },
                    { 7, null, null, "CategoryNameAr", null, null, "الإسم التصنيف بالعربي", "Category Arabic Name" },
                    { 8, null, null, "CategoryNameEn", null, null, "الإسم التصنيف بالإنجليزي", "Category English Name" },
                    { 9, null, null, "CategoryCode", null, null, "كود التصنيف", "Category Code" },
                    { 10, null, null, "Categories", null, null, "التصنيفات", "Categories" }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 2, 2, 13, 51, 49, 167, DateTimeKind.Unspecified).AddTicks(3280), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 2, 2, 13, 51, 49, 169, DateTimeKind.Unspecified).AddTicks(2078), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 2, 2, 13, 51, 49, 169, DateTimeKind.Unspecified).AddTicks(2091), new TimeSpan(0, 2, 0, 0, 0)));
        }
    }
}
