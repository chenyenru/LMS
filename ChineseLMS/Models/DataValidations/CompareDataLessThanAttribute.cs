// Source code from https://www.codemag.com/Article/2301031/The-Rich-Set-of-Data-Annotation-and-Validation-Attributes-in-.NET
using System;
#nullable disable

using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace DataValidations;

public class CompareDateLessThanAttribute : ValidationAttribute
{
    public CompareDateLessThanAttribute(string propToCompare)
    {
        _propToCompare = propToCompare;
    }

    private readonly string _propToCompare;

    protected override ValidationResult IsValid(object value, ValidationContext vc)
    {
        if (value != null)
        {
            // Get value entered
            DateTime currentValue = (DateTime)value;

            // Get PropertyInfo for comparison property
            PropertyInfo pinfo = vc.ObjectType.GetProperty(_propToCompare);

            // Ensure the comparison property value is not null
            if (pinfo.GetValue(vc.ObjectInstance) != null)
            {
                // Get value for comparison property
                DateTime comparisonValue = (DateTime)pinfo.GetValue(vc.ObjectInstance);

                // Perform the comparison
                if (currentValue > comparisonValue)
                {
                    return new ValidationResult(ErrorMessage, new[] { vc.MemberName });
                }
            }
        }

        return ValidationResult.Success;
    }
}
