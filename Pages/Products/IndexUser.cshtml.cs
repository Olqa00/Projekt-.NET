using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projekt_2.Data;
using Projekt_2.Models;

namespace Projekt_2.Pages.Products
{
    public class IndexUserModel : PageModel
    {
        private readonly Projekt_2.Data.ProjectContext _context;

        public IndexUserModel(Projekt_2.Data.ProjectContext context)
        {
            _context = context;
        }
        
        public IList<Product> Product { get;set; }
        public IList<Category> Category { get; set; }
        public async Task OnGetAsync()
        {
            
            Product = await _context.Product
                .Include(p => p.ProductType).ToListAsync();
        }
    }
}
