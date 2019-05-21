using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaldenHospitalConsumer.Model;

namespace WaldenHospitalConsumer.CurrentEntities
{
    static class CurrentState
    {
      public static  Patient CurrentPatient { get; set; }
      public static  Patient SelectedPatient { get; set; }
    }
}
