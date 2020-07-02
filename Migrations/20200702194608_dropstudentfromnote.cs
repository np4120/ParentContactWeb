using Microsoft.EntityFrameworkCore.Migrations;

namespace ParentContactWeb.Migrations
{
    public partial class dropstudentfromnote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_notes_student_StudentID",
                table: "notes");

            migrationBuilder.DropIndex(
                name: "UK_notes_StudentID",
                table: "notes");

            migrationBuilder.DropColumn(
                name: "StudentID",
                table: "notes");

            migrationBuilder.AddColumn<int>(
                name: "NoteId",
                table: "student",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_student_NoteId",
                table: "student",
                column: "NoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_student_notes_NoteId",
                table: "student",
                column: "NoteId",
                principalTable: "notes",
                principalColumn: "NoteID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_student_notes_NoteId",
                table: "student");

            migrationBuilder.DropIndex(
                name: "IX_student_NoteId",
                table: "student");

            migrationBuilder.DropColumn(
                name: "NoteId",
                table: "student");

            migrationBuilder.AddColumn<int>(
                name: "StudentID",
                table: "notes",
                type: "int(11)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "UK_notes_StudentID",
                table: "notes",
                column: "StudentID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_notes_student_StudentID",
                table: "notes",
                column: "StudentID",
                principalTable: "student",
                principalColumn: "StudentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
