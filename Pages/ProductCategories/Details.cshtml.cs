﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Projekt_2.Data;
using Projekt_2.Models;

namespace Projekt_2.Pages.ProductCategories
{
    [Authorize(Roles = "Employee, Admin")]
    public class DetailsModel : PageModel
    {
        private readonly Projekt_2.Data.ProjectContext _context;

        public DetailsModel(Projekt_2.Data.ProjectContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
