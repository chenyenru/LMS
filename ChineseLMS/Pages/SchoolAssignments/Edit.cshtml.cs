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

namespace ChineseLMS.Pages.SchoolAssignments
{
    public class EditModel : PageModel
    {
        private readonly ChineseLMS.Data.SchoolContext _context;

        public EditModel(ChineseLMS.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SchoolAssignment SchoolAssignment { get; set; } = default!;


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SchoolAssignments == null)
            {
                return NotFound();
            }

            var schoolassignment =  await _context.SchoolAssignments.FirstOrDefaultAsync(m => m.ID == id);
            if (schoolassignment == null)
            {
                return NotFound();
            }
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "FullName");
            SchoolAssignment = schoolassignment;

            var SpecificTodos = _context.Todos
                .Where(p => p.SchoolAssignmentID == schoolassignment.ID)
                .Include(p => p.SchoolAssignment)
                .Select(p => new { p.ID, p.TodoName, p.Checked, p.ByTeacher })
                .ToList();
            ViewData["SpecificTodos"] = SpecificTodos;

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

                Console.WriteLine("The form is invalid!");
                return Page();
            }

            var currentSchoolAssignment = await _context.SchoolAssignments.FindAsync(id);

            if (await TryUpdateModelAsync<SchoolAssignment>(
                 currentSchoolAssignment,
                 "SchoolAssignment",   // Prefix for form value.
                 s => s.Title, s => s.SchoolAssignmentDetails, s => s.CourseID, s => s.TaskDueStartTime, s => s.TaskDueEndTime))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SchoolAssignmentExists(SchoolAssignment.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }



            _context.Attach(SchoolAssignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchoolAssignmentExists(SchoolAssignment.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            var schoolassignment = await _context.SchoolAssignments.FirstOrDefaultAsync(m => m.ID == id);
            var SpecificTodos = _context.Todos
                .Where(p => p.SchoolAssignmentID == schoolassignment.ID)
                .Include(p => p.SchoolAssignment)
                .Select(p => new { p.ID, p.TodoName, p.Checked, p.ByTeacher })
                .ToList();
            ViewData["SpecificTodos"] = SpecificTodos;

            return RedirectToPage("./Index");
        }

        private bool SchoolAssignmentExists(int id)
        {
          return _context.SchoolAssignments.Any(e => e.ID == id);
        }
    }
}
