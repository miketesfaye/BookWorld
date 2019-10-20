using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookWorld.Models;
using BookWorld.ViewModels;

namespace BookWorld.Controllers
{
    public class BooksController : Controller
    {
        //DbContext that accesses the database
        private ApplicationDbContext _context;

        public BooksController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Books
        public ViewResult Index()
        {
            //Include method eager loads MembershipType
            var books = _context.Books.Include(b => b.Genre).ToList();

            return View(books);
        }
        public ViewResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new BookFormViewModel
            {
                Genres = genres
            };

            return View("BookForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Book book)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new BookFormViewModel(book)
                {
                    Genres = _context.Genres.ToList()
                };

                return View("BookForm", viewModel);
            }

            if (book.Id == 0)
            {
                book.DateAdded = DateTime.Now;
                book.NumberAvailable = book.NumberInStock;
                _context.Books.Add(book);
            }
                
            else
            {
                var bookInDb = _context.Books.Single(m => m.Id == book.Id);

                bookInDb.Name = book.Name;
                bookInDb.ReleaseDate = book.ReleaseDate;
                bookInDb.GenreId = book.GenreId;
                bookInDb.NumberInStock = book.NumberInStock;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Books");
        }

        public ActionResult Edit(int id)
        {
            var book = _context.Books.SingleOrDefault(m => m.Id == id);

            if (book == null)
                return HttpNotFound();

            var viewModel = new BookFormViewModel(book)
            {
                Genres = _context.Genres.ToList()
            };

            return View("BookForm", viewModel);
        }
    }
}