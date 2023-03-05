using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChineseLMS.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ChineseLMS.Models
{
    public class CourseMessage
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CourseMessageID { get; set; }

        //[ForeignKey("Course")]
        //public int CourseID { get; set; }

        public virtual Course Course { get; set; }

        [Required(ErrorMessage="Course Name is required")]
        [ForeignKey("Course")]
        [Display(Name = "Course")]
        public int CourseID { get; set; }

        //[ForeignKey("Instructor")]
        //[Required]
        //public virtual Instructor Instructor { get; set; }

        [Required(ErrorMessage = "Instructor Name is required.")]
        [ForeignKey("Instructor")]
        [Display(Name = "Sender")]
        public int InstructorID { get; set; }

        [StringLength(50, MinimumLength = 5, ErrorMessage = "Must be between {2} and {1} characters")]
        [Required(ErrorMessage = "Message title is required.")]
        [Display(Name = "Title")]
        public string MessageTitle { get; set; }

        [Required(ErrorMessage ="Message content is required.")]
        [StringLength(500, MinimumLength = 11, ErrorMessage = "Must be between 3 and {1} characters")]
        [Display(Name = "Details")]
        public string MessageContent { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Create Date")]
        public DateTime MessageCreateDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Edit Date")]
        public DateTime MessageEditDate { get; set; }

        //public ICollection<Course> Courses { get; set; }
        //public ICollection<Instructor> Instructors { get; set; }

        
    }
}

