using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BandApi.Models
{
    public class CreateBandDto
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }
        public DateTime Founded { get; set; }

        [Required, MaxLength(20)]
        public string MainGenre { get; set; }
        public List<CreateAlbumDto> Albums { get; set; } = new List<CreateAlbumDto>();
    }
}
