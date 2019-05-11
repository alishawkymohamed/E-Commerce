using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbContexts.Migrations
{
    public partial class addLocalization1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsRealPhoto",
                table: "Photos",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsMainPhoto",
                table: "Photos",
                nullable: true,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCommercialPhoto",
                table: "Photos",
                nullable: true,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Photos",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Localizations",
                columns: new[] { "LocalizationId", "CreatedBy", "CreatedOn", "Key", "UpdatedBy", "UpdatedOn", "ValueAr", "ValueEn" },
                values: new object[,]
                {
                    { 50, null, null, "Price", null, null, "السعر", "Price" },
                    { 51, null, null, "Deduction", null, null, "التخفيض", "Deduction" },
                    { 52, null, null, "Photo", null, null, "الصورة", "Photo" },
                    { 53, null, null, "RealPhotos", null, null, "الصور الحقيقية", "Real Photos" },
                    { 54, null, null, "MainPhoto", null, null, "الصورة الرئيسية", "Main Photo" },
                    { 55, null, null, "CommercialPhotos", null, null, "الصور التسويقية", "Commercial Photo" }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 5, 9, 21, 48, 30, 516, DateTimeKind.Unspecified).AddTicks(5210), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 5, 9, 21, 48, 30, 518, DateTimeKind.Unspecified).AddTicks(3125), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 5, 9, 21, 48, 30, 518, DateTimeKind.Unspecified).AddTicks(3137), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.CreateIndex(
                name: "IX_Photos_Path",
                table: "Photos",
                column: "Path",
                unique: true,
                filter: "[Path] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Photos_Path",
                table: "Photos");

            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Localizations",
                keyColumn: "LocalizationId",
                keyValue: 55);

            migrationBuilder.DropColumn(
                name: "IsCommercialPhoto",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "Photos");

            migrationBuilder.AlterColumn<bool>(
                name: "IsRealPhoto",
                table: "Photos",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true,
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsMainPhoto",
                table: "Photos",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true,
                oldDefaultValue: false);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 5, 9, 0, 42, 23, 643, DateTimeKind.Unspecified).AddTicks(1379), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 5, 9, 0, 42, 23, 644, DateTimeKind.Unspecified).AddTicks(9235), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 5, 9, 0, 42, 23, 644, DateTimeKind.Unspecified).AddTicks(9247), new TimeSpan(0, 2, 0, 0, 0)));
        }
    }
}
