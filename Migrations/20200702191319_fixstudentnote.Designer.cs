﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParentContactWeb.models;

namespace ParentContactWeb.Migrations
{
    [DbContext(typeof(parentcontactdbContext))]
    [Migration("20200702191319_fixstudentnote")]
    partial class fixstudentnote
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ParentContactWeb.Models.ContactMethod", b =>
                {
                    b.Property<int>("CmID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CmID")
                        .HasColumnType("int(11)");

                    b.Property<string>("Method")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasAnnotation("MySql:CharSet", "latin1")
                        .HasAnnotation("MySql:Collation", "latin1_swedish_ci");

                    b.HasKey("CmID");

                    b.HasIndex("CmID")
                        .HasName("IDX_notes_cmID");

                    b.ToTable("ContactMethod");
                });

            modelBuilder.Entity("ParentContactWeb.Models.ContactReason", b =>
                {
                    b.Property<int>("CrID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CrID")
                        .HasColumnType("int(11)");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasAnnotation("MySql:CharSet", "latin1")
                        .HasAnnotation("MySql:Collation", "latin1_swedish_ci");

                    b.HasKey("CrID");

                    b.HasIndex("CrID")
                        .HasName("IDX_notes_crID");

                    b.ToTable("ContactReason");
                });

            modelBuilder.Entity("ParentContactWeb.Models.Staff", b =>
                {
                    b.Property<int>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("StaffId")
                        .HasColumnType("int(11)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasAnnotation("MySql:CharSet", "latin1")
                        .HasAnnotation("MySql:Collation", "latin1_swedish_ci");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasAnnotation("MySql:CharSet", "latin1")
                        .HasAnnotation("MySql:Collation", "latin1_swedish_ci");

                    b.Property<string>("Notes")
                        .HasColumnType("varchar(100)")
                        .HasAnnotation("MySql:CharSet", "latin1")
                        .HasAnnotation("MySql:Collation", "latin1_swedish_ci");

                    b.HasKey("StaffId");

                    b.HasIndex("StaffId")
                        .HasName("IDX_Staff_Staffid");

                    b.ToTable("Staff");
                });

            modelBuilder.Entity("ParentContactWeb.models.Contact", b =>
                {
                    b.Property<int>("ContactId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ContactID")
                        .HasColumnType("int(11)");

                    b.Property<string>("AssignedTo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("ContactDate")
                        .HasColumnType("datetime");

                    b.Property<string>("ContactMethod")
                        .HasColumnType("varchar(20)")
                        .HasAnnotation("MySql:CharSet", "latin1")
                        .HasAnnotation("MySql:Collation", "latin1_swedish_ci");

                    b.Property<string>("ContactReason")
                        .IsRequired()
                        .HasColumnType("varchar(1000)")
                        .HasAnnotation("MySql:CharSet", "latin1")
                        .HasAnnotation("MySql:Collation", "latin1_swedish_ci");

                    b.Property<string>("ContactStatus")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasAnnotation("MySql:CharSet", "latin1")
                        .HasAnnotation("MySql:Collation", "latin1_swedish_ci");

                    b.Property<bool?>("FollowUpNeeded")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ParentComments")
                        .HasColumnType("varchar(2000)")
                        .HasAnnotation("MySql:CharSet", "latin1")
                        .HasAnnotation("MySql:Collation", "latin1_swedish_ci");

                    b.Property<int>("ParentId")
                        .HasColumnName("ParentID")
                        .HasColumnType("int(11)");

                    b.Property<int>("StudentId")
                        .HasColumnName("StudentID")
                        .HasColumnType("int(11)");

                    b.Property<string>("TalkingPoints")
                        .HasColumnType("varchar(2000)")
                        .HasAnnotation("MySql:CharSet", "latin1")
                        .HasAnnotation("MySql:Collation", "latin1_swedish_ci");

                    b.HasKey("ContactId");

                    b.HasIndex("ContactId")
                        .IsUnique()
                        .HasName("UK_contact_ContactID");

                    b.HasIndex("ParentId")
                        .HasName("IDX_contact_ParentID");

                    b.HasIndex("StudentId")
                        .HasName("IDX_contact_StudentID");

                    b.ToTable("contact");
                });

            modelBuilder.Entity("ParentContactWeb.models.Note", b =>
                {
                    b.Property<int>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("NoteID")
                        .HasColumnType("int(11)");

                    b.Property<int>("ContactId")
                        .HasColumnName("ContactID")
                        .HasColumnType("int(11)");

                    b.Property<string>("ContactNotes")
                        .IsRequired()
                        .HasColumnType("varchar(2000)")
                        .HasAnnotation("MySql:CharSet", "latin1")
                        .HasAnnotation("MySql:Collation", "latin1_swedish_ci");

                    b.Property<DateTime>("NoteDate")
                        .HasColumnType("datetime");

                    b.Property<string>("NoteType")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasAnnotation("MySql:CharSet", "latin1")
                        .HasAnnotation("MySql:Collation", "latin1_swedish_ci");

                    b.Property<string>("ParentComments")
                        .HasColumnType("varchar(2000)")
                        .HasAnnotation("MySql:CharSet", "latin1")
                        .HasAnnotation("MySql:Collation", "latin1_swedish_ci");

                    b.Property<int>("StudentId")
                        .HasColumnName("StudentID")
                        .HasColumnType("int(11)");

                    b.HasKey("NoteId");

                    b.HasIndex("ContactId")
                        .HasName("IDX_notes_ContactID");

                    b.HasIndex("NoteId")
                        .IsUnique()
                        .HasName("UK_notes_NoteID");

                    b.HasIndex("StudentId")
                        .IsUnique()
                        .HasName("UK_notes_StudentID");

                    b.ToTable("notes");
                });

            modelBuilder.Entity("ParentContactWeb.models.Parent", b =>
                {
                    b.Property<int>("ParentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("parentID")
                        .HasColumnType("int(11)");

                    b.Property<string>("CellNo")
                        .HasColumnType("varchar(40)")
                        .HasAnnotation("MySql:CharSet", "latin1")
                        .HasAnnotation("MySql:Collation", "latin1_swedish_ci");

                    b.Property<string>("Email")
                        .HasColumnName("email")
                        .HasColumnType("varchar(40)")
                        .HasAnnotation("MySql:CharSet", "latin1")
                        .HasAnnotation("MySql:Collation", "latin1_swedish_ci");

                    b.Property<string>("FamilyName")
                        .IsRequired()
                        .HasColumnType("varchar(60)")
                        .HasAnnotation("MySql:CharSet", "latin1")
                        .HasAnnotation("MySql:Collation", "latin1_swedish_ci");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(40)")
                        .HasAnnotation("MySql:CharSet", "latin1")
                        .HasAnnotation("MySql:Collation", "latin1_swedish_ci");

                    b.Property<int>("StudentId")
                        .HasColumnName("StudentID")
                        .HasColumnType("int(11)");

                    b.HasKey("ParentId");

                    b.HasIndex("ParentId")
                        .IsUnique()
                        .HasName("UK_parent_parentID");

                    b.HasIndex("StudentId")
                        .HasName("IDX_parent_StudentID");

                    b.ToTable("parent");
                });

            modelBuilder.Entity("ParentContactWeb.models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("StudentID")
                        .HasColumnType("int(11)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(40)")
                        .HasAnnotation("MySql:CharSet", "latin1")
                        .HasAnnotation("MySql:Collation", "latin1_swedish_ci");

                    b.Property<int?>("Grade")
                        .HasColumnType("int(11)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(40)")
                        .HasAnnotation("MySql:CharSet", "latin1")
                        .HasAnnotation("MySql:Collation", "latin1_swedish_ci");

                    b.Property<string>("StudentNo")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasAnnotation("MySql:CharSet", "latin1")
                        .HasAnnotation("MySql:Collation", "latin1_swedish_ci");

                    b.Property<string>("StudentNotes")
                        .HasColumnType("varchar(2000)")
                        .HasAnnotation("MySql:CharSet", "latin1")
                        .HasAnnotation("MySql:Collation", "latin1_swedish_ci");

                    b.Property<string>("Usi")
                        .IsRequired()
                        .HasColumnName("USI")
                        .HasColumnType("varchar(20)")
                        .HasAnnotation("MySql:CharSet", "latin1")
                        .HasAnnotation("MySql:Collation", "latin1_swedish_ci");

                    b.HasKey("StudentId");

                    b.HasIndex("StudentId")
                        .IsUnique()
                        .HasName("UK_student_StudentID");

                    b.ToTable("student");
                });

            modelBuilder.Entity("ParentContactWeb.models.Contact", b =>
                {
                    b.HasOne("ParentContactWeb.models.Parent", "Parent")
                        .WithMany("Contacts")
                        .HasForeignKey("ParentId")
                        .HasConstraintName("FK_contact_parent_parentID")
                        .IsRequired();

                    b.HasOne("ParentContactWeb.models.Student", "Student")
                        .WithMany("Contacts")
                        .HasForeignKey("StudentId")
                        .IsRequired();
                });

            modelBuilder.Entity("ParentContactWeb.models.Note", b =>
                {
                    b.HasOne("ParentContactWeb.models.Contact", "Contact")
                        .WithMany("Notes")
                        .HasForeignKey("ContactId")
                        .IsRequired();

                    b.HasOne("ParentContactWeb.models.Student", "Student")
                        .WithOne("Note")
                        .HasForeignKey("ParentContactWeb.models.Note", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ParentContactWeb.models.Parent", b =>
                {
                    b.HasOne("ParentContactWeb.models.Student", "Student")
                        .WithMany("Parents")
                        .HasForeignKey("StudentId")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}