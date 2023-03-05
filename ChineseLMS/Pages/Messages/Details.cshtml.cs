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
    public class DetailsModel : PageModel
    {
        private readonly ChineseLMS.Data.SchoolContext _context;

        public DetailsModel(ChineseLMS.Data.SchoolContext context)
        {
            _context = context;
        }

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
    }
}
