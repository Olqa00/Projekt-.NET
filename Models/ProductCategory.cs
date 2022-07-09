using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_2.Models
{
    public class ProductCategory
    {
        [Key]
        public int id { get; set; }
        [Display(Name ="Nazwa Produktu")]
        [Required]
        public int productID { get; set; }
        [Display(Name = "Produkt")]
        public Product Products { get; set; }

        [Display(Name ="Kategoria")]
        public int categoryID { get; set; }
        [Display(Name = "Kategoria")]
        public Category Categories { get; set; }
    }
}
