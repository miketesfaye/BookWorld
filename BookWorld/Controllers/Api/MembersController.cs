using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using BookWorld.App_Start;
using BookWorld.Dtos;
using BookWorld.Models;

namespace BookWorld.Controllers.Api
{
    public class MembersController : ApiController
    {
        protected readonly IMapper _mapper;
        private readonly MapperConfiguration config;

        private ApplicationDbContext _context;

        public MembersController()
        {
            config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            _mapper = config.CreateMapper();

            _context = new ApplicationDbContext();
        }

        // GET /api/members
        public IHttpActionResult GetMembers()
        {
            var memberDtos = _context.Members
                .Include(m => m.MembershipType)
                .ToList()
                .Select(_mapper.Map<Member, MemberDto>);

            return Ok(memberDtos);
        }

        // GET /api/members/1
        public IHttpActionResult GetMember(int id)
        {
            var member = _context.Members.SingleOrDefault(m => m.Id == id);

            if (member == null)
                return NotFound();

            return Ok(_mapper.Map<Member, MemberDto>(member));
        }

        // POST /api/members
        [HttpPost]
        public IHttpActionResult CreateMember(MemberDto memberDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var member = _mapper.Map<MemberDto, Member>(memberDto);
            _context.Members.Add(member);
            _context.SaveChanges();

            memberDto.Id = member.Id;

            return Created(new Uri(Request.RequestUri + "/" + member.Id), memberDto);
        }

        // PUT /api/members/1
        [HttpPut]
        public IHttpActionResult UpdateMember(int id, MemberDto memberDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var memberInDb = _context.Members.SingleOrDefault(m => m.Id == id);

            if (memberInDb == null)
                return NotFound();

            _mapper.Map(memberDto, memberInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/members/1
        [HttpDelete]
        public IHttpActionResult DeleteMember(int id)
        {
            var memberInDb = _context.Members.SingleOrDefault(m => m.Id == id);

            if (memberInDb == null)
                return NotFound();

            _context.Members.Remove(memberInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
