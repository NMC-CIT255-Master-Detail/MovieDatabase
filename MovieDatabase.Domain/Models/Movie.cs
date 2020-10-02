using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDatabase.Domain.Models
{
    public class Movie : DomainObject
    {
        public DateTime _releaseDate;
        public int _runTime;
        public string _description;
        public string _imdbLink;
        public byte[] _image;

        public string Title { get; set; }

        public DateTime ReleaseDate
        {
            get => _releaseDate;
            set
            {
                _releaseDate = value;
                OnPropertyChanged(nameof(ReleaseDate));
            }
        }

        public int Runtime 
        {
            get => _runTime;
            set 
            {
                _runTime = value;
                OnPropertyChanged(nameof(Runtime));
            }
        }

        public string Description 
        {
            get => _description;
            set 
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public string IMDBLink 
        {
            get => _imdbLink;
            set 
            {
                _imdbLink = value;
                OnPropertyChanged(nameof(IMDBLink));
            }
        }
        public byte[] Image 
        {
            get => _image;
            set 
            {
                _image = value;
                OnPropertyChanged(nameof(Image));
            }
        }
        public virtual Studio Studio 
        {
            get;
            set;
        }
        public virtual Producer Producer 
        { 
            get;
            set;
        }
    }
}
