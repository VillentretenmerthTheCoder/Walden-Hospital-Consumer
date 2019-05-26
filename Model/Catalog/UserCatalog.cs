using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaldenHospitalConsumer.Handler;
using System.Collections.ObjectModel;
using Windows.UI.Popups;
using Windows.Web.Http;
using Newtonsoft.Json;
using WaldenHospitalConsumer.Utilities;


namespace WaldenHospitalConsumer.Model.Catalog
{
   public class UserCatalog: IRequestHttpHandler<User>
    {
        private const string Uri = "http://localhost:54174/api/users";

        public ObservableCollection<User> Users { get; set; }

        public ViewModel.LoginViewModel UserCatalogVm { get; set; }

        public UserCatalog()
        {
            
            Users = new ObservableCollection<User>();
            FetchAllData();
        }


        public async void FetchAllData()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = "";
                    Task task = Task.Run(async () =>
                    {
                        // sends GET request
                        // ReSharper disable once AccessToDisposedClosure
                        response = await client.GetStringAsync(new Uri(Uri));
                    });
                    // Wait
                    task.Wait();
                    // convert Json into Objects
                    if (response != null)
                    {
                        Users = JsonConvert.DeserializeObject<ObservableCollection<User>>(response);
                        //call on property change interface.
                    }
                }
                catch(Exception ex)
                {
                    var messageDialog = new MessageDialog(ex.Message);
                    await messageDialog.ShowAsync();
                }                
            }
        }


           public void Post()
        {
            throw new NotImplementedException();
        }

    }
}
