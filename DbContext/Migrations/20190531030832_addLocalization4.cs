using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbContexts.Migrations
{
    public partial class addLocalization4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Localizations",
                columns: new[] { "LocalizationId", "CreatedBy", "CreatedOn", "Key", "UpdatedBy", "UpdatedOn", "ValueAr", "ValueEn" },
                values: new object[] { 60, null, null, "Max5Photos", null, null, "يمكن رفع 5 صور بحد أقصي", "Max 5 Photos" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 5, 31, 5, 8, 31, 276, DateTimeKind.Unspecified).AddTicks(8840), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 5, 31, 5, 8, 31, 279, DateTimeKind.Unspecified).AddTicks(2193), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 5, 31, 5, 8, 31, 279, DateTimeKind.Unspecified).AddTicks(2218), new TimeSpan(0, 2, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 60);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 5, 25, 23, 49, 14, 497, DateTimeKind.Unspecified).AddTicks(2518), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 5, 25, 23, 49, 14, 499, DateTimeKind.Unspecified).AddTicks(1401), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 5, 25, 23, 49, 14, 499, DateTimeKind.Unspecified).AddTicks(1419), new TimeSpan(0, 2, 0, 0, 0)));
        }
    }
}
