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
        
        private ObservableCollection<Patient> _patients;
        private string _search = "";
       


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
                
                
                    _search = value;
                    OnPropertyChanged(nameof(Search));
                
            }
        }


        private Patient _selectedPatient;
        public Patient SelectedPatient
        {
            get { return _selectedPatient; }
            set
            {
                _selectedPatient = value;
                CurrentEntities.CurrentState.SelectedPatient = SelectedPatient;
                OnPropertyChanged(nameof(SelectedPatient));
            }
        }

        public RelayCommand DoSearching { get; set; }
        private void Find(object s)
        {
            PatientCatalog PatientCatalog = new PatientCatalog();
            Patients = new ObservableCollection<Patient>();
            Patients.Clear();
            foreach (var _patient in PatientCatalog.Patients)
            {
                if (Search == "")
                {
                    Patients.Add(_patient);
                }
                else
                {
                    if(_patient.Cpr == Search)
                    {
                        Patients.Add(_patient);
                        
                    }
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
            DoSearching = new RelayCommand(Find);
            DoShowPatientInfo = new RelayCommand(ShowPatientInfo);
          
        }
    
        //RelayCommands
        public RelayCommand DoLogOut { get; set; }
        public RelayCommand DoShowNewsView { get; set; }
        public RelayCommand DoShowRegistrationPage { get; set; }
        public RelayCommand DoShowPatientInfo { get; set; }
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

        public void ShowPatientInfo(object s)
        {
         Type type = typeof(PatientInfoView);
          FrameNavigation.ActivateFrameNavigation(type);
        }
    }
}
