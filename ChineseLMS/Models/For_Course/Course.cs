using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ChineseLMS.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int CourseID { get; set; }

        [Required(ErrorMessage = "Course title is required.")]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }


        [Display(Name = "Course Full Name")]
        public string FullName
        {
            get
            {
                return CourseID + " " + Title;
            }
        }

        [Range(0, 5)]
        public int Credits { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }

        public int ModuleID { get; set; }

        public Department Department { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Instructor> Instructors { get; set; }
        public ICollection<SchoolAssignment> SchoolAssignments { get; set; }
        public ICollection<CourseTimeBlock> CourseTimeBlocks { get; set; }
        public ICollection<ResourceFile> ResourceFiles { get; set; }
        public ICollection<Module> Modules { get; set; }

        // Child CourseMessages
        public virtual ICollection<CourseMessage> CourseMessages { get; set; }

    }
}