using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChineseLMS.Data;
using ChineseLMS.Models;

namespace ChineseLMS.Pages.Messages
{
    public class EditModel : PageModel
    {
        private readonly ChineseLMS.Data.SchoolContext _context;

        public EditModel(ChineseLMS.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CourseMessage CourseMessage { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CourseMessages == null)
            {
                return NotFound();
            }

            var coursemessage = await _context.CourseMessages
                .FirstOrDefaultAsync(m => m.CourseMessageID == id);
            if (coursemessage == null)
            {
                return NotFound();
            }
            CourseMessage = coursemessage;

            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "FullName");
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "ID", "FullName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var currentCourseMessage = await _context.CourseMessages.FindAsync(id);
            currentCourseMessage.MessageEditDate = DateTime.Now;

            if (await TryUpdateModelAsync<CourseMessage>(
                 currentCourseMessage,
                 "CourseMessage",   // Prefix for form value.
                 s => s.MessageTitle, s => s.MessageContent, s => s.CourseID, s=>s.MessageEditDate))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                } catch (DbUpdateConcurrencyException)
                {
                    if (!CourseMessageExists(CourseMessage.CourseMessageID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            //_context.Attach(CourseMessage).State = EntityState.Modified;

           
            //try
            //{
            //    await _context.SaveChangesAsync();
            //}

            return RedirectToPage("./Index");
        }

        private bool CourseMessageExists(int id)
        {
            return _context.CourseMessages.Any(e => e.CourseMessageID == id);
        }
    }
}
