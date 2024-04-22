using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticeProjectUI_TK.Migrations
{
    public partial class tk1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stateTbl_countryTbl_CountriesCountryId",
                table: "stateTbl");

            migrationBuilder.RenameColumn(
                name: "CountriesCountryId",
                table: "stateTbl",
                newName: "CountriesId");

            migrationBuilder.RenameIndex(
                name: "IX_stateTbl_CountriesCountryId",
                table: "stateTbl",
                newName: "IX_stateTbl_CountriesId");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "countryTbl",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_stateTbl_countryTbl_CountriesId",
                table: "stateTbl",
                column: "CountriesId",
                principalTable: "countryTbl",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stateTbl_countryTbl_CountriesId",
                table: "stateTbl");

            migrationBuilder.RenameColumn(
                name: "CountriesId",
                table: "stateTbl",
                newName: "CountriesCountryId");

            migrationBuilder.RenameIndex(
                name: "IX_stateTbl_CountriesId",
                table: "stateTbl",
                newName: "IX_stateTbl_CountriesCountryId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "countryTbl",
                newName: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_stateTbl_countryTbl_CountriesCountryId",
                table: "stateTbl",
                column: "CountriesCountryId",
                principalTable: "countryTbl",
                principalColumn: "CountryId");
        }
    }
}
