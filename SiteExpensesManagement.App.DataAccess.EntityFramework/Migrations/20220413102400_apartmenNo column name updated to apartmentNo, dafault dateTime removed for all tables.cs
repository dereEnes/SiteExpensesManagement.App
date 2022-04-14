using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteExpensesManagement.App.DataAccess.EntityFramework.Migrations
{
    public partial class apartmenNocolumnnameupdatedtoapartmentNodafaultdateTimeremovedforalltables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApartmenNo",
                schema: "Identity",
                table: "Apartments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "RoomTypes",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 13, 13, 24, 0, 400, DateTimeKind.Local).AddTicks(9142),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 12, 20, 58, 33, 675, DateTimeKind.Local).AddTicks(3475));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "Messages",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 12, 20, 58, 33, 676, DateTimeKind.Local).AddTicks(3981));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "Dues",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 12, 20, 58, 33, 674, DateTimeKind.Local).AddTicks(6921));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "Cars",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 13, 13, 24, 0, 398, DateTimeKind.Local).AddTicks(6899),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 12, 20, 58, 33, 673, DateTimeKind.Local).AddTicks(2473));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "Bills",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 12, 20, 58, 33, 672, DateTimeKind.Local).AddTicks(1856));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "Apartments",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 12, 20, 58, 33, 670, DateTimeKind.Local).AddTicks(5921));

            migrationBuilder.AddColumn<int>(
                name: "ApartmentNo",
                schema: "Identity",
                table: "Apartments",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApartmentNo",
                schema: "Identity",
                table: "Apartments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "RoomTypes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 12, 20, 58, 33, 675, DateTimeKind.Local).AddTicks(3475),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 4, 13, 13, 24, 0, 400, DateTimeKind.Local).AddTicks(9142));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "Messages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 12, 20, 58, 33, 676, DateTimeKind.Local).AddTicks(3981),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "Dues",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 12, 20, 58, 33, 674, DateTimeKind.Local).AddTicks(6921),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "Cars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 12, 20, 58, 33, 673, DateTimeKind.Local).AddTicks(2473),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 4, 13, 13, 24, 0, 398, DateTimeKind.Local).AddTicks(6899));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 12, 20, 58, 33, 672, DateTimeKind.Local).AddTicks(1856),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "Apartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 12, 20, 58, 33, 670, DateTimeKind.Local).AddTicks(5921),
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<int>(
                name: "ApartmenNo",
                schema: "Identity",
                table: "Apartments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
