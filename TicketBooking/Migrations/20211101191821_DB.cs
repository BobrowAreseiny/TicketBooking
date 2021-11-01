using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketBooking.Migrations
{
    public partial class DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UseraId",
                table: "Accounts",
                newName: "UseraID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UseraID",
                table: "Accounts",
                newName: "UseraId");
        }
    }
}
