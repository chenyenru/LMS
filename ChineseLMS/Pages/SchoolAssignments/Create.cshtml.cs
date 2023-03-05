using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ChineseLMS.Data;
using ChineseLMS.Models;

namespace ChineseLMS.Pages.SchoolAssignments
{
    public class CreateModel : PageModel
    {
        private readonly ChineseLMS.Data.SchoolContext _context;

        public CreateModel(ChineseLMS.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SchoolAssignment schoolassignment { get; set; }

        public IActionResult OnGet()
        {
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "FullName");
            return Page();
        }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            schoolassignment.TaskCreateDate = DateTime.Now;

            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize<SchoolAssignment>(
                schoolassignment,
                options);
            schoolassignment.JSONString = jsonString;
            _context.SchoolAssignments.Add(schoolassignment);
            await _context.SaveChangesAsync();

            Console.WriteLine(String.Format("Below is the JSON String: {0}", schoolassignment.JSONString));

            return RedirectToPage("./Index");
        }
    }
}
