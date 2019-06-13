using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbContexts.Migrations
{
    public partial class AddLocalization10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Localizations",
                columns: new[] { "LocalizationId", "CreatedBy", "CreatedOn", "Key", "UpdatedBy", "UpdatedOn", "ValueAr", "ValueEn" },
                values: new object[] { 61, null, null, "All", null, null, "الكل", "All" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 6, 13, 2, 15, 24, 981, DateTimeKind.Unspecified).AddTicks(8526), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 6, 13, 2, 15, 24, 983, DateTimeKind.Unspecified).AddTicks(5404), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 6, 13, 2, 15, 24, 983, DateTimeKind.Unspecified).AddTicks(5415), new TimeSpan(0, 2, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 61);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 5, 31, 6, 37, 51, 492, DateTimeKind.Unspecified).AddTicks(9910), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 5, 31, 6, 37, 51, 494, DateTimeKind.Unspecified).AddTicks(6845), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 5, 31, 6, 37, 51, 494, DateTimeKind.Unspecified).AddTicks(6855), new TimeSpan(0, 2, 0, 0, 0)));
        }
    }
}
