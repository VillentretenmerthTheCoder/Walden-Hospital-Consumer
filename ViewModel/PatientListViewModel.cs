using System;
using WaldenHospitalConsumer.Utilities;
using WaldenHospitalConsumer.Model.Catalog;
using Windows.UI.Xaml.Controls;
using System.Collections.ObjectModel;
using WaldenHospitalConsumer.Model;
using WaldenHospitalConsumer.View;

namespace WaldenHospitalConsumer.ViewModel
{
    class PatientListViewModel
    {
        public RelayCommand DoSearchByCpr;
        public RelayCommand DoSearchByName;
        public RelayCommand DoSearchBySurname;

        PatientCatalog PatientCatalog = new PatientCatalog();
        private ObservableCollection<Patient> _patients;
        private ObservableCollection<Patient> _displayPatients;
        private Patient _inputPatient;
        
        
        public static Frame ContentFrame { get; set; }

        //Constructor
        public PatientListViewModel()
        {
            DoLogOut = new RelayCommand(LogOut);
            DoShowNewsView = new RelayCommand(ShowListOfPatient);
            DoShowRegistrationPage = new RelayCommand(ShowRegistrationPage);
            DoSearchByCpr = new RelayCommand(SearchByCpr);
            DoSearchByName = new RelayCommand(SearchByName);
            DoSearchBySurname = new RelayCommand(SearchBySurname);
            _inputPatient = new Patient();
            _patients = new ObservableCollection<Patient>();
            _displayPatients = new ObservableCollection<Patient>();
            PatientInit();
        }

        //Methods
        private void PatientInit()
        {
            PatientCatalog.Patients = _patients;
            _patients.Clear();
        }

        public void SearchByCpr(object s)
        {
            PatientInit();
            _displayPatients.Clear();
            foreach (var Patient in _patients)
            {
                if(Patient.Cpr == _inputPatient.Cpr)
                {
                    _displayPatients.Add(Patient);
                }
            }
        }

        public void SearchByName(object s)
        {
            PatientInit();
            _displayPatients.Clear();
            foreach(var Patient in _patients)
            {
                if(Patient.User.Name == _inputPatient.User.Name)
                {
                    _displayPatients.Add(Patient);
                }
            }
        }

        public void SearchBySurname (object s)
        {
            PatientInit();
            _displayPatients.Clear();
            foreach (var Patient in _patients)
            {
                if (Patient.User.Surname == _inputPatient.User.Surname)
                {
                    _displayPatients.Add(Patient);
                }
            }
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
