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
                OnPropertyChanged("Patients");
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
                    UpdateSearch();
                }
            }
        }

        public RelayCommand SelectItemCommand { get; set; }

        private void UpdateSearch()
        {
            Patients = Find(Search);
        }

        private ObservableCollection<Patient> Find(string Search)
        {
            ObservableCollection<Patient> _ReturnedList = new ObservableCollection<Patient>();
            foreach(Patient _patient in PatientCatalog.Patients)
            {
                if(Convert.ToString(_patient.Cpr) == Search )
                {
                    _ReturnedList.Add(_patient);
                }
                else
                if (Convert.ToString(_patient.Name) == Search)
                {
                    _ReturnedList.Add(_patient);
                }
                else
                if(Convert.ToString(_patient.LastName) == Search)
                {
                    _ReturnedList.Add(_patient);
                }
            }
            if (_ReturnedList == null)
            {
                return PatientCatalog.Patients;
            }
            else
            {
                return _ReturnedList;
            }
        }
        
        //private void SelectItem(object s)
        //{

        //}
        
        
        
        
        //Constructor
        public PatientListViewModel()
        {
            //Navigation
            DoLogOut = new RelayCommand(LogOut);
            DoShowNewsView = new RelayCommand(ShowListOfPatient);
            DoShowRegistrationPage = new RelayCommand(ShowRegistrationPage);
            //Searching


          
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
