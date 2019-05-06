using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaldenHospitalConsumer.Model
{
  public class Appointment
    {
        
        public int Cpr { get; set; }

       
        public string Description { get; set; }

       
        public DateTime? AppointmentDate { get; set; }

        public virtual User User { get; set; }
    }
}
