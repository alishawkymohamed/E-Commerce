using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbContexts.Migrations
{
    public partial class anotherLocalizations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Localizations",
                columns: new[] { "LocalizationId", "CreatedBy", "CreatedOn", "Key", "UpdatedBy", "UpdatedOn", "ValueAr", "ValueEn" },
                values: new object[,]
                {
                    { 6, null, null, "Save", null, null, "حفظ", "Save" },
                    { 7, null, null, "SavedSuccess", null, null, "تم الحفظ بنجاح", "Saved Successfully" },
                    { 8, null, null, "ErrorOccured", null, null, "حدث خطأ ما", "Error Occured" }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 2, 7, 20, 37, 4, 201, DateTimeKind.Unspecified).AddTicks(1548), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 2, 7, 20, 37, 4, 202, DateTimeKind.Unspecified).AddTicks(5271), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 2, 7, 20, 37, 4, 202, DateTimeKind.Unspecified).AddTicks(5287), new TimeSpan(0, 2, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 2, 7, 17, 50, 22, 268, DateTimeKind.Unspecified).AddTicks(6911), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 2, 7, 17, 50, 22, 269, DateTimeKind.Unspecified).AddTicks(9767), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 2, 7, 17, 50, 22, 269, DateTimeKind.Unspecified).AddTicks(9782), new TimeSpan(0, 2, 0, 0, 0)));
        }
    }
}
