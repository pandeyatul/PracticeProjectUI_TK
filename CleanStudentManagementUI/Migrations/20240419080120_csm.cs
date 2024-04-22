using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanStudentManagementUI.Migrations
{
    public partial class csm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamResultTbl_QuesAnswerTbl_QuesAnswerId",
                table: "ExamResultTbl");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamResultTbl_StudentTbl_Studentid",
                table: "ExamResultTbl");

            migrationBuilder.DropIndex(
                name: "IX_ExamResultTbl_QuesAnswerId",
                table: "ExamResultTbl");

            migrationBuilder.DropColumn(
                name: "QuesAnswerId",
                table: "ExamResultTbl");

            migrationBuilder.RenameColumn(
                name: "Studentid",
                table: "ExamResultTbl",
                newName: "StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_ExamResultTbl_Studentid",
                table: "ExamResultTbl",
                newName: "IX_ExamResultTbl_StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamResultTbl_StudentTbl_StudentId",
                table: "ExamResultTbl",
                column: "StudentId",
                principalTable: "StudentTbl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamResultTbl_StudentTbl_StudentId",
                table: "ExamResultTbl");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "ExamResultTbl",
                newName: "Studentid");

            migrationBuilder.RenameIndex(
                name: "IX_ExamResultTbl_StudentId",
                table: "ExamResultTbl",
                newName: "IX_ExamResultTbl_Studentid");

            migrationBuilder.AddColumn<int>(
                name: "QuesAnswerId",
                table: "ExamResultTbl",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExamResultTbl_QuesAnswerId",
                table: "ExamResultTbl",
                column: "QuesAnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamResultTbl_QuesAnswerTbl_QuesAnswerId",
                table: "ExamResultTbl",
                column: "QuesAnswerId",
                principalTable: "QuesAnswerTbl",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamResultTbl_StudentTbl_Studentid",
                table: "ExamResultTbl",
                column: "Studentid",
                principalTable: "StudentTbl",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
