using Microsoft.Win32;
using Pharmcy.Constans;
using Pharmcy.Entities.Pharmacists;
using Pharmcy.Helpers;
using Pharmcy.Interfaces.Pharmacists;
using Pharmcy.Repostories.Pharmacists;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Pharmcy.Windows.Pharmacists
{
    /// <summary>
    /// Interaction logic for CreatePharmacist.xaml
    /// </summary>
    public partial class CreatePharmacist : Window
    {
        
        private readonly IPharmacistRepository _pharmacistRepository;
        public CreatePharmacist()
        {
            InitializeComponent();
            this._pharmacistRepository = new PharmacistRepository();
        }

        private void cmbBoxCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Pharmacist pharmacist = new Pharmacist();
            pharmacist.FirstName = tbFirstName.Text;
            pharmacist.LastName = tbLastName.Text;
            pharmacist.PharEmail = tbPrice.Text;
            pharmacist.gender = cmbGender.Text;
            string imagepath = ImgBImage.ImageSource.ToString();
            if (!String.IsNullOrEmpty(imagepath))
                pharmacist.image_path = await CopyImageAsync(imagepath, 
                    ContentConstants.IMAGE_CONTENTS_PATH);

            pharmacist.birth_date = DateTime.Parse(dpBirthDate.Text.ToString());
            pharmacist.PharEmail = string.Empty;
            pharmacist.CreatedAT = TimeHelper.GetDateTime();
            pharmacist.UpdatedAT = TimeHelper.GetDateTime();
            var result = await _pharmacistRepository.CreateAsync(pharmacist);
            if(result>0)
            {
                MessageBox.Show("Succesfully");
                this.Close();
            }            
        }
        private async Task<string> CopyImageAsync(string imgPath, string destinationDirectory)
        {
            if (!Directory.Exists(destinationDirectory))
                Directory.CreateDirectory(destinationDirectory);
            var imageName = ContentNameMaker.GetImageName(imgPath);
            string path = Path.Combine(destinationDirectory, imageName);
            byte[] image = await File.ReadAllBytesAsync(imgPath);
            await File.WriteAllBytesAsync(path, image);
            return path;
        }
        private void btnImageSelector_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = GetImageDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string imgPath = openFileDialog.FileName;
                ImgBImage.ImageSource = new BitmapImage(new Uri(imgPath, UriKind.Relative));
            }
        }
        private OpenFileDialog GetImageDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|GIF Files (*.gif)|*.gif";
            return openFileDialog;
        }
    }
}
