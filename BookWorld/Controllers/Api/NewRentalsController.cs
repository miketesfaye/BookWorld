using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookWorld.Dtos;
using BookWorld.Models;

namespace BookWorld.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }


        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            var member = _context.Members.Single(
                m => m.Id == newRental.MemberId);

            var books = _context.Books.Where(
                b => newRental.BookIds.Contains(b.Id)).ToList();

            foreach (var book in books)
            {
                if (book.NumberAvailable == 0)
                    return BadRequest("Book is not available.");

                book.NumberAvailable--;

                var rental = new Rental
                {
                    Member = member,
                    Book = book,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
