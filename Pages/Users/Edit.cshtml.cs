using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projekt_2.Data;
using Projekt_2.Models;

namespace Projekt_2.Pages.Users
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly Projekt_2.Data.ProjectContext _context;

        public EditModel(Projekt_2.Data.ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SiteUser SiteUser { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SiteUser = await _context.SiteUser.FirstOrDefaultAsync(m => m.id == id);

            if (SiteUser == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            SiteUser.password = Hash.HashPassword(SiteUser.password);
            SiteUser.confirmpassword = SiteUser.password;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SiteUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SiteUserExists(SiteUser.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SiteUserExists(int id)
        {
            return _context.SiteUser.Any(e => e.id == id);
        }
    }
}
