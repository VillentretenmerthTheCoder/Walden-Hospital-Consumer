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
    public class AppointmentCatalog: IRequestHttpHandler<Patient>
    {
       
        
            private const string Uri = "http://localhost:65394/api/appointments";


            public ObservableCollection<Appointment> Appointments { get; set; }
            public Appointment Appointment { get; set; }



            public AppointmentCatalog()
            {
                Appointment = new Appointment();
                Appointments = new ObservableCollection<Appointment>();
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
                            Appointments = JsonConvert.DeserializeObject<ObservableCollection<Appointment>>(response);
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

            Appointment Appointment12 = new Appointment
            {
                Cpr = Appointment.Cpr,
                Description = Appointment.Description,
                AppointmentDate = Appointment.AppointmentDate


                };


                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new HttpMediaTypeWithQualityHeaderValue("application/json"));
                    //We need to convert new object firstly into json format and then into json string form.
                    var jsonStr = JsonConvert.SerializeObject(Appointment12);
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
                        throw new Exception("Appointment is already done!");
                    }
                    //id response successed.
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonFormat = await response.Content.ReadAsStringAsync();
                        var newAppointment = JsonConvert.DeserializeObject<Patient>(jsonFormat);
                        string appointment = $"Cpr:{newAppointment.Cpr}, Name:{newAppointment.Name}, Last Name:{newAppointment.LastName}, Gender:{newAppointment.Gender}, BirthTime:{newAppointment.BirthTime}";
                        var messageDialog = new MessageDialog("Congratulations New Patient has been added correctly." + appointment);
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

            public void GetData(Appointment app)
            {
                Appointment = app;
            }
        }
    }

