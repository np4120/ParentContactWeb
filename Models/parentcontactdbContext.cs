using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using ParentContactWeb.Models;

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
        public virtual DbSet<ContactReason> ContactReasons { get; set; }
        public virtual DbSet<ContactMethod> ContactMethods { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }

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
                entity.HasIndex(e => e.ContactId)
                    .HasName("UK_contact_ContactID")
                    .IsUnique();

                entity.HasIndex(e => e.ParentId)
                    .HasName("IDX_contact_ParentID");

                entity.HasIndex(e => e.StudentId)
                    .HasName("IDX_contact_StudentID");

                entity.Property(e => e.ContactMethod)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ContactReason)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ContactStatus)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ParentComments)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.TalkingPoints)
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
                entity.HasIndex(e => e.ContactId)
                    .HasName("IDX_notes_ContactID");

                entity.HasIndex(e => e.NoteId)
                    .HasName("UK_notes_NoteID")
                    .IsUnique();

                
                entity.Property(e => e.ContactNotes)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.NoteType)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.ParentComments)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

               
            });
            modelBuilder.Entity<ContactReason>(entity =>
            {
                entity.HasIndex(e => e.CrID)
                    .HasName("IDX_notes_crID");
                               
                entity.Property(e => e.Reason)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

           
            });

            modelBuilder.Entity<ContactMethod>(entity =>
            {
                entity.HasIndex(e => e.CmID)
                    .HasName("IDX_notes_cmID");

                entity.Property(e => e.Method)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");


            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.HasIndex(e => e.StaffId)
                    .HasName("IDX_Staff_Staffid");

                entity.Property(e => e.FirstName)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
                entity.Property(e => e.LastName)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
                entity.Property(e => e.Notes)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });


            modelBuilder.Entity<Parent>(entity =>
            {
                entity.HasIndex(e => e.ParentId)
                    .HasName("UK_parent_parentID")
                    .IsUnique();

                entity.HasIndex(e => e.StudentId)
                    .HasName("IDX_parent_StudentID");

                entity.Property(e => e.CellNo)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Email)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.FamilyName)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.FirstName)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Parents)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasIndex(e => e.StudentId)
                    .HasName("UK_student_StudentID")
                    .IsUnique();

                entity.Property(e => e.FirstName)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.LastName)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.StudentNo)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.StudentNotes)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.Usi)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
