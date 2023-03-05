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
    public class DetailsModel : PageModel
    {
        private readonly ChineseLMS.Data.SchoolContext _context;

        public DetailsModel(ChineseLMS.Data.SchoolContext context)
        {
            _context = context;
        }

        public SchoolAssignment SchoolAssignment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.SchoolAssignments == null)
            {
                return NotFound();
            }

           

            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "Title");

            var schoolassignment = await _context.SchoolAssignments.FirstOrDefaultAsync(m => m.ID == id);

            var SpecificTodos = _context.Todos
                .Where(p=> p.SchoolAssignmentID == schoolassignment.ID)
                .Include(p => p.SchoolAssignment)
                .Select(p => new { p.ID, p.TodoName, p.Checked, p.ByTeacher})
                .ToList();
            ViewData["SpecificTodos"] = SpecificTodos;

            //var coursename = ViewData["CourseID"]
            //     .Where(x => x.CourseID == schoolassignment.CourseID).Select(x => x.FullName).First()

            //Create Linq statement to find the todos related to the school assignment

            if (schoolassignment == null)
            {
                return NotFound();
            }
            else 
            {
                SchoolAssignment = schoolassignment;
                //SpecificTodos = todos;
            }
            return Page();
        }


    }
}
