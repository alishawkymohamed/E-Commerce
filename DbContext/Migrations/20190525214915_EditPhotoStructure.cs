using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbContexts.Migrations
{
    public partial class EditPhotoStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoName",
                table: "Photos");

            migrationBuilder.RenameColumn(
                name: "PhotoNameEn",
                table: "Photos",
                newName: "UniqueName");

            migrationBuilder.RenameColumn(
                name: "PhotoNameAr",
                table: "Photos",
                newName: "Base64String");

            migrationBuilder.AlterColumn<string>(
                name: "UniqueName",
                table: "Photos",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Photos_UniqueName",
                table: "Photos",
                column: "UniqueName",
                unique: true,
                filter: "[UniqueName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Photos_UniqueName",
                table: "Photos");

            migrationBuilder.RenameColumn(
                name: "UniqueName",
                table: "Photos",
                newName: "PhotoNameEn");

            migrationBuilder.RenameColumn(
                name: "Base64String",
                table: "Photos",
                newName: "PhotoNameAr");

            migrationBuilder.AlterColumn<string>(
                name: "PhotoNameEn",
                table: "Photos",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoName",
                table: "Photos",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 5, 11, 9, 48, 4, 419, DateTimeKind.Unspecified).AddTicks(8071), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 5, 11, 9, 48, 4, 421, DateTimeKind.Unspecified).AddTicks(4644), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 5, 11, 9, 48, 4, 421, DateTimeKind.Unspecified).AddTicks(4656), new TimeSpan(0, 2, 0, 0, 0)));
        }
    }
}
