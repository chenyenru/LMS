using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using DataValidations;

namespace ChineseLMS.Models
{
    public class SchoolAssignment
    {
        [JsonPropertyName("id")]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key] //SchoolAssignmentID
        public int ID { get; set; }

        // This is used to link the task with the course
        [JsonIgnore]
        public int CourseID { get; set; }

        [JsonPropertyName("title")]
        [Required]
        [StringLength(80, MinimumLength = 5, ErrorMessage = "Must be between {2} and {1} characters")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        // Makes this field required
        [JsonIgnore]
        [Required(ErrorMessage = "Assignment Details is required")]
        [StringLength(3000, MinimumLength = 12, ErrorMessage = "Please keep the task description between 5 and 1000 characters (including space)!")]
        // Map to the "FirstName" column in the database
        [Column("Task Details")]
        [Display(Name = "Details")]
        public string SchoolAssignmentDetails { get; set; }

        [Required]
        [JsonIgnore]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Creation Date")]
        public DateTime TaskCreateDate { get; set; }

        [Required]
        [JsonPropertyName("start")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Time")]
        [ValidateDateRange(ErrorMessage = "The date should be within a year")]
        [CompareDateLessThanAttribute(nameof(TaskDueEndTime), ErrorMessage = "Start must be less End Time")]
        public DateTime TaskDueStartTime { get; set; }

        [Required]
        [JsonPropertyName("end")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Time")]
        [ValidateDateRange(ErrorMessage = "The date should be within a year")]
        public DateTime TaskDueEndTime { get; set; }

        [JsonPropertyName("allDay")]
        public bool AllDay { get; set; }

        internal static IQueryable<SchoolAssignment> AsNoTracking()
        {
            throw new NotImplementedException();
        }

        [JsonIgnore]
        public string JSONString { get; set; }

        public virtual ICollection<Todo> Todos { get; set; }
        public virtual ICollection<ResourceFile> ResourceFiles { get; set; }

    }
}