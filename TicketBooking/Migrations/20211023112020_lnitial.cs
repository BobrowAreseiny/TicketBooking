using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketBooking.Migrations
{
    public partial class lnitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Concerts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExectorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfConcert = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CountOfTicket = table.Column<int>(type: "int", nullable: false),
                    LocationOfConcert = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concerts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfConcerts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfConcert = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeOfThisConcert = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeOfVoice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Healiner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Way = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Composer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgeLimit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcertID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfConcerts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TypeOfConcerts_Concerts_ConcertID",
                        column: x => x.ConcertID,
                        principalTable: "Concerts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConcertID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tickets_Concerts_ConcertID",
                        column: x => x.ConcertID,
                        principalTable: "Concerts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ConcertID",
                table: "Tickets",
                column: "ConcertID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserID",
                table: "Tickets",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_TypeOfConcerts_ConcertID",
                table: "TypeOfConcerts",
                column: "ConcertID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "TypeOfConcerts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Concerts");
        }
    }
}
