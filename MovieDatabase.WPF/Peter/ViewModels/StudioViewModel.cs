using MovieDatabase.Domain;
using MovieDatabase.Domain.Models;
using MovieDatabase.Domain.Services;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace MovieDatabase.WPF.Peter.ViewModels
{
    public class StudioViewModel : BaseViewModel
    {
        IDataService<Studio> _studioRepo;
        string _name;
        private long? _phone;
        private string _email;
        private string _website;
        private string _description;
        private string _address;
        private string _city;
        private string _state;
        private int? _zipcode;
        string _message;


        public string Name 
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        
        public long? Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }

        
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        
        public string Website
        {
            get
            {
                return _website;
            }
            set
            {
                _website = value;
                OnPropertyChanged(nameof(Website));
            }
        }

        
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        
        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
                OnPropertyChanged(nameof(City));
            }
        }

        
        public string State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
                OnPropertyChanged(nameof(State));
            }
        }

        
        public int? Zipcode
        {
            get
            {
                return _zipcode;
            }
            set
            {
                _zipcode = value;
                OnPropertyChanged(nameof(Zipcode));
            }
        }

        public ICommand SaveButtonCommand => new RelayCommand(SaveButton);


        public StudioViewModel(IDataService<Studio> studioRepo)
        {
            _studioRepo = studioRepo;
        }

        private void SaveButton()
        {
            if (Name != "" && Phone != 0 && Email != "" && Website != "" && Description != "" && Address != "" && City != "" && State != "" && Zipcode != 0)
            {
                Studio newStudioToAdd = new Studio();
                newStudioToAdd.Name = _name;
                newStudioToAdd.Phone = (long)_phone;
                newStudioToAdd.Email = _email;
                newStudioToAdd.Website = _website;
                newStudioToAdd.Description = _description;
                newStudioToAdd.Address = _address;
                newStudioToAdd.City = _city;
                newStudioToAdd.State = _state;
                newStudioToAdd.Zipcode = (int)_zipcode;
                SaveToDB(newStudioToAdd);
            } else
            {
                _message = "Some fileds are not filled in!";
                MessageBox.Show(_message);
            }
            
        }

        private void SaveToDB(Studio newStudioToAdd)
        {
            if (newStudioToAdd != null)
            {
                _studioRepo.Create(newStudioToAdd);
            }

            ResetForm();
            
        }

        private void ResetForm()
        {
            Name = "";
            Phone = null;
            Email = "";
            Website = "";
            Description = "";
            Address = "";
            City = "";
            State = "";
            Zipcode = null;
            _message = "Added the Studio to the Database!";
            MessageBox.Show(_message);
        }
    }
}