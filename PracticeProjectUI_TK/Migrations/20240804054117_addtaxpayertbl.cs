using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticeProjectUI_TK.Migrations
{
    public partial class addtaxpayertbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaxpayerTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsReceiveForm1095 = table.Column<bool>(type: "bit", nullable: false),
                    Identifier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Policynumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SSN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IndividualName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IndividualSSN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxpayerTbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Monthly_Premium_Information",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Month = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MPAmount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SLCSP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxCredit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxpayerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monthly_Premium_Information", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Monthly_Premium_Information_TaxpayerTbl_TaxpayerId",
                        column: x => x.TaxpayerId,
                        principalTable: "TaxpayerTbl",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Monthly_Premium_Information_TaxpayerId",
                table: "Monthly_Premium_Information",
                column: "TaxpayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Monthly_Premium_Information");

            migrationBuilder.DropTable(
                name: "TaxpayerTbl");
        }
    }
}
