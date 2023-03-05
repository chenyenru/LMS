using System;
using System.ComponentModel.DataAnnotations;

namespace ChineseLMS.Models.DataValidations
{
	public class ValidateDateRange_Instructor_HireDate : ValidationAttribute
	{
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dt = (DateTime)value;


            if (!(dt >= DateTime.Now.AddYears(-40)))
            {
                return new ValidationResult("Only student enrolled in the past 40 years can be added.");
            }
            else if (!(dt <= DateTime.Now.AddYears(2)))
            {
                return new ValidationResult("Only future student within 2 years can be added.");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}

