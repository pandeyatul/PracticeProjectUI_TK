using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConcertBooking_WebApp.Migrations
{
    public partial class booktickets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConcertId",
                table: "ticketTbl",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConcertId",
                table: "ticketTbl");
        }
    }
}
