using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticeProjectUI_TK.Migrations
{
    public partial class addforeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "countryTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country_Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countryTbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SkillsTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillsTbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsersTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passowrd = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersTbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentTbl_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "stateTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country_ID = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stateTbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_stateTbl_countryTbl_CountryId",
                        column: x => x.CountryId,
                        principalTable: "countryTbl",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentSkill",
                columns: table => new
                {
                    StudentsId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSkill", x => new { x.StudentsId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_StudentSkill_SkillsTbl_SkillId",
                        column: x => x.SkillId,
                        principalTable: "SkillsTbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSkill_StudentTbl_StudentsId",
                        column: x => x.StudentsId,
                        principalTable: "StudentTbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_stateTbl_CountryId",
                table: "stateTbl",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSkill_SkillId",
                table: "StudentSkill",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTbl_AddressId",
                table: "StudentTbl",
                column: "AddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cityTbl");

            migrationBuilder.DropTable(
                name: "StudentSkill");

            migrationBuilder.DropTable(
                name: "UsersTbl");

            migrationBuilder.DropTable(
                name: "stateTbl");

            migrationBuilder.DropTable(
                name: "SkillsTbl");

            migrationBuilder.DropTable(
                name: "StudentTbl");

            migrationBuilder.DropTable(
                name: "countryTbl");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
