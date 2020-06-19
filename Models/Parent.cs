using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParentContactWeb.models
{
    [Table("parent")]
    public partial class Parent
    {
        public Parent()
        {
            Contacts = new HashSet<Contact>();
        }

        [Key]
        [Column("parentID", TypeName = "int(11)")]
        public int ParentId { get; set; }
        [Column("StudentID", TypeName = "int(11)")]
        public int StudentId { get; set; }
        [Required]
        [Column(TypeName = "varchar(60)")]
        public string FamilyName { get; set; }
        [Required]
        [Column(TypeName = "varchar(40)")]
        public string FirstName { get; set; }
        [Column(TypeName = "varchar(40)")]
        public string CellNo { get; set; }
        [Column("email", TypeName = "varchar(40)")]
        public string Email { get; set; }

        [ForeignKey(nameof(StudentId))]
        [InverseProperty("Parents")]
        public virtual Student Student { get; set; }
        [InverseProperty(nameof(Contact.Parent))]
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
