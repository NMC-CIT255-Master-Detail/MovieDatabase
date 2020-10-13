using System;
using System.ComponentModel.DataAnnotations;

namespace MovieDatabase.Domain.Models
{
    public class Producer : DomainObject
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string Biography { get; set; }
    }
}