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
    public class DeleteModel : PageModel
    {
        private readonly ChineseLMS.Data.SchoolContext _context;

        public DeleteModel(ChineseLMS.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Todo Todo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Todos == null)
            {
                return NotFound();
            }

            var todo = await _context.Todos.FirstOrDefaultAsync(m => m.ID == id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Todos == null)
            {
                return NotFound();
            }
            var todo = await _context.Todos.FindAsync(id);

            if (todo != null)
            {
                Todo = todo;
                _context.Todos.Remove(Todo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
