using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteExpensesManagement.App.DataAccess.EntityFramework.Migrations
{
    public partial class Messagestableupdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "hasRead",
                schema: "Identity",
                table: "Messages",
                newName: "HasRead");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                schema: "Identity",
                table: "Messages",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Header",
                schema: "Identity",
                table: "Messages",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "Identity",
                table: "Cars",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "Cars",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 13, 15, 0, 23, 954, DateTimeKind.Local).AddTicks(6063));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                schema: "Identity",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "Header",
                schema: "Identity",
                table: "Messages");

            migrationBuilder.RenameColumn(
                name: "HasRead",
                schema: "Identity",
                table: "Messages",
                newName: "hasRead");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "Identity",
                table: "Cars",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "Cars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 13, 15, 0, 23, 954, DateTimeKind.Local).AddTicks(6063),
                oldClrType: typeof(DateTime));
        }
    }
}
