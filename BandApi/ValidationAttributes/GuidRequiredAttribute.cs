using System;
using System.ComponentModel.DataAnnotations;

namespace BandApi.ValidationAttributes
{
    public class GuidRequiredAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return (Guid)value == default(Guid)
                ? new ValidationResult($"{validationContext.MemberName} is required", new[] { validationContext.MemberName })
                : ValidationResult.Success;
        }
    }
}
