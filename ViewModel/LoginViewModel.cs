using System;
using WaldenHospitalConsumer.Utilities;
using WaldenHospitalConsumer.Model.Catalog;
using WaldenHospitalConsumer.Model;
using Windows.UI.Popups;
using WaldenHospitalConsumer.View;

namespace WaldenHospitalConsumer.ViewModel
{
    public class LoginViewModel: NotificationClass
    {
        private int _cpr;
        private string _password;
        private bool _allowLogin = false;

        public IObservable<User> Users { get; set; }


        public bool AllowLogin
        {
            get { return _allowLogin; }
            set { _allowLogin = value; }
        }
        public int Cpr
        {
            get { return _cpr; }
            set { _cpr = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }


        public RelayCommand LoginCommand { get; set; }

        

        //Constructor
        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(Login);
        }
       //was supposed to be async but duuno where to put await xD
       
        public async void Login(object s)
        {
            try
            {
                UserCatalog UserCatalog = new UserCatalog();
                if(UserCatalog!= null)
                {
                    

                    foreach(var user in UserCatalog.Users)
                    {
                     
                        if(user.Cpr == Cpr)
                        {
                            if(user.Password.Trim() == Password)
                            {
                               
                                
                                  Type typeProfile = typeof(NewsView);
                                  FrameNavigation.ActivateFrameNavigation(typeProfile);
                                break;
                            } 
                            else
                            {
                                {
                                    var dialog = new MessageDialog("Wrong email or password");
                                    await dialog.ShowAsync();
                                    break;
                                }
                            }
                        }
                       
                    }
                    
                   
                   
                }        


            }
            catch (Exception)
            {

            }
          
           
        }


    }
}
