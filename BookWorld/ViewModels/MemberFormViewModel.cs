using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookWorld.Models;

namespace BookWorld.ViewModels
{
    public class MemberFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Member Member { get; set; }
        public string Title
        {
            get
            {
                if (Member != null && Member.Id != 0)
                    return "Edit Member";

                return "New Member";
            }
        }
    }
}