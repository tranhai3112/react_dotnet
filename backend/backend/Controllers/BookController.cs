using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly DataAccessContext _context;

        public BookController(DataAccessContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAll([FromQuery]string name)
        {
            
            //var books = await (from person in _context.Persons
            //                   join person_book in _context.Person_Books on person.Id equals person_book.PersonId
            //                   join book in _context.Books on person_book.BookId equals book.Id 
            //                   where person.Id == 1
            //                   select new
            //                   {
            //                       Id = person.Id,
            //                       BookName = book.Name,
            //                       Price = book.Price,
            //                       Description = book.Descripion,
            //                       Date = book.Date
            //                   }).ToListAsync();
            var books = await (from book in _context.Books
                               where book.Name.Contains(name)
                               select book
                               ).ToListAsync();
            if(books.Count == 0)
            {
                return Ok(new { message= "empty" });
            }
            return Ok(books);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> Create(Book book)
        {
            _context.Books.Add(book);
            var result = await _context.SaveChangesAsync();
            if(result == 0)
            {
                return BadRequest();
            }
            return Ok(book);
        }

        [HttpPut]
        public async Task<ActionResult<Book>> Update(Book book)
        {
            Book b = await _context.Books.FindAsync(book.Id);
            if(b == null)
                return NotFound();
            b.Name = book.Name;
            b.Descripion = book.Descripion;
            b.Price = book.Price;
            await _context.SaveChangesAsync();
            return Ok(book);
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult<object>> SoftDelete(int id)
        {
            Book book = await _context.Books.FindAsync(id);
            if (book == null)
                return NotFound();
            book.deleted_at = DateTime.Now;
            await _context.SaveChangesAsync();
            return Ok(new
            {
                ModifiedId = id,
                message = "success",
            });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<object>> Delete(int id)
        {
            var book = await _context.Books.FindAsync(id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                deletedId = id,
                message = "success",
            });
        }
    }
}
