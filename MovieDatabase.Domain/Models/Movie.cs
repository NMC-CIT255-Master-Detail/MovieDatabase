using System;
using System.ComponentModel.DataAnnotations;

namespace MovieDatabase.Domain.Models
{
    public class Movie : DomainObject
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public int Runtime{ get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string IMDBLink { get; set; }
        [Required]
        public int StudioId { get; set; }
        [Required]
        public int ProducerId { get; set; }
        [Required]
        public Studio Studio { get; set; }
        public Producer Producer { get; set; }
    }
}