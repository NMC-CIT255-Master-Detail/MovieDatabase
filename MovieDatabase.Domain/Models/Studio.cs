using System.ComponentModel.DataAnnotations;

namespace MovieDatabase.Domain.Models
{
    public class Studio : DomainObject
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required, MaxLength(14)]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Website { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required, MaxLength(5)]
        public int Zipcode { get; set; }
    }
}