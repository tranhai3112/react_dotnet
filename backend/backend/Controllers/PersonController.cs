using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.Models;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly DataAccessContext _context;

        public PersonController(DataAccessContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetAll()
        {
            return Ok(await _context.Persons.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetOne(int id)
        {
            var person = await _context.Persons.FindAsync(id);
            return person == null ? NotFound() : Ok(person);
        }

        [HttpPost]
        public async Task<ActionResult<Person>> Create(Person person)
        {
            PersonValidator validationRules = new PersonValidator();
            ValidationResult result = validationRules.Validate(person);
            IDbContextTransaction transaction = null;
            if (result.IsValid)
            {
                try
                {
                    //https://stackoverflow.com/questions/5212751/how-can-i-retrieve-id-of-inserted-entity-using-entity-framework
                    using (transaction = await _context.Database.BeginTransactionAsync())
                    {
                        Profile profile = new Profile
                        {
                            Person = person,
                        };
                        Address address = new Address
                        {
                            Person = person,
                        };
                        _context.Persons.Add(person);
                        await _context.SaveChangesAsync();
                        transaction.Commit();
                        return Ok(person);
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return BadRequest(ex);
                }
            } else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Person>> Update(Person person)
        {
            Person p = await _context.Persons.FindAsync(person.Id);
            if(p == null)
                return NotFound();
            p.FirstName = person.FirstName;
            p.LastName = person.LastName;
            p.Age = person.Age;

            await _context.SaveChangesAsync();
            return Ok(person);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<object>> Delete(int id)
        {
            Person person = await _context.Persons.FindAsync(id);
            if (person == null)
                return NotFound();
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                deletedId = id,
                message = "success",
            });
        }

    }
}
