using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_2.Models
{
    public class Product
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Typ")] //czy ksiazka, plyta itp
        [Required(ErrorMessage ="To pole jest obowiązkowe")]
        public int producttypeID { get; set; }
        [Display(Name = "Typ")]
        public ProductType ProductType { get; set; }
        [Display(Name = "Tytuł")]
        [StringLength(15)]
        [Required(ErrorMessage = "To pole jest obowiązkowe")]
        public string name { get; set; }
        [Display(Name = "Autor")]
        [Required(ErrorMessage = "To pole jest obowiązkowe")]
        public string author { get; set; }
        [Display(Name = "Rok Wydania")]
        [Required(ErrorMessage = "To pole jest obowiązkowe")]
        public string year { get; set; }
        [Display(Name = "Wydawnictwo")]
        [Required(ErrorMessage = "To pole jest obowiązkowe")]
        public string publishing_house { get; set; }
        [Display(Name = "Cena produktu")]
        [Required(ErrorMessage = "To pole jest obowiązkowe")]
        public decimal price { get; set; }
        [Display(Name ="Opis")]
        [Required]
        public string description { get; set; }
        [Display(Name ="Okładka")]
        [Required(ErrorMessage = "To pole jest obowiązkowe")]
        public string img { get; set;}
        public string link()
        {
            return img = "/Images/" + img + ".png" ;
        }
        [Display(Name = "Kategoria")]
        /*public int CategoryID { get; set; }
        [Display(Name = "Kategoria")]
        public Category Category { get; set; }*/
        public ICollection<ProductCategory> ProductCategory { get; set; }

    }
}
