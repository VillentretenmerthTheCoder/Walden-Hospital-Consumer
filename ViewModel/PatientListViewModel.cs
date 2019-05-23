using System;
using WaldenHospitalConsumer.Utilities;
using WaldenHospitalConsumer.Model.Catalog;
using Windows.UI.Xaml.Controls;
using System.Collections.ObjectModel;
using WaldenHospitalConsumer.Model;
using WaldenHospitalConsumer.View;
using System.Linq;

namespace WaldenHospitalConsumer.ViewModel
{
    class PatientListViewModel: NotificationClass
    {
        PatientCatalog PatientCatalog = new PatientCatalog();
        private ObservableCollection<Patient> _patients;
        private string _search;
       


        public ObservableCollection<Patient> Patients
        {
            get => _patients;
            set
            {
                _patients = value;
                OnPropertyChanged(nameof(Patients));
            }
        }

        public string Search
        {
            get => _search;
            set
            {
                if(Search != value)
                {
                    _search = value;
                }
            }
        }

        public RelayCommand SelectItemCommand { get; set; }

        public void Searching(object s)
        {
            Find(Search);
        }
        public RelayCommand DoSearching { get; set; }




        private void Find(string Search)
        {
            PatientCatalog PatientCatalog = new PatientCatalog();
            ObservableCollection<Patient> _ReturnedList = new ObservableCollection<Patient>();
            foreach (Patient _patient in PatientCatalog.Patients)
            {
                if (_patient.Name == Search || _patient.LastName == Search)
                {
                    Patients.Clear();
                    Patients.Add(_patient);
                }
                else
                {
                    Patients = PatientCatalog.Patients;
                }


            }
        }
     
        
        
        
        
        //Constructor
        public PatientListViewModel()
        {
            //Navigation
            DoLogOut = new RelayCommand(LogOut);
            DoShowNewsView = new RelayCommand(ShowListOfPatient);
            DoShowRegistrationPage = new RelayCommand(ShowRegistrationPage);
            //Searching
            DoSearching = new RelayCommand(Searching);

          
        }


       
        
        //RelayCommands
        public RelayCommand DoLogOut { get; set; }
        public RelayCommand DoShowNewsView { get; set; }
        public RelayCommand DoShowRegistrationPage { get; set; }

        //MovingMethods
        public void LogOut(object s)
        {
            Type type = typeof(LoginView);
            FrameNavigation.ActivateFrameNavigation(type);
        }

        public void ShowListOfPatient(object s)
        {
            Type type = typeof(NewsView);
            FrameNavigation.ActivateFrameNavigation(type);
        }

        public void ShowRegistrationPage(object s)
        {
            Type type = typeof(RegistrationView);
            FrameNavigation.ActivateFrameNavigation(type);
        }


    }
}
