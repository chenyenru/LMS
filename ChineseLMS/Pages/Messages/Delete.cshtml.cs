using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ChineseLMS.Data;
using ChineseLMS.Models;

namespace ChineseLMS.Pages.Messages
{
    public class DeleteModel : PageModel
    {
        private readonly ChineseLMS.Data.SchoolContext _context;

        public DeleteModel(ChineseLMS.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
      public CourseMessage CourseMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CourseMessages == null)
            {
                return NotFound();
            }

            var coursemessage = await _context.CourseMessages.FirstOrDefaultAsync(m => m.CourseMessageID == id);

            if (coursemessage == null)
            {
                return NotFound();
            }
            else 
            {
                CourseMessage = coursemessage;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.CourseMessages == null)
            {
                return NotFound();
            }
            var coursemessage = await _context.CourseMessages.FindAsync(id);

            if (coursemessage != null)
            {
                CourseMessage = coursemessage;
                _context.CourseMessages.Remove(CourseMessage);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
