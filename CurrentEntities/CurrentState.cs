using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaldenHospitalConsumer.Model;
using System.Collections.ObjectModel;

namespace WaldenHospitalConsumer.CurrentEntities
{
    static class CurrentState
    {
        public static Patient CurrentPatient { get; set; }
        public static Patient SelectedPatient { get; set; }
        public static Doctor SelectedDoctor { get; set; }

        public static Doctor ReceiptDoctor { get; set; }



   
        public static Medicine ReceitMedicine { get; set; }

        public static string ReceiptDescription { get; set; }
        public static int ReceiptPrice { get; set; }


     
    }
}
