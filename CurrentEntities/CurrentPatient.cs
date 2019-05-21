using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaldenHospitalConsumer.CurrentEntities
{
    public static class CurrentPatient
    {
        public int Cpr { get; set; }


        public int Gender { get; set; }


        public DateTime? BirthTime { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

    }
}
