using EFDataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.IModels
{
    public class PersonBookReturnType
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Descripion { get; set; }
        public decimal Price { get; set; }

    }
}
