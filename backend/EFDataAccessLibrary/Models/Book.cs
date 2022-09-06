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
    [Table("book")]
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName ="ntext")]
        public string Name { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Nullable<DateTime> deleted_at { get; set; } = null;

        [Column(TypeName ="ntext")]
        public string Descripion { get; set; } = String.Empty;

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

    }
}
