using EFDataAccessLibrary.DataAccess;
using EFDataAccessLibrary.IModels;
using EFDataAccessLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        public readonly DataAccessContext _context;
        public ProfileController(DataAccessContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserReturnType>> GetOne(int id)
        {
            var result = await (from profile in _context.Profiles
                                     join person in _context.Persons on profile.Id equals person.Id
                                     where profile.Id == id
                                     select new UserReturnType
                                     {
                                         Id = person.Id,
                                         FirstName = person.FirstName,
                                         LastName = person.LastName,
                                         Email = profile.email
                                     }).ToListAsync();
            if(result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<Profile>> Update(Profile profile)
        {
            Profile profileToUpdate = await _context.Profiles.FindAsync(profile.Id);
            if (profileToUpdate == null)
                return NotFound();
            profileToUpdate.email = profile.email;
            await _context.SaveChangesAsync();
            return Ok(profileToUpdate);

        }
       
    }
}
