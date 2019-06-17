using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaldenHospitalConsumer.Utilities;
using System.Collections.ObjectModel;
using WaldenHospitalConsumer.Model;
using WaldenHospitalConsumer.CurrentEntities;
using WaldenHospitalConsumer.View;

namespace WaldenHospitalConsumer.ViewModel
{
    class ReceiptViewModel: NotificationClass
    {
        public RelayCommand DoAppointmentsView { get; set; }

        public void AppointmentView(object s)
        {
            Type type = typeof(NewsView);
            FrameNavigation.ActivateFrameNavigation(type);
        }
        public ReceiptViewModel()
        {
            DoAppointmentsView = new RelayCommand(AppointmentView);
        }



        //private ObservableCollection<Medicine> _medicines;
        //public ObservableCollection<Medicine> Medicines
        //{
        //    get { return _medicines; }
        //    set
        //    {
        //        _medicines = value;
        //        OnPropertyChanged(nameof(Medicines));
        //    }
        //}
        private Medicine _medicine;
        public Medicine Medicine
        {
            get
            {
                _medicine = CurrentState.ReceitMedicine;
                return _medicine;
            }
        }
        private Doctor _doctor;
        public Doctor Doctor
        {
            get
            {
                _doctor = CurrentState.ReceiptDoctor;
                return _doctor;
            }
        }

        private string _description;
        public string Description
        {
            get
            {
                _description = CurrentState.ReceiptDescription;
                return _description;
            }
        }

        private int _price;
        public int Price
        {
            get
            {
                _price = CurrentState.ReceiptPrice;
                return _price;
            }
        }

        //public void PassCollection(ObservableCollection<Medicine> list)
        //{
        //    Medicines = list;
        //}

    }
}
