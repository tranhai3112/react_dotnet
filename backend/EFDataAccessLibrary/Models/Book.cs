using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.Models
{
    [Table("book")]
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName ="ntext")]
        public string Name { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Column(TypeName ="ntext")]
        public string Descripion { get; set; } = String.Empty;

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

    }
}
