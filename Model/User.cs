using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaldenHospitalConsumer.Model
{
    public class User
    {
       
        public int Cpr { get; set; }

        
        public string Name { get; set; }

       
        public string Surname { get; set; }

       
        public string Password { get; set; }

        public virtual Appointment Appointment { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
