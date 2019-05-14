using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaldenHospitalConsumer.Utilities;
using WaldenHospitalConsumer.View;

namespace WaldenHospitalConsumer.ViewModel
{
    public class MyProfileViewModel: NotificationClass
    {
        public void LogOut()
        {
            Type type = typeof(LoginView);
            FrameNavigation.ActivateFrameNavigation(type);
        }

        //public void ShowListOfPatient()
        //{
        //    Type type typeof(PatientListView);
        //    FrameNavigation.ActivateFrameNavigation(type);
        //}

        //public void RegistrationPage()
        //{
        //    Type type typeof(RegistrationView);
        //    FrameNavigation.ActivateFrameNavigation(type);
        //}






    }
}
