using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ChineseLMS.Data;
using ChineseLMS.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChineseLMS.Pages.Calendar
{
    public class IndexModel : PageModel
    {
        private readonly ChineseLMS.Data.SchoolContext _context;

        public IndexModel(ChineseLMS.Data.SchoolContext context)
        {
            _context = context;
        }
        public IList<SchoolAssignment> SchoolAssignments { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.SchoolAssignments != null)
            {
                SchoolAssignments = await _context.SchoolAssignments.ToListAsync();

                Console.WriteLine("BELOW ARE THE JSONs \n");
                foreach (var assignment in SchoolAssignments)
                {
                    Console.WriteLine(assignment.JSONString + ",");
                }

            }
        }
    }
}
