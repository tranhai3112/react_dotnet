using EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.DataAccess
{
    public class DataAccessContext : DbContext
    {
        public DataAccessContext(DbContextOptions options) : base(options) { }
        
        public DbSet<Person> Persons { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Person_Book> Person_Books { get; set; }

        public DbSet<Profile> Profiles { get; set; }

        public DbSet<Address> Addresses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Person_Book>(options =>
            {
                options.HasIndex(person_book => new
                {
                    person_book.BookId,
                    person_book.PersonId
                }).IsUnique();
            });
            modelBuilder.Entity<Profile>(options =>
            {
                options.HasOne(profile => profile.Person)
                       .WithOne(person => person.Profile)
                       .HasForeignKey<Profile>(profile => profile.Id)
                       .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<Address>(options =>
            {
                options.HasOne(address => address.Person)
                       .WithMany(person => person.Addresses)
                       .HasForeignKey(address => address.PersonId)
                       .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
