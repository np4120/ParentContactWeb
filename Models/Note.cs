using System;
using System.Collections.Generic;

namespace ParentContactWeb.models
{
    public partial class Note
    {
        public int NoteId { get; set; }
        public int ContactId { get; set; }
        public string NoteType { get; set; }
        public string ContactNotes { get; set; }
        public DateTime NoteDate { get; set; }
        public string ParentComments { get; set; }
        public int StudentId { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual Student Student { get; set; }
    }
}
