using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbContexts.Migrations
{
    public partial class EditLocalizations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 17,
                columns: new[] { "Key", "ValueAr", "ValueEn" },
                values: new object[] { "NameAr", "الإسم بالعربي", "Arabic Name" });

            migrationBuilder.UpdateData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 18,
                columns: new[] { "Key", "ValueAr", "ValueEn" },
                values: new object[] { "NameEn", "الإسم بالإنجليزي", "English Name" });

            migrationBuilder.UpdateData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 19,
                columns: new[] { "Key", "ValueAr", "ValueEn" },
                values: new object[] { "Code", "الكود", "Code" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 2, 7, 17, 46, 17, 524, DateTimeKind.Unspecified).AddTicks(590), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 2, 7, 17, 46, 17, 525, DateTimeKind.Unspecified).AddTicks(5994), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 2, 7, 17, 46, 17, 525, DateTimeKind.Unspecified).AddTicks(6005), new TimeSpan(0, 2, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 17,
                columns: new[] { "Key", "ValueAr", "ValueEn" },
                values: new object[] { "CategoryNameAr", "الإسم التصنيف بالعربي", "Category Arabic Name" });

            migrationBuilder.UpdateData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 18,
                columns: new[] { "Key", "ValueAr", "ValueEn" },
                values: new object[] { "CategoryNameEn", "الإسم التصنيف بالإنجليزي", "Category English Name" });

            migrationBuilder.UpdateData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 19,
                columns: new[] { "Key", "ValueAr", "ValueEn" },
                values: new object[] { "CategoryCode", "كود التصنيف", "Category Code" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 2, 6, 21, 1, 51, 545, DateTimeKind.Unspecified).AddTicks(3334), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 2, 6, 21, 1, 51, 546, DateTimeKind.Unspecified).AddTicks(6275), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 2, 6, 21, 1, 51, 546, DateTimeKind.Unspecified).AddTicks(6290), new TimeSpan(0, 2, 0, 0, 0)));
        }
    }
}
