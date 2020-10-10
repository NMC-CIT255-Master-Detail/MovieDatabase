using System;

namespace MovieDatabase.Domain.Models
{
    public class Movie : DomainObject
    {
        public DateTime _releaseDate;
        public int _runTime;
        public string _description;
        public string _imdbLink;
        public int _studioId;
        public int _producerId;

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

        public int StudioId
        {
            get => _studioId;
            set
            {
                _studioId = value;
                OnPropertyChanged(nameof(StudioId));
            }
        }

        public int ProducerId
        {
            get => _producerId;
            set
            {
                _producerId = value;
                OnPropertyChanged(nameof(ProducerId));
            }
        }

        public Studio Studio { get; set; }
        public Producer Producer { get; set; }
    }
}