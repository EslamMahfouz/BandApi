using BandApi.Models;
using System.ComponentModel.DataAnnotations;

namespace BandApi.ValidationAttributes
{
    public class TitleAndDescriptionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var album = (AlbumManipulationDto)validationContext.ObjectInstance;
            return album.Title == album.Description
                ? new ValidationResult("Title and description need to be different", new[] { "AlbumManipulationDto" })
                : ValidationResult.Success;
        }
    }
}
