using BandApi.ValidationAttributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace BandApi.Models
{
    [TitleAndDescription(ErrorMessage = "title and description need to be different")]
    public abstract class AlbumManipulationDto
    {
        [Required(ErrorMessage = "title need to be filled in"), MaxLength(50, ErrorMessage = "max length is 50")]
        public string Title { get; set; }

        [MaxLength(100, ErrorMessage = "max length is 100")]
        public virtual string Description { get; set; }

        [Required(ErrorMessage = "release date is required")]
        public DateTime ReleaseDate { get; set; }

    }
}
