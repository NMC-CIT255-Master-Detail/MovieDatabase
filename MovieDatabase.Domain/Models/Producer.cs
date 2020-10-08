using System;

namespace MovieDatabase.Domain.Models
{
    public class Producer : DomainObject
    {
        public string Name { get; set; }

        public DateTime DOB { get; set; }
        public string Biography { get; set; }
    }
}