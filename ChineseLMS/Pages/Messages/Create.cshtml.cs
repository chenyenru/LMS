using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ChineseLMS.Data;
using ChineseLMS.Models;
using ChineseLMS.Models.SchoolViewModels;  // Add VM
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;



namespace ChineseLMS.Pages.Messages
{
    public class CreateModel : PageModel
    {
        private readonly ChineseLMS.Data.SchoolContext _context;

        public CreateModel(ChineseLMS.Data.SchoolContext context)
        {
            _context = context;
        }

        public InstructorIndexData InstructorData { get; set; }
        public int InstructorID { get; set; }
        public int CourseID { get; set; }


        // OnGet()
        public async Task OnGet(int? id, int? courseID)
        {
            //PopulateInstructorDropDownList(_context);
            //PopulateCoursesDropDownList(_context);
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "FullName");
            ViewData["InstructorID"] = new SelectList(_context.Instructors, "ID", "FullName");

            InstructorData = new InstructorIndexData();
            InstructorData.Instructors = await _context.Instructors
                .Include(i => i.OfficeAssignment)
                .Include(i => i.Courses)
                    .ThenInclude(c => c.Department)
                .OrderBy(i => i.LastName)
                .ToListAsync();

            // occurs when an instructor is selected
            if (id != null)
            {
                InstructorID = id.Value;
                Instructor instructor = InstructorData.Instructors
                    .Where(i => i.ID == id.Value).Single();
                InstructorData.Courses = instructor.Courses;
            }

            // populates the enrollment model when a course is selected
            if (courseID != null)
            {
                CourseID = courseID.Value;
                var selectedCourse = InstructorData.Courses
                    .Where(x => x.CourseID == courseID).Single();
                await _context.Entry(selectedCourse)
                              .Collection(x => x.Enrollments).LoadAsync();
                foreach (Enrollment enrollment in selectedCourse.Enrollments)
                {
                    await _context.Entry(enrollment).Reference(x => x.Student).LoadAsync();
                }
                InstructorData.Enrollments = selectedCourse.Enrollments;
            }
        }

        [BindProperty]
        public CourseMessage CourseMessage { get; set; }



        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //CourseMessages.Instructor = 
            if (!ModelState.IsValid)
            {
                System.Diagnostics.Debug.WriteLine("The Data Model is Invalid");
                return Page();
            }
            else
            {
                var emptyMessage = new CourseMessage();

                emptyMessage.MessageCreateDate = DateTime.Now;
                emptyMessage.MessageEditDate = DateTime.Now;



                if (await TryUpdateModelAsync<CourseMessage>(
                 emptyMessage,
                 "coursemessage",   // Prefix for form value.
                 s => s.InstructorID, s => s.CourseID, s => s.MessageTitle, s => s.MessageContent, s => s.MessageCreateDate, s => s.MessageEditDate, s => s.CourseMessageID))
                {
                    _context.CourseMessages.Add(emptyMessage);
                    await _context.SaveChangesAsync();
                    Debug.WriteLine("Message Creation Date: " + emptyMessage.MessageCreateDate);
                    Debug.WriteLine("Message Edit Date: " + emptyMessage.MessageEditDate);
                    Debug.WriteLine("IntructorID: " + emptyMessage.InstructorID);
                    Debug.WriteLine("We've passed the model save changes async phase");
                    return RedirectToPage("./Index");
                }



                return Page();
            }



            //// Select DepartmentID if TryUpdateModelAsync fails.
            //PopulateDepartmentsDropDownList(_context, emptyCourse.DepartmentID);
            //return Page


            //_context.CourseMessages.Add(CourseMessages);
            //await _context.SaveChangesAsync();

            //return RedirectToPage("./Index");
        }

        //public void OnPostSubmit(string TextAreaContent)
        //{
        //    this.TextAreaContent = TextAreaContent;
        //}


    }
}
