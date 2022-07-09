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

namespace Projekt_2.Pages.Categories
{
    [Authorize(Roles = "Employee, Admin")]
    public class DeleteModel : PageModel
    {
        private readonly Projekt_2.Data.ProjectContext _context;

        public DeleteModel(Projekt_2.Data.ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Category.FirstOrDefaultAsync(m => m.ID == id);

            if (Category == null)
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

            Category = await _context.Category.FindAsync(id);

            if (Category != null)
            {
                _context.Category.Remove(Category);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
