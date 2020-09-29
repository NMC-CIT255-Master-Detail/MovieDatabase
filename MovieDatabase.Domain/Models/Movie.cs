using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDatabase.Domain.Models
{
    public class Movie : DomainObject
    {
        public DateTime _releaseDate;
        //public int _runTime;
        //public string _description;
        //public string _imdbLink;
        //public byte[] _image;

        public string Title { get; set; }
        // TODO - Change DateTime to just Date for the Movies
        public DateTime ReleaseDate
        {
            get => _releaseDate;
            set
            {
                _releaseDate = value;
                
            }
        }
        public int Runtime { get; set; }
        public string Description { get; set; }
        public string IMDBLink { get; set; }
        public byte[] Image { get; set; }
        public virtual Studio Studio { get; set; }
        public virtual Producer Producer { get; set; }
    }
}
