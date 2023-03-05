using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;


namespace ChineseLMS.Models
{
    public class CourseTimeBlock
    {
        [JsonPropertyName("id")]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key] //SchoolAssignmentID
        public int ID { get; set; }

        [JsonIgnore]
        public int CourseID { get; set; }

        public int TimeBlock { get; set; }
    }
}

