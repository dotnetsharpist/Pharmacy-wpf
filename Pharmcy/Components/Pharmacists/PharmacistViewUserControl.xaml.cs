using Pharmcy.Entities.Medicines;
using Pharmcy.Entities.Pharmacists;
using Pharmcy.Interfaces.Medicines;
using Pharmcy.Interfaces.Pharmacists;
using Pharmcy.Repostories.Medicines;
using Pharmcy.Repostories.Pharmacists;
using Pharmcy.Windows.Medicines;
using Pharmcy.Windows.Pharmacists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pharmcy.Components.Pharmacists
{
    /// <summary>
    /// Interaction logic for PharmacistViewUserControl.xaml
    /// </summary>
    public partial class PharmacistViewUserControl : UserControl
    {
        private Pharmacist Pharmacist { get; set; }
        private readonly IPharmacistRepository _pharmacistRepository;
        public PharmacistViewUserControl()
        {
            InitializeComponent();
            this._pharmacistRepository = new PharmacistRepository();
            Pharmacist = new Pharmacist();
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure to delete this pharmacist?", "Warning", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                var result1 = _pharmacistRepository.DeleteAsync(Pharmacist.PharId); 
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult natija1 = MessageBox.Show("Are you sure to edit this pharmacist?", "Warning", MessageBoxButton.YesNo);
            if (natija1 == MessageBoxResult.Yes)
            {
                PharmacistUpdateWindow pharmacistUpdateWindow = new PharmacistUpdateWindow();
                pharmacistUpdateWindow.SetData(Pharmacist);
                pharmacistUpdateWindow.ShowDialog();
            }
        }
        public void SetData(Pharmacist pharmacist)
        {
            ImgB.ImageSource = new BitmapImage(new System.Uri(pharmacist.image_path, UriKind.Relative));
            lbName.Content = pharmacist.FirstName;
            
              
            lbPrice.Content = pharmacist.LastName;
            
            tbDescription.Text = pharmacist.birth_date.ToString();
            Pharmacist = pharmacist;
        }
    }
}
