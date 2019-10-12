using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookWorld.Models;

namespace BookWorld.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        public ActionResult Index()
        {
            var book = new Book() {Name = "Illiad"};

            return View();
        }
    }
}