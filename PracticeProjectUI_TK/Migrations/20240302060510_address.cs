using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticeProjectUI_TK.Migrations
{
    public partial class address : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PermanentAddressId",
                table: "StudentTbl",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address_streetline1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_streetline2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pincode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentTbl_PermanentAddressId",
                table: "StudentTbl",
                column: "PermanentAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentTbl_Address_PermanentAddressId",
                table: "StudentTbl",
                column: "PermanentAddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentTbl_Address_PermanentAddressId",
                table: "StudentTbl");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropIndex(
                name: "IX_StudentTbl_PermanentAddressId",
                table: "StudentTbl");

            migrationBuilder.DropColumn(
                name: "PermanentAddressId",
                table: "StudentTbl");
        }
    }
}
