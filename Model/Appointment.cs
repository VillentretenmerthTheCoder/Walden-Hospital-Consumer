using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WaldenHospitalConsumer.Model
{
  public class Appointment
    {

        [Required]
        [StringLength(10)]
        public string Cpr { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Column(TypeName = "date")]
        public DateTime AppointmentDate { get; set; }

        public TimeSpan AppointmentTime { get; set; }

        public int AppointmentID { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
