using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ChineseLMS.Data;
using ChineseLMS.Models;

namespace ChineseLMS.Pages.Todos
{
    public class IndexModel : PageModel
    {
        private readonly ChineseLMS.Data.SchoolContext _context;

        public IndexModel(ChineseLMS.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Todo> Todo { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Todos != null)
            {
                Todo = await _context.Todos
                .Include(t => t.SchoolAssignment).ToListAsync();
            }
        }
    }
}
