using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PracticeProjectUI_TK.Migrations
{
    public partial class skillstudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SkillsTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillsTbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTbl", x => x.Id);
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

            migrationBuilder.CreateIndex(
                name: "IX_StudentSkill_SkillId",
                table: "StudentSkill",
                column: "SkillId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentSkill");

            migrationBuilder.DropTable(
                name: "SkillsTbl");

            migrationBuilder.DropTable(
                name: "StudentTbl");
        }
    }
}
