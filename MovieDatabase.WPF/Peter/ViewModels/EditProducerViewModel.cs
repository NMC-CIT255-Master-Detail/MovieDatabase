using MovieDatabase.Domain;
using MovieDatabase.Domain.Models;
using MovieDatabase.Domain.Services;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace MovieDatabase.WPF.Peter.ViewModels
{
    public class EditProducerViewModel : BaseViewModel
    {
        ObservableCollection<Producer> _producer;
        private string _name;
        IDataService<Producer> _producerRepo;
        string _message;
        Producer _selectedProducer;


        public Producer SelectedProducer
        {
            get => _selectedProducer;
            set
            {
                _selectedProducer = value;
                OnPropertyChanged(nameof(SelectedProducer));
            }
        }

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


        public ICommand SaveButtonCommand => new RelayCommand(SaveButton);


        public EditProducerViewModel(IDataService<Producer> producerRepo, Producer selectedProducer)
        {
            _producerRepo = producerRepo;
            _selectedProducer = selectedProducer;
        }



        void SaveButton()
        {
            Producer newProducerToAdd = new Producer();
            if (Name != "" && DOB != null && Biography != "")
            {
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