using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CRUD.Data;
using CRUD.Models;

namespace CRUD.Pages_Premiums
{
    public class IndexModel : PageModel
    {
        private readonly CRUD.Data.ApplicationDbContext _context;

        public IndexModel(CRUD.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Premium> Premium { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Premiums != null)
            {
                Premium = await _context.Premiums
                .Include(p => p.Student).ToListAsync();
            }
        }
    }
}
