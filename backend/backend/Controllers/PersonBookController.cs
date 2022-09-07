using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.IModels;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonBookController : ControllerBase
    {
        private readonly DataAccessContext _context;

        public PersonBookController(DataAccessContext context)
        {
            _context = context;
        }   

        [HttpGet]
        public async Task<ActionResult<List<PersonBookReturnType>>> GetAll()
        {
            var books = await (from person in _context.Persons
                                join person_book in _context.Person_Books on person.Id equals person_book.PersonId
                                join book in _context.Books on person_book.BookId equals book.Id
                                where person.Id == 1
                                select new PersonBookReturnType
                                {
                                    Id = book.Id,
                                    Name = book.Name,
                                    Descripion = book.Descripion,
                                    Price = book.Price,
                                }).ToListAsync();
            if(books.Count == 0)
            {
                return Ok(new
                {
                    message = "empty",
                });
            }
            return Ok(books);
        }

        [HttpPost]
        public async Task<ActionResult<List<Book>>> Create(List<int> bookId)
        {
            var person_books = bookId.Select(id =>
            {
                return new Person_Book
                {
                    BookId = id,
                    PersonId = 1,
                };
            });
            await _context.Person_Books.AddRangeAsync(person_books);
            var total = await _context.SaveChangesAsync();
            if(total == 0)
            {
                return BadRequest();
            }
            return Ok(person_books);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<object>> Delete(int id)
        {
            Person_Book person_Book = await _context.Person_Books.FindAsync(id);
            if (person_Book == null)
                return NotFound();
            _context.Person_Books.Remove(person_Book);
            await _context.SaveChangesAsync();
            return Ok(new 
            {
                deletedId = id,
                message = "success"
            });
        }
    }
}
