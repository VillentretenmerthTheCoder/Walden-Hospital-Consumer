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
   public class UserCatalog: IRequestHttpHandler<User>
    {
        private const string Uri = "http://localhost:63560/api/users";

        public ObservableCollection<User> Users { get; set; }
        public User User { get; set; }
       

        public UserCatalog()
        {
            User = new User();
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


           public async void Post()
        {
            User User12 = new User
            {
                 Name = User.Name,
                 Surname = User.Surname,
                 AdminCpr = User.AdminCpr,
                 Password = User.Password
            };


            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new HttpMediaTypeWithQualityHeaderValue("application/json"));
                //We need to convert new object firstly into json format and then into json string form.
                var jsonStr = JsonConvert.SerializeObject(User12);
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
                    throw new Exception("User already exist!");
                }
                //id response successed.
                if (response.IsSuccessStatusCode)
                {
                    string jsonFormat = await response.Content.ReadAsStringAsync();
                    var newUser = JsonConvert.DeserializeObject<User>(jsonFormat);
                    string user = $"Cpr:{newUser.AdminCpr}, Name:{newUser.Name}, Last Name:{newUser.Surname}, Password:{newUser.Password}";
                    var messageDialog = new MessageDialog("Congratulations New User has been added correctly." + user);
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

        public void GetData(User pat)
        {
            User = pat;
        }
    }
}
