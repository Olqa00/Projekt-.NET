using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_2.Models
{
    public class ProductType
    {
        public int id { get; set; }
        [Display(Name = "Nazwa typu")]
        [Required(ErrorMessage = "To pole jest obowiązkowe")]
        public string name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
