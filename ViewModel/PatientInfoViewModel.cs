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
            get { return _patient; }
            set
            {
                _patient = CurrentState.SelectedPatient;
                OnPropertyChanged(nameof(Patient));
            }
        }

        public RelayCommand ShowBookingView { get; set; }

        public void ShowAppointmentBookingView(object s)
        {
            Type type = typeof(AppointmentBookingView);
            FrameNavigation.ActivateFrameNavigation(type);
        }

        public PatientInfoViewModel()
        {
            Patient = new Patient();
            ShowBookingView = new RelayCommand(ShowAppointmentBookingView);
        }

    }
}
