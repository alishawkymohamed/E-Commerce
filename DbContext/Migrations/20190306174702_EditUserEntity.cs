using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbContexts.Migrations
{
    public partial class EditUserEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnabledUntil",
                table: "Users");

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "Users",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 11,
                column: "ValueAr",
                value: "خطأ في إسم المستخدم أو كلمة السر");

            migrationBuilder.UpdateData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 13,
                column: "ValueAr",
                value: "كلمة السر");

            migrationBuilder.UpdateData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 37,
                column: "ValueEn",
                value: "Sign up new account");

            migrationBuilder.UpdateData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 39,
                column: "ValueEn",
                value: "Sign in with Facebook");

            migrationBuilder.UpdateData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 40,
                column: "ValueEn",
                value: "Sign up with Facebook");

            migrationBuilder.UpdateData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 41,
                column: "ValueEn",
                value: "Sign in With Gmail");

            migrationBuilder.UpdateData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 42,
                column: "ValueEn",
                value: "Sign up with Gmail");

            migrationBuilder.UpdateData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 44,
                column: "ValueAr",
                value: "تأكيد كلمة السر");

            migrationBuilder.InsertData(
                table: "Localizations",
                columns: new[] { "LocalizationId", "CreatedBy", "CreatedOn", "Key", "UpdatedBy", "UpdatedOn", "ValueAr", "ValueEn" },
                values: new object[] { 46, null, null, "WaitApprove", null, null, "تم إرسال طلب إنضمامك للموقع للمدير المسئول و سيتم إخطارك عن الموافقة علي طلبك", "Your request to join our website is sent to admin and you'll be notified after his approval" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 3, 6, 19, 47, 1, 671, DateTimeKind.Unspecified).AddTicks(9353), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 3, 6, 19, 47, 1, 673, DateTimeKind.Unspecified).AddTicks(3718), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 3, 6, 19, 47, 1, 673, DateTimeKind.Unspecified).AddTicks(3733), new TimeSpan(0, 2, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 46);

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "Users");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "EnabledUntil",
                table: "Users",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 11,
                column: "ValueAr",
                value: "خطأ في إسم المستخدم أو كلمة المرور");

            migrationBuilder.UpdateData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 13,
                column: "ValueAr",
                value: "كلمة المرور");

            migrationBuilder.UpdateData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 37,
                column: "ValueEn",
                value: "Sign Up New Account");

            migrationBuilder.UpdateData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 39,
                column: "ValueEn",
                value: "SignIn With Facebook");

            migrationBuilder.UpdateData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 40,
                column: "ValueEn",
                value: "Sign Up With Facebook");

            migrationBuilder.UpdateData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 41,
                column: "ValueEn",
                value: "SignIn With Gmail");

            migrationBuilder.UpdateData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 42,
                column: "ValueEn",
                value: "Sign Up With Gmail");

            migrationBuilder.UpdateData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 44,
                column: "ValueAr",
                value: "تأكيد كلمة المرور");

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
    }
}
