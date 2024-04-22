using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConcertBooking_WebApp.Migrations
{
    public partial class cbw : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "artistTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_artistTbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VenueTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeatCapacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VenueTbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "concertTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VenueId = table.Column<int>(type: "int", nullable: false),
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_concertTbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_concertTbl_artistTbl_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "artistTbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_concertTbl_VenueTbl_VenueId",
                        column: x => x.VenueId,
                        principalTable: "VenueTbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bookingTbl",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConcertId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookingTbl", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_bookingTbl_concertTbl_ConcertId",
                        column: x => x.ConcertId,
                        principalTable: "concertTbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ticketTbl",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatNumber = table.Column<int>(type: "int", nullable: false),
                    IsBooked = table.Column<bool>(type: "bit", nullable: false),
                    ConcertId = table.Column<int>(type: "int", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ticketTbl", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_ticketTbl_bookingTbl_BookingId",
                        column: x => x.BookingId,
                        principalTable: "bookingTbl",
                        principalColumn: "BookingId");
                    table.ForeignKey(
                        name: "FK_ticketTbl_concertTbl_ConcertId",
                        column: x => x.ConcertId,
                        principalTable: "concertTbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookingTbl_ConcertId",
                table: "bookingTbl",
                column: "ConcertId");

            migrationBuilder.CreateIndex(
                name: "IX_concertTbl_ArtistId",
                table: "concertTbl",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_concertTbl_VenueId",
                table: "concertTbl",
                column: "VenueId");

            migrationBuilder.CreateIndex(
                name: "IX_ticketTbl_BookingId",
                table: "ticketTbl",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_ticketTbl_ConcertId",
                table: "ticketTbl",
                column: "ConcertId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ticketTbl");

            migrationBuilder.DropTable(
                name: "bookingTbl");

            migrationBuilder.DropTable(
                name: "concertTbl");

            migrationBuilder.DropTable(
                name: "artistTbl");

            migrationBuilder.DropTable(
                name: "VenueTbl");
        }
    }
}
