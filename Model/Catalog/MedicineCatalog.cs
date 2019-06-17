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
using WaldenHospitalConsumer.ViewModel;
using Windows.Web.Http.Headers;

namespace WaldenHospitalConsumer.Model.Catalog
{
    class MedicineCatalog: IRequestHttpHandler<Medicine>
    {
        private const string Uri = "http://localhost:54174/api/medicines";


        public ObservableCollection<Medicine> Medicines { get; set; }
        public Medicine Medicine { get; set; }



        public MedicineCatalog()
        {
            Medicine = new Medicine();
            Medicines = new ObservableCollection<Medicine>();
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
                        Medicines = JsonConvert.DeserializeObject<ObservableCollection<Medicine>>(response);
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



        public async void Post()
        {

            Medicine Medicine12 = new Medicine
            {
                Name = Medicine.Name,
                Price = Medicine.Price
                
            };


            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new HttpMediaTypeWithQualityHeaderValue("application/json"));
                //We need to convert new object firstly into json format and then into json string form.
                var jsonStr = JsonConvert.SerializeObject(Medicine12);
                var content = new HttpStringContent(jsonStr, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json");
                HttpResponseMessage response = null;
                Task task = Task.Run(async () =>
                {
                    //Here we send a post request.
                    response = await client.PostAsync(new Uri(Uri), content);
                });
                task.Wait();
                if (response.StatusCode == HttpStatusCode.Conflict)
                {
                    throw new Exception("Medicine already exist!");
                }
                //id response successed.
                if (response.IsSuccessStatusCode)
                {
                    string jsonFormat = await response.Content.ReadAsStringAsync();
                    var newMedicine = JsonConvert.DeserializeObject<Medicine>(jsonFormat);
                    string medicine = $"Name:{newMedicine.Name}, Price:{newMedicine.Price}";
                    var messageDialog = new MessageDialog("Congratulations New Medicine has been added correctly." + medicine);
                    await messageDialog.ShowAsync();
                }
                else
                {
                    if (response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        var JsonError = await response.Content.ReadAsStringAsync();
                        var messageDialog = new MessageDialog(JsonError);
                        await messageDialog.ShowAsync();
                    }
                }
            }




        }

        public void GetData(Medicine med)
        {
            Medicine = med;
        }
    }
}
