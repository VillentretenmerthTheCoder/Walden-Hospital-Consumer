using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaldenHospitalConsumer.Utilities;
using WaldenHospitalConsumer.View;
using WaldenHospitalConsumer.Model;
using WaldenHospitalConsumer.Model.Catalog;
using WaldenHospitalConsumer.CurrentEntities;

namespace WaldenHospitalConsumer.ViewModel
{
    class RegisterDoctorViewModel
    {

        public Doctor Doctor { get; set; }




        public void Register(object s)
        {
            DoctorCatalog DoctorCatalog = new DoctorCatalog();
            DoctorCatalog.GetData(Doctor);
            DoctorCatalog.Post();
            Type type = typeof(NewsView);
            FrameNavigation.ActivateFrameNavigation(type);
        }

        public RegisterDoctorViewModel()
        {
            DoLogOut = new RelayCommand(LogOut);
            DoShowListOfPatients = new RelayCommand(ShowListOfPatient);
            DoShowNewsView = new RelayCommand(ShowNewsView);
            DoRegister = new RelayCommand(Register);
            Doctor = new Doctor();
        }

        public RelayCommand DoRegister { get; set; }
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
