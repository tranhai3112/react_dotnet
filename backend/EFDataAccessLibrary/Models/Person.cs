using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace EFDataAccessLibrary.Models
{
    [Table("person")]
    public class Person
    {
        [Key]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int Id { get; set; }
        [Required]
        [StringLength(70)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(70)]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }
        public List<Address>? Addresses { get; set; }
        public Profile? Profile { get; set; }

    }
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(person => person.Age)
                .Must(age => age >=16).WithMessage("Invalid {PropertyName}, Age should be greater than 16 or equal to 16");
        }
    }
    
}
