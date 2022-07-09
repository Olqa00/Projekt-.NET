using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_2.Models
{
    public class SiteUser
    {
        [Key]
        [Display(Name = "Id")]
        [Required(ErrorMessage = "To pole jest obowiązkowe")]
        public int id { get; set; }
        [Display(Name = "Nazwa użytkownika")]
        [Required(ErrorMessage = "To pole jest obowiązkowe")]
        public string login { get; set; }
        [Display(Name = "Hasło")]
        [Required(ErrorMessage = "To pole jest obowiązkowe")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Display(Name = "Powtórz hasło")]
        [Required(ErrorMessage = "To pole jest obowiązkowe")]
        [DataType(DataType.Password)]
        [Compare("password",ErrorMessage ="Hasła muszą być takie same")]
        public string confirmpassword { get; set; }
        [Display(Name ="Imię")]
        [Required(ErrorMessage = "To pole jest obowiązkowe")]
        [RegularExpression(@"^[a-żA-Ż]+$", ErrorMessage="Wprowadz jedynie litery")]//walidacja
        public string firstName { get; set; }
        [Display(Name = "Nazwisko")]
        [Required(ErrorMessage = "To pole jest obowiązkowe")]
        [RegularExpression(@"^[a-żA-Ż]+$", ErrorMessage = "Wprowadz jedynie litery")]//walidacja
        public string lastName { get; set; }
        [Display(Name ="Rola")]
        [Required(ErrorMessage = "To pole jest obowiązkowe")]
        public string Role { get; set; }
        
    }
}
