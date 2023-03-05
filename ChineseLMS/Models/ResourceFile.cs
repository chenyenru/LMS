using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace ChineseLMS.Models
{
    public class ResourceFile
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ResourceFileID { get; set; }

        // Foreign Key to [Student]
        //[ForeignKey("Course")]
        //public int CourseID { get; set; }

        //public Course Course { get; set; }

        [ForeignKey("SchoolAssignment")]
        public int SchoolAssignmentID { get; set; }

        [ForeignKey("Student")]
        public int StudentID { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FileSubmissionDate { get; set; }

        public bool IsFileStillSubmitted;
    }
}

