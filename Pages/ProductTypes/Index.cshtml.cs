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

namespace Projekt_2.Pages.ProductTypes
{
    [Authorize(Roles = "Employee, Admin")]
    public class IndexModel : PageModel
    {
        private readonly Projekt_2.Data.ProjectContext _context;

        public IndexModel(Projekt_2.Data.ProjectContext context)
        {
            _context = context;
        }

        public IList<ProductType> ProductType { get;set; }

        public async Task OnGetAsync()
        {
            ProductType = await _context.ProductType.ToListAsync();
        }
    }
}
