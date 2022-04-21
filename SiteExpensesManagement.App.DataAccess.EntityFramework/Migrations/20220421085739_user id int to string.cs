using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteExpensesManagement.App.DataAccess.EntityFramework.Migrations
{
    public partial class useridinttostring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillPayments_Users_UserId1",
                schema: "Identity",
                table: "BillPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_DuesPayments_Users_UserId1",
                schema: "Identity",
                table: "DuesPayments");

            migrationBuilder.DropIndex(
                name: "IX_DuesPayments_UserId1",
                schema: "Identity",
                table: "DuesPayments");

            migrationBuilder.DropIndex(
                name: "IX_BillPayments_UserId1",
                schema: "Identity",
                table: "BillPayments");

            migrationBuilder.DropColumn(
                name: "UserId1",
                schema: "Identity",
                table: "DuesPayments");

            migrationBuilder.DropColumn(
                name: "UserId1",
                schema: "Identity",
                table: "BillPayments");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "Identity",
                table: "DuesPayments",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "Identity",
                table: "BillPayments",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_DuesPayments_UserId",
                schema: "Identity",
                table: "DuesPayments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BillPayments_UserId",
                schema: "Identity",
                table: "BillPayments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BillPayments_Users_UserId",
                schema: "Identity",
                table: "BillPayments",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DuesPayments_Users_UserId",
                schema: "Identity",
                table: "DuesPayments",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BillPayments_Users_UserId",
                schema: "Identity",
                table: "BillPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_DuesPayments_Users_UserId",
                schema: "Identity",
                table: "DuesPayments");

            migrationBuilder.DropIndex(
                name: "IX_DuesPayments_UserId",
                schema: "Identity",
                table: "DuesPayments");

            migrationBuilder.DropIndex(
                name: "IX_BillPayments_UserId",
                schema: "Identity",
                table: "BillPayments");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "Identity",
                table: "DuesPayments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                schema: "Identity",
                table: "DuesPayments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "Identity",
                table: "BillPayments",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                schema: "Identity",
                table: "BillPayments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DuesPayments_UserId1",
                schema: "Identity",
                table: "DuesPayments",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_BillPayments_UserId1",
                schema: "Identity",
                table: "BillPayments",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BillPayments_Users_UserId1",
                schema: "Identity",
                table: "BillPayments",
                column: "UserId1",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DuesPayments_Users_UserId1",
                schema: "Identity",
                table: "DuesPayments",
                column: "UserId1",
                principalSchema: "Identity",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
