using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteExpensesManagement.App.DataAccess.EntityFramework.Migrations
{
    public partial class changingdefaultschema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "RoomTypes",
                schema: "Identity",
                newName: "RoomTypes",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Messages",
                schema: "Identity",
                newName: "Messages",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Dues",
                schema: "Identity",
                newName: "Dues",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Cars",
                schema: "Identity",
                newName: "Cars",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Bills",
                schema: "Identity",
                newName: "Bills",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Apartments",
                schema: "Identity",
                newName: "Apartments",
                newSchema: "dbo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "RoomTypes",
                schema: "dbo",
                newName: "RoomTypes",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Messages",
                schema: "dbo",
                newName: "Messages",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Dues",
                schema: "dbo",
                newName: "Dues",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Cars",
                schema: "dbo",
                newName: "Cars",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Bills",
                schema: "dbo",
                newName: "Bills",
                newSchema: "Identity");

            migrationBuilder.RenameTable(
                name: "Apartments",
                schema: "dbo",
                newName: "Apartments",
                newSchema: "Identity");
        }
    }
}
