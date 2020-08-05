using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParentContactWeb.ViewModels
{
    public class ContactFollowupViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string ContactReason { get; set; }

        public DateTime COntactDate { get; set; }

        public int ContactID { get; set; }

        public Boolean FollowUPNeeded { get; set; }
    }
}
