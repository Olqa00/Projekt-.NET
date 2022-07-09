using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projekt_2.Data;
using Projekt_2.Models;
using Projekt_2.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace Projekt_2.Pages.Products
{
    public class DetailsModel : MyPageModel
    {
        private readonly Projekt_2.Data.ProjectContext _context;

        public DetailsModel(Projekt_2.Data.ProjectContext context)
        {
            _context = context;
        }
        public Product Product { get; set; }
        
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }
            LoadDB();
            Product = await _context.Product
                .Include(p => p.ProductType).FirstOrDefaultAsync(m => m.id == id);
            SaveDB();
            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
        
        public void OnPost()
        {
            SaveDB();
        }
    }
}
