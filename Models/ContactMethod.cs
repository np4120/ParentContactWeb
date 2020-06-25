using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParentContactWeb.Models
{
    [Table("ContactMethod")]
    public partial class ContactMethod
    {
        [Key]
        [Column("CmID", TypeName = "int(11)")]
        public int CmID { get; set; }

        [Required]
        [Column(TypeName = "varchar(200)")]
        public string Method { get; set; }


    }
}

