using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbContexts.Migrations
{
    public partial class EditUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnabledSince",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "EnabledUntil",
                table: "UserRoles");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 3, 11, 18, 49, 12, 614, DateTimeKind.Unspecified).AddTicks(7023), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 3, 11, 18, 49, 12, 616, DateTimeKind.Unspecified).AddTicks(1728), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 3, 11, 18, 49, 12, 616, DateTimeKind.Unspecified).AddTicks(1743), new TimeSpan(0, 2, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "EnabledSince",
                table: "UserRoles",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "EnabledUntil",
                table: "UserRoles",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 3, 11, 17, 40, 20, 771, DateTimeKind.Unspecified).AddTicks(7045), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 3, 11, 17, 40, 20, 773, DateTimeKind.Unspecified).AddTicks(5087), new TimeSpan(0, 2, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTimeOffset(new DateTime(2019, 3, 11, 17, 40, 20, 773, DateTimeKind.Unspecified).AddTicks(5106), new TimeSpan(0, 2, 0, 0, 0)));
        }
    }
}
