using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaldenHospitalConsumer.Utilities;
using WaldenHospitalConsumer.View;

namespace WaldenHospitalConsumer.ViewModel
{
    class RegistrationViewModel
    {
        //Constructor
        public RegistrationViewModel()
        {
            DoLogOut = new RelayCommand(LogOut);
            DoShowListOfPatients = new RelayCommand(ShowListOfPatient);
            DoShowNewsView = new RelayCommand(ShowNewsView);
        }



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
