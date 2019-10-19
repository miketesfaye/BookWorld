using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookWorld.Models
{
    public class Rental
    {
        public int Id { get; set; }

        [Required]
        public Member Member { get; set; }

        [Required]
        public Book Book { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }
    }
}