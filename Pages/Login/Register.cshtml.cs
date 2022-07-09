using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Projekt_2.Models;
using Projekt_2.Data;
namespace Projekt_2.Pages.Login
{
    public class RegisterModel : PageModel
    {
        private readonly Projekt_2.Data.ProjectContext _context;

        public RegisterModel(Projekt_2.Data.ProjectContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }
        [BindProperty]
        public SiteUser SiteUser { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            SiteUser.Role = LoginDB.GetRole(SiteUser);
            /*if(LoginDB.GetLogin(SiteUser)==true)// istnieje taki u¿ytkownik
            {
                return Page();
                error = "Taki u¿ytkownik ju¿ istnieje!";
            }*/
            /*if (!ModelState.IsValid)
            {
                return Page();
            }*/
            
            
            SiteUser.password = Hash.HashPassword(SiteUser.password);
            SiteUser.confirmpassword = SiteUser.password;
            _context.SiteUser.Add(SiteUser);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Products/Index");
        }
    }
}
