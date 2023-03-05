using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataValidations;

namespace ChineseLMS.Models
{
    public class Student
    {
        public int ID { get; set; }


        [Required(ErrorMessage = "Last name is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Must be between {2} and {1} characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        //// Makes this field required
        //[Required(ErrorMessage = "First name is required")]
        //[StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        //public string FirstName { get; set; }

        // Map to the "FirstName" column in the database
        [Column("FirstName")]
        [Display(Name = "First Name")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Must be between {2} and {1} characters")]
        public string FirstMidName { get; set; }
        /*The DataType attribute specifies a data type that's more specific than the database intrinsic type. 
        In this case only the date should be displayed, not the date and time. 
        The DataType Enumeration provides for many data types, 
            such as Date, Time, PhoneNumber, Currency, EmailAddress, etc. 
        The DataType attribute can also enable the app to automatically provide type-specific features. 
        For example:
            The mailto: link is automatically created for DataType.EmailAddress.
            The date selector is provided for DataType.Date in most browsers.
*/

        [Range(minimum:2017, maximum:2050, ErrorMessage = "Class Year should be between {1} and {2}")]
        [Column("ClassOf")]
        [Display(Name = "Class Of")]
        public int ClassOf { get; set; }

        [Required(ErrorMessage = "Enrollment date is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date")]
        [ValidateDateRange_Student_Enrollment]
        public DateTime EnrollmentDate { get; set; }


        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }

        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<ResourceFile> ResourceFiles { get; set; }


    }
}