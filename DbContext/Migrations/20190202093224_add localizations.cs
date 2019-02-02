using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbContexts.Migrations
{
    public partial class addlocalizations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Categories_Code",
                table: "Categories");

            migrationBuilder.RenameColumn(
                name: "Code",
                table: "Categories",
                newName: "CategoryCode");

            migrationBuilder.AddColumn<decimal>(
                name: "Deduction",
                table: "Products",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Products",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 7,
                columns: new[] { "Key", "ValueAr", "ValueEn" },
                values: new object[] { "CategoryNameAr", "الإسم التصنيف بالعربي", "Category Arabic Name" });

            migrationBuilder.InsertData(
                table: "Localizations",
                columns: new[] { "LocalizationId", "CreatedBy", "CreatedOn", "Key", "UpdatedBy", "UpdatedOn", "ValueAr", "ValueEn" },
                values: new object[,]
                {
                    { 8, null, null, "CategoryNameEn", null, null, "الإسم التصنيف بالإنجليزي", "Category English Name" },
                    { 9, null, null, "CategoryCode", null, null, "كود التصنيف", "Category Code" }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 2, 2, 11, 32, 24, 99, DateTimeKind.Unspecified).AddTicks(4944), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 2, 2, 11, 32, 24, 101, DateTimeKind.Unspecified).AddTicks(3914), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 2, 2, 11, 32, 24, 101, DateTimeKind.Unspecified).AddTicks(3926), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryCode",
                table: "Categories",
                column: "CategoryCode",
                unique: true,
                filter: "[CategoryCode] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Categories_CategoryCode",
                table: "Categories");

            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 9);

            migrationBuilder.DropColumn(
                name: "Deduction",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CategoryCode",
                table: "Categories",
                newName: "Code");

            migrationBuilder.UpdateData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 7,
                columns: new[] { "Key", "ValueAr", "ValueEn" },
                values: new object[] { "AccountIsDisabledSince", "الحساب متوقف منذ  {0:yyyy-MM-dd}", "Account is disabled since {0:dd-MM-yyyy}" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 1, 23, 5, 27, 32, 697, DateTimeKind.Unspecified).AddTicks(8457), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 1, 23, 5, 27, 32, 699, DateTimeKind.Unspecified).AddTicks(7142), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 1, 23, 5, 27, 32, 699, DateTimeKind.Unspecified).AddTicks(7153), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Code",
                table: "Categories",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");
        }
    }
}
