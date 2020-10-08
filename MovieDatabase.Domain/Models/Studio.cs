namespace MovieDatabase.Domain.Models
{
    public class Studio : DomainObject
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
    }
}