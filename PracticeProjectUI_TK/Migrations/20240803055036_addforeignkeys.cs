using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticeProjectUI_TK.Migrations
{
    public partial class addforeignkeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stateTbl_countryTbl_CountryId",
                table: "stateTbl");

            migrationBuilder.DropColumn(
                name: "Country_ID",
                table: "stateTbl");

            migrationBuilder.RenameColumn(
                name: "CountryId",
                table: "stateTbl",
                newName: "CountryID");

            migrationBuilder.RenameIndex(
                name: "IX_stateTbl_CountryId",
                table: "stateTbl",
                newName: "IX_stateTbl_CountryID");

            migrationBuilder.AlterColumn<int>(
                name: "CountryID",
                table: "stateTbl",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_stateTbl_countryTbl_CountryID",
                table: "stateTbl",
                column: "CountryID",
                principalTable: "countryTbl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_stateTbl_countryTbl_CountryID",
                table: "stateTbl");

            migrationBuilder.RenameColumn(
                name: "CountryID",
                table: "stateTbl",
                newName: "CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_stateTbl_CountryID",
                table: "stateTbl",
                newName: "IX_stateTbl_CountryId");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "stateTbl",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Country_ID",
                table: "stateTbl",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_stateTbl_countryTbl_CountryId",
                table: "stateTbl",
                column: "CountryId",
                principalTable: "countryTbl",
                principalColumn: "Id");
        }
    }
}
