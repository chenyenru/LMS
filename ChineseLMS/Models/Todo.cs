using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ChineseLMS.Models
{
	public class Todo
	{
        [JsonPropertyName("id")]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

		[Required(ErrorMessage = "Todo Name is required")]
        [Display(Name = "Todo Name")]
        public string TodoName { get; set; }


        [Required(ErrorMessage = "Enrollment date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Due Date")]
        public DateTime TodoDueDate { get; set; }

        //[Required(ErrorMessage = "An Attribution to School Assignment is required")]
        public int SchoolAssignmentID { get; set; }

        public bool Checked { get; set; }
        public bool ByTeacher { get; set; }

        [Display(Name = "Assignment")]
        public virtual SchoolAssignment SchoolAssignment { get; set; }



    }
}

