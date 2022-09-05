using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Models
{
    [Table("address")]
    public class Address
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [Column(TypeName ="ntext")]
        public string Name { get; set; }

        public int PersonId { get; set; }

        [ForeignKey("PersonId")]
        public Person person { get; set; }

    }
}
