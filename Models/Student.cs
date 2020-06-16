using System;
using System.Collections.Generic;

namespace ParentContactWeb.models
{
    public partial class Student
    {
        public Student()
        {
            Contacts = new HashSet<Contact>();
            Parents = new HashSet<Parent>();
        }

        public int StudentId { get; set; }
        public string StudentNo { get; set; }
        public string Usi { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Grade { get; set; }
        public string StudentNotes { get; set; }

        public virtual Note Note { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<Parent> Parents { get; set; }
    }
}
