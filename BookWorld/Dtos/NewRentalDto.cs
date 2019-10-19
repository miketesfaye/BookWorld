using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookWorld.Dtos
{
    public class NewRentalDto
    {
        public int MemberId { get; set; }
        public List<int> BookIds { get; set; }
    }
}