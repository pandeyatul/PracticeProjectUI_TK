using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticeProjectUI_TK.Migrations
{
    public partial class tk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "countryTbl",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countryTbl", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "stateTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country_ID = table.Column<int>(type: "int", nullable: false),
                    CountriesCountryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stateTbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_stateTbl_countryTbl_CountriesCountryId",
                        column: x => x.CountriesCountryId,
                        principalTable: "countryTbl",
                        principalColumn: "CountryId");
                });

            migrationBuilder.CreateTable(
                name: "cityTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    city_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cityTbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cityTbl_stateTbl_StateID",
                        column: x => x.StateID,
                        principalTable: "stateTbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cityTbl_StateID",
                table: "cityTbl",
                column: "StateID");

            migrationBuilder.CreateIndex(
                name: "IX_stateTbl_CountriesCountryId",
                table: "stateTbl",
                column: "CountriesCountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cityTbl");

            migrationBuilder.DropTable(
                name: "stateTbl");

            migrationBuilder.DropTable(
                name: "countryTbl");
        }
    }
}
