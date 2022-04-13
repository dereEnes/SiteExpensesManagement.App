using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteExpensesManagement.App.DataAccess.EntityFramework.Migrations
{
    public partial class MessagesTableadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Beds_RoomTypeId",
                schema: "Identity",
                table: "Apartments");

            migrationBuilder.DropTable(
                name: "Beds",
                schema: "Identity");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "Dues",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 12, 20, 58, 33, 674, DateTimeKind.Local).AddTicks(6921),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 12, 17, 13, 20, 552, DateTimeKind.Local).AddTicks(2854));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "Cars",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 12, 20, 58, 33, 673, DateTimeKind.Local).AddTicks(2473),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 12, 17, 13, 20, 551, DateTimeKind.Local).AddTicks(1263));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "Bills",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 12, 20, 58, 33, 672, DateTimeKind.Local).AddTicks(1856),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 12, 17, 13, 20, 550, DateTimeKind.Local).AddTicks(951));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "Apartments",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 12, 20, 58, 33, 670, DateTimeKind.Local).AddTicks(5921),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2022, 4, 12, 17, 13, 20, 548, DateTimeKind.Local).AddTicks(4712));

            migrationBuilder.CreateTable(
                name: "Messages",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2022, 4, 12, 20, 58, 33, 676, DateTimeKind.Local).AddTicks(3981)),
                    hasRead = table.Column<bool>(nullable: false, defaultValue: false),
                    SenderId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Users_SenderId",
                        column: x => x.SenderId,
                        principalSchema: "Identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2022, 4, 12, 20, 58, 33, 675, DateTimeKind.Local).AddTicks(3475)),
                    CountOfRooms = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                schema: "Identity",
                table: "Messages",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_RoomTypes_RoomTypeId",
                schema: "Identity",
                table: "Apartments",
                column: "RoomTypeId",
                principalSchema: "Identity",
                principalTable: "RoomTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_RoomTypes_RoomTypeId",
                schema: "Identity",
                table: "Apartments");

            migrationBuilder.DropTable(
                name: "Messages",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "RoomTypes",
                schema: "Identity");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "Dues",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 12, 17, 13, 20, 552, DateTimeKind.Local).AddTicks(2854),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 4, 12, 20, 58, 33, 674, DateTimeKind.Local).AddTicks(6921));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "Cars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 12, 17, 13, 20, 551, DateTimeKind.Local).AddTicks(1263),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 4, 12, 20, 58, 33, 673, DateTimeKind.Local).AddTicks(2473));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "Bills",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 12, 17, 13, 20, 550, DateTimeKind.Local).AddTicks(951),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 4, 12, 20, 58, 33, 672, DateTimeKind.Local).AddTicks(1856));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "Identity",
                table: "Apartments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2022, 4, 12, 17, 13, 20, 548, DateTimeKind.Local).AddTicks(4712),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2022, 4, 12, 20, 58, 33, 670, DateTimeKind.Local).AddTicks(5921));

            migrationBuilder.CreateTable(
                name: "Beds",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountOfRooms = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 4, 12, 17, 13, 20, 552, DateTimeKind.Local).AddTicks(9639)),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beds", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Beds_RoomTypeId",
                schema: "Identity",
                table: "Apartments",
                column: "RoomTypeId",
                principalSchema: "Identity",
                principalTable: "Beds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
