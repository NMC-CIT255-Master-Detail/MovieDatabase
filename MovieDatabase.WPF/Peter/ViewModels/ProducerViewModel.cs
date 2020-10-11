using MovieDatabase.Domain;
using MovieDatabase.Domain.Models;
using MovieDatabase.Domain.Services;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace MovieDatabase.WPF.Peter.ViewModels
{
    public class ProducerViewModel : BaseViewModel
    {
        ObservableCollection<Producer> _producer;
        private string _name;
        IDataService<Producer> _producerRepo;
        string _message;
        Producer _selectedProducer;


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
            get =>_bio; 
            set 
            { 
                _bio = value;
                OnPropertyChanged(nameof(Biography));
            }
        }

        public Producer SelectedProducer {
            get => _selectedProducer;
            set
            {
                _selectedProducer = value;
                OnPropertyChanged(nameof(SelectedProducer));
            }
        }


        public ICommand SaveButtonCommand => new RelayCommand(SaveButton);


        public ProducerViewModel(IDataService<Producer> producerRepo)
        {
            _producerRepo = producerRepo;
            _selectedProducer = HomeViewModel.Selection.Producer;
            if (HomeViewModel.ActionToTake == HomeViewModel.Action.EDIT)
            {
                Name = _selectedProducer.Name;
                DOB = _selectedProducer.DOB;
                Biography = _selectedProducer.Biography;
            }
        }



        void SaveButton()
        {
            if (HomeViewModel.ActionToTake == HomeViewModel.Action.EDIT)
            {
                Producer producerToUpdate = new Producer();
                producerToUpdate.Name = _name;
                producerToUpdate.DOB = (DateTime)_dob;
                producerToUpdate.Biography = _bio;
                UpdateToDB(producerToUpdate);
            } else
            {
                if (Name != "" && DOB != null && Biography != "")
                {
                    Producer newProducerToAdd = new Producer();
                    newProducerToAdd.Name = _name;
                    newProducerToAdd.DOB = (DateTime)_dob;
                    newProducerToAdd.Biography = _bio;
                    SaveToDB(newProducerToAdd);
                }
                else
                {
                    _message = "Sorry, but it looks like you didn't fill out all the fields";
                    MessageBox.Show(_message);
                }
            }
        }

        private void UpdateToDB(Producer producerToUpdate)
        {
            if (producerToUpdate != null)
            {
                _producerRepo.Update(_selectedProducer.Id, producerToUpdate);
            }
        }

        void SaveToDB(Producer producer)
        {
            if (producer != null)
            {
                _producerRepo.Create(producer);
            }

            ResetForm();
        }

        void ResetForm()
        {
            Name = "";
            DOB = new DateTime?();
            Biography = "";
            _message = "Successfully added to the DataBase!";
            MessageBox.Show(_message);
        }
    }
}