using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbContexts.Migrations
{
    public partial class anotherNewLocalization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Localizations",
                columns: new[] { "LocalizationId", "CreatedBy", "CreatedOn", "Key", "UpdatedBy", "UpdatedOn", "ValueAr", "ValueEn" },
                values: new object[] { 33, null, null, "SubCategory", null, null, "تصنيف فرعي", "Sub Category" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 33);

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
    }
}
