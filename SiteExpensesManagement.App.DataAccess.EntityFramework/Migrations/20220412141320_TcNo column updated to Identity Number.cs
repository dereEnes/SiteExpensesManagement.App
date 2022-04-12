using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteExpensesManagement.App.DataAccess.EntityFramework.Migrations
{
    public partial class TcNocolumnupdatedtoIdentityNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TcNo",
                schema: "Identity",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "IdentityNumber",
                schema: "Identity",
                table: "Users",
                maxLength: 11,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "Dues",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 12, 17, 13, 20, 552, DateTimeKind.Local).AddTicks(2854),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 11, 19, 33, 18, 584, DateTimeKind.Local).AddTicks(9806));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "Cars",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 12, 17, 13, 20, 551, DateTimeKind.Local).AddTicks(1263),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 11, 19, 33, 18, 583, DateTimeKind.Local).AddTicks(9127));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "Bills",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 12, 17, 13, 20, 550, DateTimeKind.Local).AddTicks(951),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 11, 19, 33, 18, 583, DateTimeKind.Local).AddTicks(1384));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "Beds",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 12, 17, 13, 20, 552, DateTimeKind.Local).AddTicks(9639),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 11, 19, 33, 18, 585, DateTimeKind.Local).AddTicks(5778));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "Apartments",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 12, 17, 13, 20, 548, DateTimeKind.Local).AddTicks(4712),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 11, 19, 33, 18, 581, DateTimeKind.Local).AddTicks(6392));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentityNumber",
                schema: "Identity",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "TcNo",
                schema: "Identity",
                table: "Users",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "Dues",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 11, 19, 33, 18, 584, DateTimeKind.Local).AddTicks(9806),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 4, 12, 17, 13, 20, 552, DateTimeKind.Local).AddTicks(2854));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "Cars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 11, 19, 33, 18, 583, DateTimeKind.Local).AddTicks(9127),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 4, 12, 17, 13, 20, 551, DateTimeKind.Local).AddTicks(1263));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 11, 19, 33, 18, 583, DateTimeKind.Local).AddTicks(1384),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 4, 12, 17, 13, 20, 550, DateTimeKind.Local).AddTicks(951));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "Beds",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 11, 19, 33, 18, 585, DateTimeKind.Local).AddTicks(5778),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 4, 12, 17, 13, 20, 552, DateTimeKind.Local).AddTicks(9639));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "Apartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 11, 19, 33, 18, 581, DateTimeKind.Local).AddTicks(6392),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 4, 12, 17, 13, 20, 548, DateTimeKind.Local).AddTicks(4712));
        }
    }
}
