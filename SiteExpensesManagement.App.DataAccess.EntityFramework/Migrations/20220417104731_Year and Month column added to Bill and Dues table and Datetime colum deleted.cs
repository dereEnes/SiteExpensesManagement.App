using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteExpensesManagement.App.DataAccess.EntityFramework.Migrations
{
    public partial class YearandMonthcolumnaddedtoBillandDuestableandDatetimecolumdeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DuesDate",
                schema: "Identity",
                table: "Dues");

            migrationBuilder.DropColumn(
                name: "BillDate",
                schema: "Identity",
                table: "Bills");

            migrationBuilder.RenameColumn(
                name: "Amount",
                schema: "Identity",
                table: "Dues",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "Amount",
                schema: "Identity",
                table: "Bills",
                newName: "Price");

            migrationBuilder.AddColumn<byte>(
                name: "Month",
                schema: "Identity",
                table: "Dues",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<short>(
                name: "Year",
                schema: "Identity",
                table: "Dues",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<byte>(
                name: "Month",
                schema: "Identity",
                table: "Bills",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<short>(
                name: "Year",
                schema: "Identity",
                table: "Bills",
                nullable: false,
                defaultValue: (short)0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Month",
                schema: "Identity",
                table: "Dues");

            migrationBuilder.DropColumn(
                name: "Year",
                schema: "Identity",
                table: "Dues");

            migrationBuilder.DropColumn(
                name: "Month",
                schema: "Identity",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "Year",
                schema: "Identity",
                table: "Bills");

            migrationBuilder.RenameColumn(
                name: "Price",
                schema: "Identity",
                table: "Dues",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "Price",
                schema: "Identity",
                table: "Bills",
                newName: "Amount");

            migrationBuilder.AddColumn<DateTime>(
                name: "DuesDate",
                schema: "Identity",
                table: "Dues",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "BillDate",
                schema: "Identity",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
