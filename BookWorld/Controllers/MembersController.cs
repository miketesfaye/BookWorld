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

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new MemberFormViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View("MemberForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Member member)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MemberFormViewModel()
                {
                    Member = member,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("MemberForm", viewModel);
            }

            if (member.Id == 0)
                _context.Members.Add(member);
            else
            {
                var memberInDb = _context.Members.Single(m => m.Id == member.Id);

                memberInDb.Name = member.Name;
                memberInDb.Birthdate = member.Birthdate;
                memberInDb.MembershipTypeId = member.MembershipTypeId;
                memberInDb.IsSubscribedToNewsLetter = member.IsSubscribedToNewsLetter;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Members");
        }

        public ActionResult Edit(int id)
        {
            var member = _context.Members.SingleOrDefault(m => m.Id == id);

            if (member == null)
                return HttpNotFound();

            var viewModel = new MemberFormViewModel()
            {
                Member = member,
                //Getting MembershipTypes from the database since Member already exists
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("MemberForm", viewModel);
        }
    }
}