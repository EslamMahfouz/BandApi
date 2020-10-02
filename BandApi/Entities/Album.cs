using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BandApi.Entities
{
    public class Album
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }


        [ForeignKey("BandId")]
        public Band Band { get; set; }
        public Guid BandId { get; set; }

    }
}
