using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Projekt_2.Data;
using Projekt_2.Models;

namespace Projekt_2.Pages.Products
{
    [Authorize(Roles = "Employee, Admin")]
    public class CreateModel : PageModel
    {
        private readonly Projekt_2.Data.ProjectContext _context;

        public CreateModel(Projekt_2.Data.ProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["producttypeID"] = new SelectList(_context.ProductType, "id", "name");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; }
        int x;
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Product.link();
            _context.Product.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
