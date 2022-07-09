using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projekt_2.Data;
using Projekt_2.Models;

namespace Projekt_2.Pages.Users
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly Projekt_2.Data.ProjectContext _context;

        public CreateModel(Projekt_2.Data.ProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public SiteUser SiteUser { get; set; }
        
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }
            SiteUser.password = Hash.HashPassword(SiteUser.password);
            SiteUser.confirmpassword = SiteUser.password;
            _context.SiteUser.Add(SiteUser);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
