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
   public class PatientCatalog : IRequestHttpHandler<Patient>
    {
        private const string Uri = "http://localhost:65394/api/patients";
        

        public ObservableCollection<Patient> Patients { get; set; }

        public ViewModel.LoginViewModel UserCatalogVm { get; set; }

        public PatientCatalog()
        {

            Patients = new ObservableCollection<Patient>();
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
                        Patients = JsonConvert.DeserializeObject<ObservableCollection<Patient>>(response);
                        //call on property change interface.
                    }
                }
                catch (Exception ex)
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
