using System;
using System.Collections.Generic;

namespace ParentContactWeb.models
{
    public partial class Student
    {
        public Student()
        {
            Contact = new HashSet<Contact>();
            Parent = new HashSet<Parent>();
        }

        public int StudentId { get; set; }
        public string StudentNo { get; set; }
        public string Usi { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Grade { get; set; }
        public string StudentNotes { get; set; }

        public virtual Notes Notes { get; set; }
        public virtual ICollection<Contact> Contact { get; set; }
        public virtual ICollection<Parent> Parent { get; set; }
    }
}
