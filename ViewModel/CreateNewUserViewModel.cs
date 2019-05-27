using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaldenHospitalConsumer.View;
using WaldenHospitalConsumer.Utilities;
using WaldenHospitalConsumer.Model.Catalog;
using WaldenHospitalConsumer.Model;

namespace WaldenHospitalConsumer.ViewModel
{
    class CreateNewUserViewModel
    {
        public RelayCommand DoLogOut { get; set; }
        public User User { get; set; }
        public RelayCommand DoRegister { get; set; }

        public void Register(object s)
        {
            UserCatalog UserCatalog = new UserCatalog();
            UserCatalog.GetData(User);
            UserCatalog.Post();
        }


        public CreateNewUserViewModel()
        {
            DoLogOut = new RelayCommand(LogOut);
            DoRegister = new RelayCommand(Register);
            User = new User();
        }

        public void LogOut(object s)
        {
            Type type = typeof(LoginView);
            FrameNavigation.ActivateFrameNavigation(type);
        }
    }
}
