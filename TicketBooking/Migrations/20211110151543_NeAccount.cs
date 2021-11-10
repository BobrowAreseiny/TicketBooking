using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketBooking.Migrations
{
    public partial class NeAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsUserValid",
                table: "Accounts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUserValid",
                table: "Accounts");
        }
    }
}
