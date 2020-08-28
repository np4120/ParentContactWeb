
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParentContactWeb.Models
{
    [Table("contactreason")]
    public partial class ContactReason
    {
        [Key]
        [Column("CrID", TypeName = "int(11)")]
        public int CrID { get; set; }

        [Required]
        [Column(TypeName = "varchar(200)")]
        public string Reason { get; set; }


    }

}