using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaldenHospitalConsumer.Model
{
   public class Patient
    {
       
        public int Cpr { get; set; }

        
        public string Gender { get; set; }

       
        public DateTime? BirthTime { get; set; }

        public User User { get; set; }
    }
}
