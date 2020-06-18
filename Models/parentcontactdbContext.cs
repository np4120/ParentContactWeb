﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ParentContactWeb.models
{
    public partial class parentcontactdbContext : DbContext
    {
       

        public parentcontactdbContext(DbContextOptions<parentcontactdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
           
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("contact");

                entity.HasIndex(e => e.ContactId)
                    .HasName("UK_contact_ContactID")
                    .IsUnique();

                entity.HasIndex(e => e.ParentId)
                    .HasName("IDX_contact_ParentID");

                entity.HasIndex(e => e.StudentId)
                    .HasName("IDX_contact_StudentID");

                entity.Property(e => e.ContactId)
                    .HasColumnName("ContactID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ContactDate).HasColumnType("datetime");

                entity.Property(e => e.ContactMethod)
                    .HasColumnType("varchar(20)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ContactReason)
                    .IsRequired()
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ContactStatus)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ParentComments)
                    .HasColumnType("varchar(2000)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ParentId)
                    .HasColumnName("ParentID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StudentId)
                    .HasColumnName("StudentID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TalkingPoints)
                    .HasColumnType("varchar(2000)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
               
                entity.Property(e => e.AssignedTo)
                    .HasColumnType("varchar(200)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");


                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_contact_parent_parentID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.ToTable("notes");

                entity.HasIndex(e => e.ContactId)
                    .HasName("IDX_notes_ContactID");

                entity.HasIndex(e => e.NoteId)
                    .HasName("UK_notes_NoteID")
                    .IsUnique();

                entity.HasIndex(e => e.StudentId)
                    .HasName("UK_notes_StudentID")
                    .IsUnique();

                entity.Property(e => e.NoteId)
                    .HasColumnName("NoteID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ContactId)
                    .HasColumnName("ContactID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ContactNotes)
                    .IsRequired()
                    .HasColumnType("varchar(2000)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.NoteDate).HasColumnType("datetime");

                entity.Property(e => e.NoteType)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ParentComments)
                    .HasColumnType("varchar(2000)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.StudentId)
                    .HasColumnName("StudentID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Student)
                    .WithOne(p => p.Note)
                    .HasForeignKey<Note>(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Parent>(entity =>
            {
                entity.ToTable("parent");

                entity.HasIndex(e => e.ParentId)
                    .HasName("UK_parent_parentID")
                    .IsUnique();

                entity.HasIndex(e => e.StudentId)
                    .HasName("IDX_parent_StudentID");

                entity.Property(e => e.ParentId)
                    .HasColumnName("parentID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CellNo)
                    .HasColumnType("varchar(40)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(40)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.FamilyName)
                    .IsRequired()
                    .HasColumnType("varchar(60)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("varchar(40)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.StudentId)
                    .HasColumnName("StudentID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Parents)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("student");

                entity.HasIndex(e => e.StudentId)
                    .HasName("UK_student_StudentID")
                    .IsUnique();

                entity.Property(e => e.StudentId)
                    .HasColumnName("StudentID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("varchar(40)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Grade).HasColumnType("int(11)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("varchar(40)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.StudentNo)
                    .IsRequired()
                    .HasColumnType("varchar(20)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.StudentNotes)
                    .HasColumnType("varchar(2000)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Usi)
                    .IsRequired()
                    .HasColumnName("USI")
                    .HasColumnType("varchar(20)")
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
