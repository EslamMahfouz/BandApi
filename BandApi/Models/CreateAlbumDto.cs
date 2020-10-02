using BandApi.ValidationAttributes;
using System;

namespace BandApi.Models
{
    public class CreateAlbumDto : AlbumManipulationDto /*: IValidatableObject*/
    {
        [GuidRequired]
        public Guid BandId { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (Title == Description)
        //    {
        //        yield return new ValidationResult("Title and description need to be different", new[] { "CreateAlbumDto" });
        //    }
        //}
    }
}
