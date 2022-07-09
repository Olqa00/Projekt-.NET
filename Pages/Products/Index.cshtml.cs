using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projekt_2.Data;
using Projekt_2.Models;

namespace Projekt_2.Pages.Products
{
    [Authorize(Roles = "Employee, Admin")]
    public class IndexModel : PageModel
    {
        private readonly Projekt_2.Data.ProjectContext _context;

        public IndexModel(Projekt_2.Data.ProjectContext context)
        {
            _context = context;
        }
        
        public IList<Product> Product { get;set; }
        public IList<Category> Category { get; set; }
        public async Task OnGetAsync()
        {
            
            Product = await _context.Product
                .Include(p => p.ProductType).ToListAsync();
            Product = await _context.Product
                .Include(p => p.ProductCategory).ToListAsync();
        }
    }
}
