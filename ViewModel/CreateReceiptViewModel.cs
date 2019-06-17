using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaldenHospitalConsumer.Model.Catalog;
using System.Collections.ObjectModel;
using WaldenHospitalConsumer.Model;
using WaldenHospitalConsumer.Utilities;
using WaldenHospitalConsumer.View;
using WaldenHospitalConsumer.CurrentEntities;

namespace WaldenHospitalConsumer.ViewModel
{
    class CreateReceiptViewModel: NotificationClass
    {

        //Medicines
        
        private ObservableCollection<Medicine> _medicines;

        public ObservableCollection<Medicine> Medicines
        {
            get
            {
                MedicineCatalog MedicineCatalog = new MedicineCatalog();
                _medicines = MedicineCatalog.Medicines;
                return _medicines; }
            set
            {
                _medicines = value;
            }
        }

        


       

        private Medicine _selectedMedicine;

        public Medicine SelectedMedicine
        {
            get { return _selectedMedicine; }
            set
            {
                _selectedMedicine = value;
                CurrentState.ReceitMedicine = _selectedMedicine;
            }
        }

        private ObservableCollection<Medicine> _selectedMedicines;

        public ObservableCollection<Medicine> SelectedMedicines
        {
            get
            {
                return _selectedMedicines;
            }
            set
            {
                _selectedMedicines = value;
            }
        }




        public RelayCommand DoAdd { get; set; }
        public void Add(object s)
        {
            SelectedMedicines.Add(SelectedMedicine);       
        }
        //Dependecy Injection
       
        
        
        
        //Price of the service.
        private int _servicePrice;
        public int ServicePrice
        {
            get { return _servicePrice; }
            set
            {
                _servicePrice = value;
                CurrentState.ReceiptPrice = _servicePrice;
            }
        }

        private string _serviceDescription;
        public string ServiceDescription
        {
            get { return _serviceDescription; }
            set
            {
                _serviceDescription = value;
                CurrentState.ReceiptDescription = _serviceDescription;
            }
        }



        //Doctors

        private Doctor _selectedDoctor;
        public Doctor SelectedDoctor
        {
            get { return _selectedDoctor; }
            set
            {
                _selectedDoctor = value;
                CurrentState.ReceiptDoctor = _selectedDoctor;
            }
        }

        private ObservableCollection<Doctor> _doctors;

        public ObservableCollection<Doctor> Doctors
        {
            get
            {
                DoctorCatalog DoctorCatalog = new DoctorCatalog();
                _doctors = DoctorCatalog.Doctors;
                return _doctors;
            }
            set
            {
                _doctors = value;
            }
        }

        //Navigation
        public RelayCommand DoBack { get; set; }

        public void Back(object s)
        {
            Type type = typeof(NewsView);
            FrameNavigation.ActivateFrameNavigation(type);
        }

        //ReceiptCreation
        public RelayCommand DoCreateReceipt { get; set; }

        public void CreateReceipt(object s)
        {

            ReceiptViewModel rvm = new ReceiptViewModel();
            //rvm.PassCollection(SelectedMedicines);
            Type type = typeof(ReceiptView);
            FrameNavigation.ActivateFrameNavigation(type);
        }
        


        //Constructor
        public CreateReceiptViewModel()
        {
            DoBack = new RelayCommand(Back);
            DoCreateReceipt = new RelayCommand(CreateReceipt);
            DoAdd = new RelayCommand(Add);
            SelectedMedicines = new ObservableCollection<Medicine>();
            DoAppointmentsView = new RelayCommand(AppointmentView);
        }


        public RelayCommand DoAppointmentsView { get; set; }

        public void AppointmentView(object s)
        {
            Type type = typeof(NewsView);
            FrameNavigation.ActivateFrameNavigation(type);
        }


    }
}
