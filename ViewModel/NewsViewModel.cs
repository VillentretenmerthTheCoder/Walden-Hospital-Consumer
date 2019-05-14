using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaldenHospitalConsumer.View;
using WaldenHospitalConsumer.Utilities;

namespace WaldenHospitalConsumer.ViewModel
{
    public class NewsViewModel
    {
        public NewsViewModel()
        {
            DoLogOut = new RelayCommand(LogOut);
            DoShowListOfPatients = new RelayCommand(ShowListOfPatient);
            DoShowRegistrationPage = new RelayCommand(ShowRegistrationPage);

        }
        //RelayCommands
        public RelayCommand DoLogOut { get; set; }
       public  RelayCommand DoShowListOfPatients { get; set; }
       public  RelayCommand DoShowRegistrationPage { get; set; }

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
    }
}
