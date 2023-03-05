using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ChineseLMS.Data;
using ChineseLMS.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ChineseLMS.Pages.SchoolAssignments
{
    public class IndexModel : PageModel
    {
        private readonly ChineseLMS.Data.SchoolContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(ChineseLMS.Data.SchoolContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        
        public PaginatedList<SchoolAssignment> SchoolAssignments { get; set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            ViewData["CourseID"] = new SelectList(_context.Courses, "CourseID", "FullName");
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<SchoolAssignment> schoolassignmentsIQ = from s in _context.SchoolAssignments
                                             select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                /* The Where clause selects only students 
                 * whose first name or last name contains the search string.
                 * The LINQ statement is executed only if there's a value to search for.
                 */
                schoolassignmentsIQ = schoolassignmentsIQ.Where(s => s.Title.ToLower().Contains((searchString).ToLower()) || s.SchoolAssignmentDetails.ToLower().Contains(searchString.ToLower()) ||
                  s.CourseID.ToString().ToLower().Contains(searchString.ToLower()));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    schoolassignmentsIQ = schoolassignmentsIQ.OrderByDescending(s => s.Title);
                    break;
                case "Date":
                    schoolassignmentsIQ = schoolassignmentsIQ.OrderBy(s => s.TaskDueStartTime);
                    break;
                case "date_desc":
                    schoolassignmentsIQ = schoolassignmentsIQ.OrderByDescending(s => s.TaskDueStartTime);
                    break;
                case "Class":
                    schoolassignmentsIQ = schoolassignmentsIQ.OrderBy(s => s.CourseID);
                    break;
                case "class_desc":
                    schoolassignmentsIQ = schoolassignmentsIQ.OrderByDescending(s => s.CourseID);
                    break;
                default:
                    schoolassignmentsIQ = schoolassignmentsIQ.OrderBy(s => s.Title);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 2);
            SchoolAssignments = await PaginatedList<SchoolAssignment>.CreateAsync(
                schoolassignmentsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
