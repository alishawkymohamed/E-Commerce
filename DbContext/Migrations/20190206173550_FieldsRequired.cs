using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbContexts.Migrations
{
    public partial class FieldsRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SubCategories_Code",
                table: "SubCategories");

            migrationBuilder.DropIndex(
                name: "IX_SubCategories_SubCategoryNameAr",
                table: "SubCategories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CategoryCode",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CategoryNameAr",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "SubCategories");

            migrationBuilder.AlterColumn<string>(
                name: "SubCategoryNameAr",
                table: "SubCategories",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubCategoryCode",
                table: "SubCategories",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "CategoryNameAr",
                table: "Categories",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryCode",
                table: "Categories",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 2, 6, 19, 35, 49, 309, DateTimeKind.Unspecified).AddTicks(3972), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 2, 6, 19, 35, 49, 311, DateTimeKind.Unspecified).AddTicks(4853), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 2, 6, 19, 35, 49, 311, DateTimeKind.Unspecified).AddTicks(4876), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_SubCategoryCode",
                table: "SubCategories",
                column: "SubCategoryCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_SubCategoryNameAr",
                table: "SubCategories",
                column: "SubCategoryNameAr",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryCode",
                table: "Categories",
                column: "CategoryCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryNameAr",
                table: "Categories",
                column: "CategoryNameAr",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SubCategories_SubCategoryCode",
                table: "SubCategories");

            migrationBuilder.DropIndex(
                name: "IX_SubCategories_SubCategoryNameAr",
                table: "SubCategories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CategoryCode",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_CategoryNameAr",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "SubCategoryCode",
                table: "SubCategories");

            migrationBuilder.AlterColumn<string>(
                name: "SubCategoryNameAr",
                table: "SubCategories",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "SubCategories",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CategoryNameAr",
                table: "Categories",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CategoryCode",
                table: "Categories",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 2, 6, 19, 29, 30, 151, DateTimeKind.Unspecified).AddTicks(5807), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 2, 6, 19, 29, 30, 152, DateTimeKind.Unspecified).AddTicks(8776), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 2, 6, 19, 29, 30, 152, DateTimeKind.Unspecified).AddTicks(8792), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_Code",
                table: "SubCategories",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_SubCategoryNameAr",
                table: "SubCategories",
                column: "SubCategoryNameAr",
                unique: true,
                filter: "[SubCategoryNameAr] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryCode",
                table: "Categories",
                column: "CategoryCode",
                unique: true,
                filter: "[CategoryCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryNameAr",
                table: "Categories",
                column: "CategoryNameAr",
                unique: true,
                filter: "[CategoryNameAr] IS NOT NULL");
        }
    }
}
