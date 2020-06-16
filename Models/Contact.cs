using System;
using System.Collections.Generic;

namespace ParentContactWeb.models
{
    public partial class Contact
    {
        public Contact()
        {
            Notes = new HashSet<Note>();
        }

        public int ContactId { get; set; }
        public int StudentId { get; set; }
        public int ParentId { get; set; }
        public string ContactReason { get; set; }
        public string TalkingPoints { get; set; }
        public string ParentComments { get; set; }
        public bool? FollowUpNeeded { get; set; }
        public string ContactStatus { get; set; }
        public string ContactMethod { get; set; }
        public DateTime ContactDate { get; set; }

        public virtual Parent Parent { get; set; }
        public virtual Student Student { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}
