
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParentContactWeb.Models
{
    [Table("Staff")]
    public partial class Staff
    {
        [Key]
        [Column("StaffId", TypeName = "int(11)")]
        public int StaffId{ get; set; }

        [Column(TypeName = "varchar(100)")]
        public string FullName { get; set; }


        [Required]
        [Column(TypeName = "varchar(100)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string LastName { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Title { get; set; }



    }



}