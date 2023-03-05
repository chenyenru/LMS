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
    public class DetailsModel : PageModel
    {
        private readonly ChineseLMS.Data.SchoolContext _context;

        public DetailsModel(ChineseLMS.Data.SchoolContext context)
        {
            _context = context;
        }

      public Todo Todo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Todos == null)
            {
                return NotFound();
            }

            var todo = await _context.Todos
                .Include(t => t.SchoolAssignment)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (todo == null)
            {
                return NotFound();
            }
            else 
            {
                Todo = todo;
            }
            return Page();
        }
    }
}
