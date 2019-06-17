using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WaldenHospitalConsumer.Model
{
    class Doctor
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        public string LastName { get; set; }

        [Required]
        [StringLength(10)]
        public string Cpr { get; set; }

        [Required]
        [StringLength(20)]
        public string Profession { get; set; }

        public override string ToString()
        {
            return $"{Name} {LastName} Profession:{Profession}";
        }

    }
}
