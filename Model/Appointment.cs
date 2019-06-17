using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WaldenHospitalConsumer.Utilities;

namespace WaldenHospitalConsumer.Model
{
  public class Appointment: NotificationClass
    {

        [Required]
        [StringLength(10)]
        public string Cpr { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Column(TypeName = "date")]
        private DateTimeOffset _appointmentDate;

        public DateTimeOffset AppointmentDate
        {
            get { return _appointmentDate; }
            set
            {
                _appointmentDate = value;
                OnPropertyChanged(nameof(AppointmentDate));
            }
        }

        private DateTimeOffset _appointmentTime;

        public DateTimeOffset AppointmentTime
        {
            get { return _appointmentTime; }
            set
            {
                _appointmentTime = value;
                OnPropertyChanged(nameof(AppointmentTime));
            }
        }


        public int AppointmentID { get; set; }

        [Required]
        [StringLength(20)]
        public string Doctor { get; set; }

        public virtual Patient Patient { get; set; }
    }
}
