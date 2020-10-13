using MovieDatabase.Domain;
using MovieDatabase.Domain.Models;
using MovieDatabase.Domain.Services;
using MovieDatabase.WPF.Peter.Commands;
using MovieDatabase.WPF.Peter.State.Navigator;
using MovieDatabase.WPF.Peter.ViewModels.ViewModelFactories;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace MovieDatabase.WPF.Peter.ViewModels
{
    public class ProducerViewModel : BaseViewModel
    {

        #region Fields

        private string _name;
        string _message;
        ObservableCollection<Producer> _producer;
        Producer _selectedProducer;
        IDataService<Producer> _producerRepo;

        #endregion

        #region Properties

        public ObservableCollection<Producer> Producer
        {
            get => _producer;
            set
            {
                _producer = value;
                OnPropertyChanged(nameof(Producer));
            }
        }


        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private DateTime? _dob;

        public DateTime? DOB
        {
            get => _dob;
            set
            {
                _dob = value;
                OnPropertyChanged(nameof(DOB));
            }
        }

        private string _bio;

        public string Biography
        {
            get => _bio;
            set
            {
                _bio = value;
                OnPropertyChanged(nameof(Biography));
            }
        }

        public Producer SelectedProducer
        {
            get => _selectedProducer;
            set
            {
                _selectedProducer = value;
                OnPropertyChanged(nameof(SelectedProducer));
            }
        }

        #endregion

        #region ICommands

        public ICommand SaveButtonCommand => new RelayCommand(SaveButton);
        public ICommand ResetFormCommand => new RelayCommand(ResetForm);

        #endregion

        #region Constructor

        public ProducerViewModel(IDataService<Producer> producerRepo)
        {
            _producerRepo = producerRepo;

            if (HomeViewModel.ActionToTake == HomeViewModel.Action.EDIT)
            {
                _selectedProducer = HomeViewModel.Selection.Producer;
                SetSelectedData();
            }
        }

        #endregion

        #region Methods

        void SaveButton()
        {
            if (HomeViewModel.ActionToTake == HomeViewModel.Action.EDIT)
            {
                if (Name != "" && DOB != null && Biography != "")
                {

                }
                Producer producerToUpdate = new Producer()
                {
                    Name = _name,
                    DOB = (DateTime)_dob,
                    Biography = _bio
                };
                UpdateToDB(producerToUpdate);
            }
            else
            {
                if (Name != "" && DOB != null && Biography != "")
                {
                    Producer newProducerToAdd = new Producer()
                    {
                        Name = _name,
                        DOB = (DateTime)_dob,
                        Biography = _bio
                    };
                    SaveToDB(newProducerToAdd);
                }
                else
                {
                    _message = "Sorry, but it looks like you didn't fill out all the fields";
                    string title = "Blank Fields ERROR";
                    MessageBox.Show(_message, title);
                }
            }
        }

        private void UpdateToDB(Producer producerToUpdate)
        {
            if (producerToUpdate != null)
            {
                _producerRepo.Update(_selectedProducer.Id, producerToUpdate);
                ResetFormAfterAdd();
            }
        }

        void SaveToDB(Producer producer)
        {
            if (producer != null)
            {
                _producerRepo.Create(producer);
                ResetFormAfterAdd();
            }
        }

        void ResetFormAfterAdd()
        {
            ResetData();
            _message = "Successfully Added/Updated the Producer to the DataBase!";
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

        void SetSelectedData()
        {
            Name = _selectedProducer.Name;
            DOB = _selectedProducer.DOB;
            Biography = _selectedProducer.Biography;
        }

        void ResetData()
        {
            Name = "";
            DOB = new DateTime?();
            Biography = "";
        }
   
        #endregion

    }
}