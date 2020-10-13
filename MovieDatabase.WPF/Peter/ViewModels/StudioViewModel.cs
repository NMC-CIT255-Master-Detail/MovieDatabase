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

        IDataService<Studio> _studioRepo;

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
        public ICommand ResetFormCommand => new RelayCommand(ResetForm);

        #endregion

        #region Constructor

        public StudioViewModel(IDataService<Studio> studioRepo)
        {
            _studioRepo = studioRepo;


            if (HomeViewModel.ActionToTake == HomeViewModel.Action.EDIT)
            {
                _selectedStudio = HomeViewModel.Selection.Studio;
                SetSelectedData();
            }
        }

        #endregion

        #region Methods

        private void SaveButton()
        {
            if (HomeViewModel.ActionToTake == HomeViewModel.Action.EDIT)
            {
                Studio studioToUpdate = new Studio() 
                {
                    Name = _name,
                    Phone = _phone,
                    Email = _email,
                    Website = _website,
                    Description = _description,
                    Address = _address,
                    City = _city,
                    State = _state,
                    Zipcode = (int)_zipcode
                };
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
                    string title = "Blank Fields ERROR";
                    MessageBox.Show(_message, title);
                }
            }
        }

        private void UpdateToDB(Studio studioToUpdate)
        {
            if (studioToUpdate != null)
            {
                _studioRepo.Update(_selectedStudio.Id, studioToUpdate);
                ResetFormAfterAdd();
            }
        }

        private void SaveToDB(Studio newStudioToAdd)
        {
            if (newStudioToAdd != null)
            {
                _studioRepo.Create(newStudioToAdd);
                ResetFormAfterAdd();
            }
        }

        private void ResetFormAfterAdd()
        {
            ResetData();
            _message = "Successfully Added/Updated the Studio to the Database!";
            string title = "SUCCESS";
            MessageBox.Show(_message, title);
        }

        private void ResetForm()
        {
            string title = "Reset Form";
            string message = "Are you sure you want to reset the form?";
            MessageBoxButton buttons = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show(message, title, buttons);

            if (result == MessageBoxResult.Yes)
            {
                if (HomeViewModel.ActionToTake == HomeViewModel.Action.EDIT)
                {
                    SetSelectedData();
                }
                else
                {
                    ResetData();
                }
            }
        }

        private void SetSelectedData()
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

        void ResetData()
        {
            Name = "";
            Phone = "";
            Email = "";
            Website = "";
            Description = "";
            Address = "";
            City = "";
            State = "";
            Zipcode = null;
        }
        #endregion

    }
}