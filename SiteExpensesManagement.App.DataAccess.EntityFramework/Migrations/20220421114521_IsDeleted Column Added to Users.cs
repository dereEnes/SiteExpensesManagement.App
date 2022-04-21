using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteExpensesManagement.App.DataAccess.EntityFramework.Migrations
{
    public partial class IsDeletedColumnAddedtoUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Identity",
                table: "Users",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Identity",
                table: "Users");
        }
    }
}
