using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChineseLMS.Models
{
    public class Module
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ModuleID { get; set; }

        public int CourseID { get; set; }

        public int Year { get; set; }
    }
}