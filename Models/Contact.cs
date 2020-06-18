using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ParentContactWeb.models
{

    public enum ContactReason
    {
        [Display(Name = "General Update")]
        GeneralUpdate,
        [Display(Name = "Behaviour Concern")]
        Behaviour,
        [Display(Name = "Academic Concern")]
        Academic,
        [Display(Name = "Attendance/Truancy")]
        Attendance,
        [Display(Name = "Health Concern")]
        Health,
        [Display(Name = "School Update")]
        SchoolUPdate,
        [Display(Name = "Enrollment")]
        Enrollment,
        [Display(Name = "Re-Enrollment")]
        ReEnrollment
    }

    public enum ContactMethod
    {
        [Display(Name = "Phonee")]
        Phone,
        [Display(Name = "Text")]
        Text,
        [Display(Name = "Via Remind")]
        Remind,
        [Display(Name = "Email")]
        Email,
        [Display(Name = "SMS via Summit")]
        Summit,
        [Display(Name = "Via Swiftk12")]
        Swiftk12,
        [Display(Name = "Verbal")]
        Verbal
       
    }


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
        public string AssignedTo { get; set; }

        public virtual Parent Parent { get; set; }
        public virtual Student Student { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}
