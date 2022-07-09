using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projekt_2.Data;
using Projekt_2.Models;

namespace Projekt_2.Pages.Users
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly Projekt_2.Data.ProjectContext _context;

        public DeleteModel(Projekt_2.Data.ProjectContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SiteUser = await _context.SiteUser.FindAsync(id);

            if (SiteUser != null)
            {
                _context.SiteUser.Remove(SiteUser);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
