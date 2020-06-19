using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParentContactWeb.models
{
    [Table("contact")]
    public partial class Contact
    {
        public Contact()
        {
            Notes = new HashSet<Note>();
        }

        [Key]
        [Column("ContactID", TypeName = "int(11)")]
        public int ContactId { get; set; }
        [Column("StudentID", TypeName = "int(11)")]
        public int StudentId { get; set; }
        [Column("ParentID", TypeName = "int(11)")]
        public int ParentId { get; set; }
        [Required]
        [Column(TypeName = "varchar(1000)")]
        public string ContactReason { get; set; }
        [Column(TypeName = "varchar(2000)")]
        public string TalkingPoints { get; set; }
        [Column(TypeName = "varchar(2000)")]
        public string ParentComments { get; set; }
        public bool? FollowUpNeeded { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string ContactStatus { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string ContactMethod { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ContactDate { get; set; }

        [ForeignKey(nameof(ParentId))]
        [InverseProperty("Contacts")]
        public virtual Parent Parent { get; set; }
        [ForeignKey(nameof(StudentId))]
        [InverseProperty("Contacts")]
        public virtual Student Student { get; set; }
        [InverseProperty(nameof(Note.Contact))]
        public virtual ICollection<Note> Notes { get; set; }
    }
}
