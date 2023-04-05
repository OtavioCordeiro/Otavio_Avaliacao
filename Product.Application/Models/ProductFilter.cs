using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProduct.Application.Models
{
    public class ProductFilter
    {
        public string? Description { get; set; }
        public bool? Situation { get; set; }
        public string? Category { get; set; }
    }
}
