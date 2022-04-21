using Microsoft.EntityFrameworkCore.Migrations;
using System;



namespace SiteExpensesManagement.App.DataAccess.EntityFramework.Migrations
{
    public partial class payments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillPayments",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    UserId1 = table.Column<string>(nullable: true),
                    BillId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillPayments_Bills_BillId",
                        column: x => x.BillId,
                        principalSchema: "dbo",
                        principalTable: "Bills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BillPayments_Users_UserId1",
                        column: x => x.UserId1,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DuesPayments",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    UserId1 = table.Column<string>(nullable: true),
                    DuesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuesPayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuesPayments_Dues_DuesId",
                        column: x => x.DuesId,
                        principalSchema: "dbo",
                        principalTable: "Dues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DuesPayments_Users_UserId1",
                        column: x => x.UserId1,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillPayments_BillId",
                schema: "Identity",
                table: "BillPayments",
                column: "BillId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BillPayments_UserId1",
                schema: "Identity",
                table: "BillPayments",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_DuesPayments_DuesId",
                schema: "Identity",
                table: "DuesPayments",
                column: "DuesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DuesPayments_UserId1",
                schema: "Identity",
                table: "DuesPayments",
                column: "UserId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillPayments",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "DuesPayments",
                schema: "Identity");
        }
    }
}
