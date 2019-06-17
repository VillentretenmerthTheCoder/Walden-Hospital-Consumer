using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaldenHospitalConsumer.View;
using WaldenHospitalConsumer.Utilities;
using System.Collections.ObjectModel;
using WaldenHospitalConsumer.Model;
using WaldenHospitalConsumer.Model.Catalog;

namespace WaldenHospitalConsumer.ViewModel
{
    public class NewsViewModel: NotificationClass
    {
        
        private ObservableCollection<Appointment> _appointments;
        private string _search = "";

        public ObservableCollection<Appointment> Appointments
        {
            get => _appointments;
            set
            {
                
                _appointments = value;
                OnPropertyChanged(nameof(Appointments));
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


        public RelayCommand DoSearching { get; set; }




        private void Find(object s)
        {
            AppointmentCatalog AppointmentCatalog = new AppointmentCatalog();
            Appointments = new ObservableCollection<Appointment>();
            Appointments.Clear();
            foreach (var _appointment in AppointmentCatalog.Appointments)
            {
                if (Search == "")
                {
                    Appointments.Add(_appointment);
                }
                else
                {
                    if (_appointment.Cpr == Search)
                    {
                        Appointments.Add(_appointment);

                    }
                }
            }
        }


        public NewsViewModel()
        {
            DoLogOut = new RelayCommand(LogOut);
            DoShowListOfPatients = new RelayCommand(ShowListOfPatient);
            DoShowRegistrationPage = new RelayCommand(ShowRegistrationPage);
            DoSearching = new RelayCommand(Find);
            DoShowRegisterNewDoctor = new RelayCommand(ShowRegisterNewDoctor);
            DoShowAddNewMedicine = new RelayCommand(ShowAddNewMedicine);
            DoShowReceipt = new RelayCommand(ShowReceipt);

        }
        //RelayCommands
        public RelayCommand DoLogOut { get; set; }
        public  RelayCommand DoShowListOfPatients { get; set; }
        public  RelayCommand DoShowRegistrationPage { get; set; }
        public RelayCommand DoShowRegisterNewDoctor { get; set; }
        public RelayCommand DoShowAddNewMedicine { get; set; }
        public RelayCommand DoShowReceipt { get; set; }

        public void LogOut(object s) 
        {
            Type type = typeof(LoginView);
            FrameNavigation.ActivateFrameNavigation(type);
        }

        public void ShowListOfPatient(object s)
        {
            Type type = typeof(PatientListView);
            FrameNavigation.ActivateFrameNavigation(type);
        }

        public void ShowRegistrationPage(object s)
        {
            Type type = typeof(RegistrationView);
            FrameNavigation.ActivateFrameNavigation(type);
        }

        public void ShowRegisterNewDoctor(object s)
        {
            Type type = typeof(RegisterNewDoctor);
            FrameNavigation.ActivateFrameNavigation(type);
        }

        public void ShowAddNewMedicine(object s)
        {
            Type type = typeof(AddNewMedicineView);
            FrameNavigation.ActivateFrameNavigation(type);
        }

        public void ShowReceipt(object s)
        {
            Type type = typeof(CreateReceiptView);
            FrameNavigation.ActivateFrameNavigation(type);
        }
    }
}
