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

namespace Projekt_2.Pages.ProductCategories
{
    [Authorize(Roles = "Employee, Admin")]
    public class EditModel : PageModel
    {
        private readonly Projekt_2.Data.ProjectContext _context;

        public EditModel(Projekt_2.Data.ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ProductCategory ProductCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductCategory = await _context.ProductCategory
                .Include(p => p.Categories)
                .Include(p => p.Products).FirstOrDefaultAsync(m => m.id == id);

            if (ProductCategory == null)
            {
                return NotFound();
            }
           ViewData["categoryID"] = new SelectList(_context.Category, "ID", "name");
           ViewData["productID"] = new SelectList(_context.Product, "id", "name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ProductCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductCategoryExists(ProductCategory.id))
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

        private bool ProductCategoryExists(int id)
        {
            return _context.ProductCategory.Any(e => e.id == id);
        }
    }
}
