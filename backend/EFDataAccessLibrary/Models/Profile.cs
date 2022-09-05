using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using System.Net.Mail;

namespace EFDataAccessLibrary.Models
{
    [Table("profile")]
    public class Profile
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        public Person Person { get; set; }
    }
    
    public class ProfileValidator : AbstractValidator<Profile>
    {
        public ProfileValidator()
        {
            RuleFor(profile => profile.email)
                .Must(IsValidEmail).WithMessage("Invalid {PropertyName}");
        }
        protected static bool IsValidEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
