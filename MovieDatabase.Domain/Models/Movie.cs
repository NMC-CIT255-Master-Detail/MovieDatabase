using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDatabase.Domain.Models
{
    public class Movie : DomainObject
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Runtime { get; set; }
        public string Description { get; set; }
        public string IMDBLink { get; set; }
        public byte[] Image { get; set; }
        public virtual Studio Studio { get; set; }
        public virtual Producer Producer { get; set; }
    }
}
