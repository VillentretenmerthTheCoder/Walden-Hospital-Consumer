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
    class DoctorCatalog
    {
        private const string Uri = "http://localhost:54174/api/doctors";


        public ObservableCollection<Doctor> Doctors { get; set; }
        public Doctor Doctor { get; set; }



        public DoctorCatalog()
        {
            Doctor = new Doctor();
            Doctors = new ObservableCollection<Doctor>();
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
                        Doctors = JsonConvert.DeserializeObject<ObservableCollection<Doctor>>(response);
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

            Doctor Doctor12 = new Doctor
            {
                Cpr = Doctor.Cpr,
                Name = Doctor.Name,
                LastName = Doctor.LastName,
                Profession = Doctor.Profession
            };


            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new HttpMediaTypeWithQualityHeaderValue("application/json"));
                //We need to convert new object firstly into json format and then into json string form.
                var jsonStr = JsonConvert.SerializeObject(Doctor12);
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
                    throw new Exception("Doctor already exist!");
                }
                //id response successed.
                if (response.IsSuccessStatusCode)
                {
                    string jsonFormat = await response.Content.ReadAsStringAsync();
                    var newDoctor = JsonConvert.DeserializeObject<Doctor>(jsonFormat);
                    string doctor = $"Cpr:{newDoctor.Cpr}, Name:{newDoctor.Name}, Last Name:{newDoctor.LastName}, Profession:{newDoctor.Profession}";
                    var messageDialog = new MessageDialog("Congratulations New Doctor has been added correctly." + doctor);
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

        public void GetData(Doctor doc)
        {
            Doctor = doc;
        }
    }
}
