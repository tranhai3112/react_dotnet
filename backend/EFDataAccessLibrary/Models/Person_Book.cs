using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace EFDataAccessLibrary.Models
{
    [Table("person_book")]
    public class Person_Book
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        public int BookId { get; set; }

        [ForeignKey("BookId")]
        public Book Book { get; set; }
        public int PersonId { get; set; }

        [ForeignKey("PersonId")]
        public Person Person { get; set; }

    }
}
