using Pharmcy.Entities.Medicines;
using Pharmcy.Interfaces.Medicines;
using Pharmcy.Repostories.Medicines;
using Pharmcy.Windows.Medicines;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Pharmcy.Components.Medicines
{
    /// <summary>
    /// Interaction logic for MedicineViewUserControl.xaml
    /// </summary>
    public partial class MedicineViewUserControl : UserControl
    {
        //public long Id { get; private set; }
        private Medicine Medicine { get; set; }
        //private readonly IMedicineRepository _medicineRepository;
        private readonly IMedicineRepository _medicineRepository;
        public MedicineViewUserControl()
        {
            InitializeComponent();
            this._medicineRepository = new MedicineRepository();
            Medicine = new Medicine();
        }
        

        public void SetData(Medicine medicine)
        {
            //Id = medicine.MedId;
            ImgB.ImageSource = new BitmapImage(new System.Uri(medicine.image_path, UriKind.Relative));
            lbName.Content = medicine.Name;
            lbPrice.Content = medicine.Price;
            tbDescription.Text = medicine.Description;
            Medicine = medicine;
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e, Medicine medicine)
        {
            MedicineUpdateWindow medicineUpdateWindow = new MedicineUpdateWindow();
        }


        private void Bin_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure to delete this medicine?", "Warning", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                var result2 = _medicineRepository.DeleteAsync(Medicine.MedId);   
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult natija1 = MessageBox.Show("Are you sure to edit this medicine?", "Warning", MessageBoxButton.YesNo);
            if(natija1 == MessageBoxResult.Yes)
            {
                MedicineUpdateWindow medicineUpdateWindow = new MedicineUpdateWindow();
                medicineUpdateWindow.SetData(Medicine);
                medicineUpdateWindow.ShowDialog();
            }
        }
            
            
            //MessageBoxResult result = MessageBox.Show("Are you sure to edit this medicine?","Warning",MessageBoxButton.OKCancel);
            //if (result == MessageBoxResult.OK)
            //{
              //  MedicineUpdateWindow medicineUpdateWindow = new MedicineUpdateWindow();
            //}
        
    }    
            
}
