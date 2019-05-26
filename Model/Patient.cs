using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaldenHospitalConsumer.Utilities;
namespace WaldenHospitalConsumer.Model
{
    public class Patient : NotificationClass
    {
        private string _cpr;
        private int _gender;
        private DateTime? _birthtime;
        private string _name;
        private string _lastname;


        public string Cpr
        {
            get { return _cpr; }
            set { _cpr = value;
                OnPropertyChanged(nameof(Cpr));
            }
        }
        
        public int Gender
        {
            get { return _gender; }
            set { _gender = value;
                OnPropertyChanged(nameof(Gender));
            }
        }

        public DateTime? BirthTime
        {
            get { return _birthtime; }
            set { _birthtime = value;
                OnPropertyChanged(nameof(BirthTime));
            }
        }

        public string Name { get { return _name; } set { _name = value;
                OnPropertyChanged(nameof(_name));
            } }
        
        public string LastName
        {
            get { return _lastname; }
            set { _lastname = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        
    }
}
