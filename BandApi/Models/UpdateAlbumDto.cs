using System;
using System.ComponentModel.DataAnnotations;

namespace BandApi.Models
{
    public class UpdateAlbumDto : AlbumManipulationDto
    {
        [Required(ErrorMessage = "album id is required")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "description in update is required")]
        public override string Description { get; set; }
    }
}
