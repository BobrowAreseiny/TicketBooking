using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketBooking.Migrations
{
    public partial class CashBox : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CashBoxID",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CashBoxID",
                table: "Tickets");
        }
    }
}
