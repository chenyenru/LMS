using System.ComponentModel.DataAnnotations;

namespace DataValidations
{
    public class ValidateDateRange_Student_Enrollment : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dt = (DateTime)value;

            
            if (!(dt >= DateTime.Now.AddYears(-6)))
            {
                return new ValidationResult("Only student enrolled in the past 6 years can be added.");
            } else if (!(dt <= DateTime.Now.AddYears(2)))
            {
                return new ValidationResult("Only future student within 2 years can be added.");
            } else
            {
                return ValidationResult.Success;
            }
        }
    }
}