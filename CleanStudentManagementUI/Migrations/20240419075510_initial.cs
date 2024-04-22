using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanStudentManagementUI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GroupTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passwprd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTbl", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExamTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Period = table.Column<int>(type: "int", nullable: false),
                    Groupid = table.Column<int>(type: "int", nullable: false),
                    groupsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamTbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamTbl_GroupTbl_groupsId",
                        column: x => x.groupsId,
                        principalTable: "GroupTbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    groupId = table.Column<int>(type: "int", nullable: false),
                    GroupsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentTbl_GroupTbl_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "GroupTbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuesAnswerTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Examid = table.Column<int>(type: "int", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OptionD = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuesAnswerTbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuesAnswerTbl_ExamTbl_Examid",
                        column: x => x.Examid,
                        principalTable: "ExamTbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamResultTbl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Studentid = table.Column<int>(type: "int", nullable: false),
                    ExamId = table.Column<int>(type: "int", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuesAnswerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamResultTbl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExamResultTbl_ExamTbl_ExamId",
                        column: x => x.ExamId,
                        principalTable: "ExamTbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamResultTbl_QuesAnswerTbl_QuesAnswerId",
                        column: x => x.QuesAnswerId,
                        principalTable: "QuesAnswerTbl",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExamResultTbl_StudentTbl_Studentid",
                        column: x => x.Studentid,
                        principalTable: "StudentTbl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExamResultTbl_ExamId",
                table: "ExamResultTbl",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamResultTbl_QuesAnswerId",
                table: "ExamResultTbl",
                column: "QuesAnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamResultTbl_Studentid",
                table: "ExamResultTbl",
                column: "Studentid");

            migrationBuilder.CreateIndex(
                name: "IX_ExamTbl_groupsId",
                table: "ExamTbl",
                column: "groupsId");

            migrationBuilder.CreateIndex(
                name: "IX_QuesAnswerTbl_Examid",
                table: "QuesAnswerTbl",
                column: "Examid");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTbl_GroupsId",
                table: "StudentTbl",
                column: "GroupsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamResultTbl");

            migrationBuilder.DropTable(
                name: "UserTbl");

            migrationBuilder.DropTable(
                name: "QuesAnswerTbl");

            migrationBuilder.DropTable(
                name: "StudentTbl");

            migrationBuilder.DropTable(
                name: "ExamTbl");

            migrationBuilder.DropTable(
                name: "GroupTbl");
        }
    }
}
