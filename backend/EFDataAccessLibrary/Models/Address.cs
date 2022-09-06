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
    [Table("address")]
    public class Address
    {
        [Key]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName ="ntext")]
        public string Name { get; set; }

        public int PersonId { get; set; }

        [JsonIgnore]
        [ForeignKey("PersonId")]
        public Person? Person { get; set; }

    }
}
