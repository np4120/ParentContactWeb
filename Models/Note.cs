using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParentContactWeb.models
{
    [Table("notes")]
    public partial class Note
    {
        [Key]
        [Column("NoteID", TypeName = "int(11)")]
        public int NoteId { get; set; }
        [Column("ContactID", TypeName = "int(11)")]
        public int ContactId { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string NoteType { get; set; }
        [Required]
        [Column(TypeName = "varchar(2000)")]
        public string ContactNotes { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime NoteDate { get; set; }
        [Column(TypeName = "varchar(2000)")]
        public string ParentComments { get; set; }
       
        [ForeignKey(nameof(ContactId))]
        [InverseProperty("Notes")]
        public virtual Contact Contact { get; set; }
        
        
    }
}
