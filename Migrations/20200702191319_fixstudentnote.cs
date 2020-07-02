using Microsoft.EntityFrameworkCore.Migrations;

namespace ParentContactWeb.Migrations
{
    public partial class fixstudentnote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_notes_student_StudentID",
                table: "notes");

            migrationBuilder.AddForeignKey(
                name: "FK_notes_student_StudentID",
                table: "notes",
                column: "StudentID",
                principalTable: "student",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_notes_student_StudentID",
                table: "notes");

            migrationBuilder.AddForeignKey(
                name: "FK_notes_student_StudentID",
                table: "notes",
                column: "StudentID",
                principalTable: "student",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
