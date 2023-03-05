using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ChineseLMS.Data;
using ChineseLMS.Models;

namespace ChineseLMS.Pages.Todos
{
    public class CreateModel : PageModel
    {
        private readonly ChineseLMS.Data.SchoolContext _context;

        public CreateModel(ChineseLMS.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["SchoolAssignmentID"] = new SelectList(_context.SchoolAssignments, "ID", "Title");
            return Page();
        }

        [BindProperty]
        public Todo Todo { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Todos.Add(Todo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
