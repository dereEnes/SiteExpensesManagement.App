using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteExpensesManagement.App.DataAccess.EntityFramework.Migrations
{
    public partial class billandduesdefaultvalueremoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsPayed",
                schema: "dbo",
                table: "Dues",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsPayed",
                schema: "dbo",
                table: "Bills",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsPayed",
                schema: "dbo",
                table: "Dues",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<bool>(
                name: "IsPayed",
                schema: "dbo",
                table: "Bills",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool));
        }
    }
}
