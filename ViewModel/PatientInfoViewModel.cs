using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaldenHospitalConsumer.Model;
using WaldenHospitalConsumer.Utilities;
using WaldenHospitalConsumer.CurrentEntities;
using System.Collections.ObjectModel;
using WaldenHospitalConsumer.View;

namespace WaldenHospitalConsumer.ViewModel
{
    class PatientInfoViewModel: NotificationClass
    {
        private Patient _patient;
        public Patient Patient
        {
            get {return _patient;}
            set
            {
                _patient = CurrentState.SelectedPatient;
                OnPropertyChanged(nameof(Patient));
            }
        }





        public RelayCommand DoShowPatientListView {get; set;}
        public RelayCommand ShowBookingView {get; set;}

        public void ShowAppointmentBookingView(object s)
        {
            Type type = typeof(AppointmentBookingView);  
            FrameNavigation.ActivateFrameNavigation(type);
        }

        public PatientInfoViewModel()
        {
            Patient = new Patient();
            ShowBookingView = new RelayCommand(ShowAppointmentBookingView);
            DoShowPatientListView = new RelayCommand(ShowPatientListView);
        }

        public void ShowPatientListView(object s)
        {
            Type type = typeof(PatientListView);
            FrameNavigation.ActivateFrameNavigation(type);
        }

    }
}
