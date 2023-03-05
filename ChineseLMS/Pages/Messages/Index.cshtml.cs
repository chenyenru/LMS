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
using System.Diagnostics;

namespace ChineseLMS.Pages.Messages
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
        public string ClassSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<CourseMessage> CourseMessage { get; set; } = default!;
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

            IQueryable<CourseMessage> coursemessagesIQ = from s in _context.CourseMessages
                                                         select s;

            ViewData["DistinctCourseMessage"] = _context.CourseMessages
                .GroupBy(p => p.CourseID)
                .Select(g => g.First())
                .ToList();

             


            if (!String.IsNullOrEmpty(searchString))
            {
                /* The Where clause selects only students 
                 * whose first name or last name contains the search string.
                 * The LINQ statement is executed only if there's a value to search for.
                 */
                coursemessagesIQ = coursemessagesIQ.Where(s => s.MessageTitle.ToLower().Contains((searchString).ToLower()) || s.MessageContent.ToLower().Contains(searchString.ToLower()) ||
                  s.CourseID.ToString().ToLower().Contains(searchString.ToLower())
                );
            }

            switch (sortOrder)
            {
                case "name_desc":
                    coursemessagesIQ = coursemessagesIQ.OrderByDescending(s => s.MessageTitle);
                    break;
                case "Date":
                    coursemessagesIQ = coursemessagesIQ.OrderBy(s => s.MessageCreateDate);
                    break;
                case "date_desc":
                    coursemessagesIQ = coursemessagesIQ.OrderByDescending(s => s.MessageCreateDate);
                    break;
                case "Class":
                    coursemessagesIQ = coursemessagesIQ.OrderBy(s => s.CourseID);
                    break;
                case "class_desc":
                    coursemessagesIQ = coursemessagesIQ.OrderByDescending(s => s.CourseID);
                    break;
                default:
                    coursemessagesIQ = coursemessagesIQ.OrderBy(s => s.CourseMessageID);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 3);
            CourseMessage = await PaginatedList<CourseMessage>.CreateAsync(
                coursemessagesIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}

