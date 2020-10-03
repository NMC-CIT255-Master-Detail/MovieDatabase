using System;

namespace MovieDatabase.Domain.Models
{
    public class Producer : DomainObject
    {
        public string Name { get; set; }
        // TODO - Change DateTime to just Date for Producer
        public DateTime DOB { get; set; }
        public string Biography { get; set; }
    }
}
