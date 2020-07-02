using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParentContactWeb.models
{
    [Table("student")]
    public partial class Student
    {
        public Student()
        {
            Contacts = new HashSet<Contact>();
            Parents = new HashSet<Parent>();
        }

        [Key]
        [Column("StudentID", TypeName = "int(11)")]
        public int StudentId { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string StudentNo { get; set; }
        [Required]
        [Column("USI", TypeName = "varchar(20)")]
        public string Usi { get; set; }
        [Required]
        [Column(TypeName = "varchar(40)")]
        public string FirstName { get; set; }
        [Required]
        [Column(TypeName = "varchar(40)")]
        public string LastName { get; set; }
        [Column(TypeName = "int(11)")]
        public int? Grade { get; set; }
        [Column(TypeName = "varchar(2000)")]
        public string StudentNotes { get; set; }

        
        public virtual Note Note { get; set; }
        [InverseProperty(nameof(Contact.Student))]
        public virtual ICollection<Contact> Contacts { get; set; }
        [InverseProperty(nameof(Parent.Student))]
        public virtual ICollection<Parent> Parents { get; set; }
    }
}
