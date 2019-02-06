using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbContexts.Migrations
{
    public partial class MoreandMoreLocalized : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 26,
                column: "ValueAr",
                value: "تعديل");

            migrationBuilder.InsertData(
                table: "Localizations",
                columns: new[] { "LocalizationId", "CreatedBy", "CreatedOn", "Key", "UpdatedBy", "UpdatedOn", "ValueAr", "ValueEn" },
                values: new object[,]
                {
                    { 1, null, null, "Agree", null, null, "موافق", "Ok" },
                    { 2, null, null, "Reject", null, null, "إلغاء", "Cancel" },
                    { 3, null, null, "Close", null, null, "إغلاق", "Close" }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 2, 6, 19, 46, 33, 717, DateTimeKind.Unspecified).AddTicks(8947), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 2, 6, 19, 46, 33, 719, DateTimeKind.Unspecified).AddTicks(2488), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 2, 6, 19, 46, 33, 719, DateTimeKind.Unspecified).AddTicks(2503), new TimeSpan(0, 2, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.UpdateData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 26,
                column: "ValueAr",
                value: "ـعديل");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 2, 6, 19, 39, 41, 218, DateTimeKind.Unspecified).AddTicks(2661), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 2, 6, 19, 39, 41, 219, DateTimeKind.Unspecified).AddTicks(8542), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 2, 6, 19, 39, 41, 219, DateTimeKind.Unspecified).AddTicks(8561), new TimeSpan(0, 2, 0, 0, 0)));
        }
    }
}
