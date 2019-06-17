using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaldenHospitalConsumer.Utilities;
using WaldenHospitalConsumer.Model;
using WaldenHospitalConsumer.View;
using WaldenHospitalConsumer.Model.Catalog;
using System.Collections.ObjectModel;

namespace WaldenHospitalConsumer.ViewModel
{
    class AppointmentBookingViewModel: NotificationClass
    {
        private Appointment _appointment;
        private ObservableCollection<Doctor> _doctor;
      

        public Appointment Appointment
        {
            get { return _appointment; }
            set { _appointment = value;
                OnPropertyChanged(nameof(Appointment));
            }
        }


        private Doctor _selectedDoctor;
        public Doctor SelectedDoctor
        {
            get { return _selectedDoctor;}
            set
            {
                _selectedDoctor = value;
                CurrentEntities.CurrentState.SelectedDoctor = SelectedDoctor;
                OnPropertyChanged(nameof(SelectedDoctor));
            }
        }




        public ObservableCollection<Doctor> Doctors
        {
            get
            {
                DoctorCatalog DoctorCatalog = new DoctorCatalog();
                _doctor = DoctorCatalog.Doctors;
                return _doctor;
            }
            set
            {
                _doctor = value;
            }
        }
        public void Booking(object s)
        {
            AppointmentCatalog AppointmentCatalog = new AppointmentCatalog();
            AppointmentCatalog.GetData(Appointment);
            AppointmentCatalog.Post();
            Type type = typeof(NewsView);
            FrameNavigation.ActivateFrameNavigation(type);
        }



        public AppointmentBookingViewModel()
        {
            DoLogOut = new RelayCommand(LogOut);
            DoShowListOfPatients = new RelayCommand(ShowListOfPatient);
            DoShowNewsView = new RelayCommand(ShowNewsView);
            DoBooking = new RelayCommand(Booking);
            Appointment = new Appointment();
        }

        public RelayCommand DoBooking { get; set; }
        public RelayCommand DoIsCheckedMale { get; set; }
        public RelayCommand DoIsCheckedFemale { get; set; }
        public RelayCommand DoLogOut { get; set; }
        public RelayCommand DoShowListOfPatients { get; set; }
        public RelayCommand DoShowNewsView { get; set; }

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

        public void ShowNewsView(object s)
        {
            Type type = typeof(NewsView);
            FrameNavigation.ActivateFrameNavigation(type);
        }
    }
}
