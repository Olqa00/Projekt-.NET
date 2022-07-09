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
    public class IndexModel : PageModel
    {
        private readonly Projekt_2.Data.ProjectContext _context;

        public IndexModel(Projekt_2.Data.ProjectContext context)
        {
            _context = context;
        }

        public IList<SiteUser> SiteUser { get;set; }

        public async Task OnGetAsync()
        {
            SiteUser = await _context.SiteUser.ToListAsync();
        }
    }
}
