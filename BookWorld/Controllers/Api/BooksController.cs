using System;
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
    public class BooksController : ApiController
    {
        protected readonly IMapper _mapper;
        private readonly MapperConfiguration config;

        private ApplicationDbContext _context;

        public BooksController()
        {
            config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
            _mapper = config.CreateMapper();

            _context = new ApplicationDbContext();
        }

        // GET /api/books
        public IHttpActionResult GetBooks()
        {
            var bookDtos = _context.Books.ToList().Select(_mapper.Map<Book, BookDto>);

            return Ok(bookDtos);
        }

        // GET /api/books/1
        public IHttpActionResult GetBook(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);

            if (book == null)
                return NotFound();

            return Ok(_mapper.Map<Book, BookDto>(book));
        }

        // POST /api/books
        [HttpPost]
        public IHttpActionResult CreateBook(BookDto bookDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var book = _mapper.Map<BookDto, Book>(bookDto);
            _context.Books.Add(book);
            _context.SaveChanges();

            bookDto.Id = book.Id;

            return Created(new Uri(Request.RequestUri + "/" + book.Id), bookDto);
        }

        // PUT /api/books/1
        [HttpPut]
        public IHttpActionResult UpdateBook(int id, BookDto bookDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var bookInDb = _context.Books.SingleOrDefault(b => b.Id == id);

            if (bookInDb == null)
                return NotFound();

            _mapper.Map(bookDto, bookInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/books/1
        [HttpDelete]
        public IHttpActionResult DeleteBook(int id)
        {
            var bookInDb = _context.Books.SingleOrDefault(b => b.Id == id);

            if (bookInDb == null)
                return NotFound();

            _context.Books.Remove(bookInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
