using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaldenHospitalConsumer.Handler
{
   public interface IRequestHttpHandler<in T> where T: class
    {
        //Get all the data.
        void FetchAllData();
        //Create new data.
        void Post();
    }
}
