using System;
using System.Collections.Generic;

namespace ParentContactWeb.models
{
    public partial class Parent
    {
        public Parent()
        {
            Contact = new HashSet<Contact>();
        }

        public int ParentId { get; set; }
        public int StudentId { get; set; }
        public string FamilyName { get; set; }
        public string FirstName { get; set; }
        public string CellNo { get; set; }
        public string Email { get; set; }

        public virtual Student Student { get; set; }
        public virtual ICollection<Contact> Contact { get; set; }
    }
}
