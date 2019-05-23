using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaldenHospitalConsumer.Utilities;
using WaldenHospitalConsumer.Model;
using WaldenHospitalConsumer.View;
using WaldenHospitalConsumer.Model.Catalog;

namespace WaldenHospitalConsumer.ViewModel
{
    class AppointmentBookingViewModel
    {
        
        public Appointment Appointment { get; set; }


        public void Booking(object s)
        {
            AppointmentCatalog AppointmentCatalog = new AppointmentCatalog();
            AppointmentCatalog.GetData(Appointment);
            AppointmentCatalog.Post();
        }



        public AppointmentBookingViewModel()
        {
            DoLogOut = new RelayCommand(LogOut);
            DoShowListOfPatients = new RelayCommand(ShowListOfPatient);
            DoShowNewsView = new RelayCommand(ShowNewsView);
            //DoIsCheckedMale = new RelayCommand(IsCheckedMale);
            //DoIsCheckedFemale = new RelayCommand(IsCheckedFemale);
            DoBooking = new RelayCommand(Booking);
            Appointment = new Appointment();
            //Patient = CurrentState.CurrentPatient;

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
