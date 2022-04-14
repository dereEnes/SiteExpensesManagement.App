using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteExpensesManagement.App.DataAccess.EntityFramework.Migrations
{
    public partial class IsEmptyhasReaddefaultvalueremoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "RoomTypes",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 13, 13, 24, 0, 400, DateTimeKind.Local).AddTicks(9142));

            migrationBuilder.AlterColumn<bool>(
                name: "hasRead",
                schema: "Identity",
                table: "Messages",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "Cars",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 13, 15, 0, 23, 954, DateTimeKind.Local).AddTicks(6063),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 13, 13, 24, 0, 398, DateTimeKind.Local).AddTicks(6899));

            migrationBuilder.AlterColumn<bool>(
                name: "IsEmpty",
                schema: "Identity",
                table: "Apartments",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "RoomTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 13, 13, 24, 0, 400, DateTimeKind.Local).AddTicks(9142),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<bool>(
                name: "hasRead",
                schema: "Identity",
                table: "Messages",
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
                defaultValue: new DateTime(2022, 4, 13, 13, 24, 0, 398, DateTimeKind.Local).AddTicks(6899),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 4, 13, 15, 0, 23, 954, DateTimeKind.Local).AddTicks(6063));

            migrationBuilder.AlterColumn<bool>(
                name: "IsEmpty",
                schema: "Identity",
                table: "Apartments",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool));
        }
    }
}
