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

        #region Fields

        IDataService<Studio> _studioRepo;
        string _name;
        private string _phone;
        private string _email;
        private string _website;
        private string _description;
        private string _address;
        private string _city;
        private string _state;
        private int? _zipcode;
        string _message;
        Studio _selectedStudio;

        #endregion

        #region Properties

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }


        public string Phone
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

        public Studio SelectedStudio
        {
            get => _selectedStudio;
            set
            {
                _selectedStudio = value;
                OnPropertyChanged(nameof(SelectedStudio));
            }
        }

        #endregion

        #region ICommands

        public ICommand SaveButtonCommand => new RelayCommand(SaveButton);

        #endregion

        #region Constructor

        public StudioViewModel(IDataService<Studio> studioRepo)
        {
            _studioRepo = studioRepo;
            _selectedStudio = HomeViewModel.Selection.Studio;

            if (HomeViewModel.ActionToTake == HomeViewModel.Action.EDIT)
            {
                Name = _selectedStudio.Name;
                Phone = _selectedStudio.Phone;
                Email = _selectedStudio.Email;
                Website = _selectedStudio.Website;
                Description = _selectedStudio.Description;
                Address = _selectedStudio.Address;
                City = _selectedStudio.City;
                State = _selectedStudio.State;
                Zipcode = _selectedStudio.Zipcode;
            }

        }

        #endregion

        #region Methods

        private void SaveButton()
        {
            if (HomeViewModel.ActionToTake == HomeViewModel.Action.EDIT)
            {
                Studio studioToUpdate = new Studio();
                studioToUpdate.Name = _name;
                studioToUpdate.Phone = _phone;
                studioToUpdate.Email = _email;
                studioToUpdate.Website = _website;
                studioToUpdate.Description = _description;
                studioToUpdate.Address = _address;
                studioToUpdate.City = _city;
                studioToUpdate.State = _state;
                studioToUpdate.Zipcode = (int)_zipcode;
                UpdateToDB(studioToUpdate);
            }
            else
            {
                if (Name != "" && Phone != "" && Email != "" && Website != "" && Description != "" && Address != "" && City != "" && State != "" && Zipcode != 0)
                {
                    Studio newStudioToAdd = new Studio();
                    newStudioToAdd.Name = _name;
                    newStudioToAdd.Phone = _phone;
                    newStudioToAdd.Email = _email;
                    newStudioToAdd.Website = _website;
                    newStudioToAdd.Description = _description;
                    newStudioToAdd.Address = _address;
                    newStudioToAdd.City = _city;
                    newStudioToAdd.State = _state;
                    newStudioToAdd.Zipcode = (int)_zipcode;
                    SaveToDB(newStudioToAdd);
                }
                else
                {
                    _message = "Some fileds are not filled in!";
                    MessageBox.Show(_message);
                }
            }
        }

        private void UpdateToDB(Studio studioToUpdate)
        {
            if (studioToUpdate != null)
            {
                _studioRepo.Update(_selectedStudio.Id, studioToUpdate);
                ResetForm();
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
            _message = "Successfully Added/Updated the Studio to the Database!";
            MessageBox.Show(_message);
        }

        #endregion

    }
}