using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticeProjectUI_TK.Migrations
{
    public partial class Removecolum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DOB",
                table: "TaxpayerTbl");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "TaxpayerTbl");

            migrationBuilder.DropColumn(
                name: "IndividualName",
                table: "TaxpayerTbl");

            migrationBuilder.DropColumn(
                name: "IndividualSSN",
                table: "TaxpayerTbl");

            migrationBuilder.DropColumn(
                name: "SSN",
                table: "TaxpayerTbl");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "TaxpayerTbl");

            migrationBuilder.AlterColumn<string>(
                name: "IsReceiveForm1095",
                table: "TaxpayerTbl",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsReceiveForm1095",
                table: "TaxpayerTbl",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "TaxpayerTbl",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "TaxpayerTbl",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "IndividualName",
                table: "TaxpayerTbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IndividualSSN",
                table: "TaxpayerTbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SSN",
                table: "TaxpayerTbl",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "TaxpayerTbl",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
