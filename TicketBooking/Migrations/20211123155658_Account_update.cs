using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketBooking.Migrations
{
    public partial class Account_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Roles_RoleId",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Accounts",
                newName: "RoleID");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_RoleId",
                table: "Accounts",
                newName: "IX_Accounts_RoleID");

            migrationBuilder.AlterColumn<int>(
                name: "RoleID",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Roles_RoleID",
                table: "Accounts",
                column: "RoleID",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Roles_RoleID",
                table: "Accounts");

            migrationBuilder.RenameColumn(
                name: "RoleID",
                table: "Accounts",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_RoleID",
                table: "Accounts",
                newName: "IX_Accounts_RoleId");

            migrationBuilder.AlterColumn<int>(
                name: "RoleId",
                table: "Accounts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Roles_RoleId",
                table: "Accounts",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
