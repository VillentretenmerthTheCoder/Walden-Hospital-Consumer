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
    class AddNewMedicineViewModel
    {
        public Medicine Medicine { get; set; }




        public void Register(object s)
        {
            MedicineCatalog MedicineCatalog = new MedicineCatalog();
            MedicineCatalog.GetData(Medicine);
            MedicineCatalog.Post();
            Type type = typeof(NewsView);
            FrameNavigation.ActivateFrameNavigation(type);
        }

        public AddNewMedicineViewModel()
        {
            DoLogOut = new RelayCommand(LogOut);
            DoShowListOfPatients = new RelayCommand(ShowListOfPatient);
            DoShowNewsView = new RelayCommand(ShowNewsView);
            DoRegister = new RelayCommand(Register);
            Medicine = new Medicine();
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
