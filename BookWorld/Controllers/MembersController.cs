using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookWorld.Models;

namespace BookWorld.Controllers
{
    public class MembersController : Controller
    {
        //DbContext that accesses the database
        private ApplicationDbContext _context;

        public MembersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Members
        public ActionResult Index()
        {
            //Include method eager loads MembershipType
            var members = _context.Members.Include(m => m.MembershipType).ToList();

            return View(members);
        }
    }
}