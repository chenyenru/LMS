using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ChineseLMS.Data;
using ChineseLMS.Models;

namespace ChineseLMS.Pages.SchoolAssignments
{
    public class DeleteModel : PageModel
    {
        private readonly ChineseLMS.Data.SchoolContext _context;

        public DeleteModel(ChineseLMS.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SchoolAssignment SchoolAssignment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SchoolAssignments == null)
            {
                return NotFound();
            }

            var schoolassignment = await _context.SchoolAssignments.FirstOrDefaultAsync(m => m.ID == id);

            if (schoolassignment == null)
            {
                return NotFound();
            }
            else 
            {
                SchoolAssignment = schoolassignment;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.SchoolAssignments == null)
            {
                return NotFound();
            }
            var schoolassignment = await _context.SchoolAssignments.FindAsync(id);

            if (schoolassignment != null)
            {
                SchoolAssignment = schoolassignment;
                _context.SchoolAssignments.Remove(SchoolAssignment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
