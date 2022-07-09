using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_2.Models
{
    public class Category
    {
        public int ID { get; set; }
        [Display(Name="Nazwa kategorii")]
        [Required(ErrorMessage = "To pole jest obowiązkowe")]
        public string name { get; set; }
        //public ICollection<Product> Products { get; set; }
        public ICollection<ProductCategory> ProductCategory { get; set; }
    }
}
