using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaldenHospitalConsumer.Utilities;

namespace WaldenHospitalConsumer.Model
{
    public class User: NotificationClass
    {

        private string _cpr;
        public string Cpr
        {
            get { return _cpr; }
            set { _cpr = value;
                OnPropertyChanged(nameof(Cpr)); 
            }
        }

        
        public string Name { get; set; }

       
        public string Surname { get; set; }

       
        public string Password { get; set; }

        public virtual Appointment Appointment { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
