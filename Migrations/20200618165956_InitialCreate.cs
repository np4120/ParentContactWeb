using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParentContactWeb.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StudentNo = table.Column<string>(type: "varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci"),
                    USI = table.Column<string>(type: "varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci"),
                    FirstName = table.Column<string>(type: "varchar(40)", nullable: false)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci"),
                    LastName = table.Column<string>(type: "varchar(40)", nullable: false)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci"),
                    Grade = table.Column<int>(type: "int(11)", nullable: true),
                    StudentNotes = table.Column<string>(type: "varchar(2000)", nullable: true)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.StudentID);
                });

            migrationBuilder.CreateTable(
                name: "parent",
                columns: table => new
                {
                    parentID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StudentID = table.Column<int>(type: "int(11)", nullable: false),
                    FamilyName = table.Column<string>(type: "varchar(60)", nullable: false)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci"),
                    FirstName = table.Column<string>(type: "varchar(40)", nullable: false)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci"),
                    CellNo = table.Column<string>(type: "varchar(40)", nullable: true)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci"),
                    email = table.Column<string>(type: "varchar(40)", nullable: true)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parent", x => x.parentID);
                    table.ForeignKey(
                        name: "FK_parent_student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "student",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "contact",
                columns: table => new
                {
                    ContactID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StudentID = table.Column<int>(type: "int(11)", nullable: false),
                    ParentID = table.Column<int>(type: "int(11)", nullable: false),
                    ContactReason = table.Column<string>(type: "varchar(1000)", nullable: false)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci"),
                    TalkingPoints = table.Column<string>(type: "varchar(2000)", nullable: true)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci"),
                    ParentComments = table.Column<string>(type: "varchar(2000)", nullable: true)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci"),
                    FollowUpNeeded = table.Column<bool>(nullable: true),
                    ContactStatus = table.Column<string>(type: "varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci"),
                    ContactMethod = table.Column<string>(type: "varchar(20)", nullable: true)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci"),
                    ContactDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contact", x => x.ContactID);
                    table.ForeignKey(
                        name: "FK_contact_parent_parentID",
                        column: x => x.ParentID,
                        principalTable: "parent",
                        principalColumn: "parentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_contact_student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "student",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "notes",
                columns: table => new
                {
                    NoteID = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ContactID = table.Column<int>(type: "int(11)", nullable: false),
                    NoteType = table.Column<string>(type: "varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci"),
                    ContactNotes = table.Column<string>(type: "varchar(2000)", nullable: false)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci"),
                    NoteDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ParentComments = table.Column<string>(type: "varchar(2000)", nullable: true)
                        .Annotation("MySql:CharSet", "latin1")
                        .Annotation("MySql:Collation", "latin1_swedish_ci"),
                    StudentID = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notes", x => x.NoteID);
                    table.ForeignKey(
                        name: "FK_notes_contact_ContactID",
                        column: x => x.ContactID,
                        principalTable: "contact",
                        principalColumn: "ContactID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_notes_student_StudentID",
                        column: x => x.StudentID,
                        principalTable: "student",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "UK_contact_ContactID",
                table: "contact",
                column: "ContactID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IDX_contact_ParentID",
                table: "contact",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IDX_contact_StudentID",
                table: "contact",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IDX_notes_ContactID",
                table: "notes",
                column: "ContactID");

            migrationBuilder.CreateIndex(
                name: "UK_notes_NoteID",
                table: "notes",
                column: "NoteID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UK_notes_StudentID",
                table: "notes",
                column: "StudentID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UK_parent_parentID",
                table: "parent",
                column: "parentID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IDX_parent_StudentID",
                table: "parent",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "UK_student_StudentID",
                table: "student",
                column: "StudentID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "notes");

            migrationBuilder.DropTable(
                name: "contact");

            migrationBuilder.DropTable(
                name: "parent");

            migrationBuilder.DropTable(
                name: "student");
        }
    }
}
