using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConcertBooking_WebApp.Migrations
{
    public partial class bookticket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ticketTbl_bookingTbl_BookingId",
                table: "ticketTbl");

            migrationBuilder.DropForeignKey(
                name: "FK_ticketTbl_concertTbl_ConcertId",
                table: "ticketTbl");

            migrationBuilder.DropIndex(
                name: "IX_ticketTbl_ConcertId",
                table: "ticketTbl");

            migrationBuilder.DropColumn(
                name: "ConcertId",
                table: "ticketTbl");

            migrationBuilder.AlterColumn<int>(
                name: "BookingId",
                table: "ticketTbl",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ticketTbl_bookingTbl_BookingId",
                table: "ticketTbl",
                column: "BookingId",
                principalTable: "bookingTbl",
                principalColumn: "BookingId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ticketTbl_bookingTbl_BookingId",
                table: "ticketTbl");

            migrationBuilder.AlterColumn<int>(
                name: "BookingId",
                table: "ticketTbl",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ConcertId",
                table: "ticketTbl",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ticketTbl_ConcertId",
                table: "ticketTbl",
                column: "ConcertId");

            migrationBuilder.AddForeignKey(
                name: "FK_ticketTbl_bookingTbl_BookingId",
                table: "ticketTbl",
                column: "BookingId",
                principalTable: "bookingTbl",
                principalColumn: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_ticketTbl_concertTbl_ConcertId",
                table: "ticketTbl",
                column: "ConcertId",
                principalTable: "concertTbl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
