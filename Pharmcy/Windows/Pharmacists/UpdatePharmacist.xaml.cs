using Microsoft.Win32;
using Pharmcy.Constans;
using Pharmcy.Entities.Medicines;
using Pharmcy.Entities.Pharmacists;
using Pharmcy.Helpers;
using Pharmcy.Interfaces.Medicines;
using Pharmcy.Interfaces.Pharmacists;
using Pharmcy.Repostories.Pharmacists;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Pharmcy.Windows.Pharmacists
{
    /// <summary>
    /// Interaction logic for UpdatePharmacist.xaml
    /// </summary>
    public partial class PharmacistUpdateWindow : Window
    {
        public Pharmacist Pharmacist { get; set; }   
        private readonly IPharmacistRepository _repository;
        public PharmacistUpdateWindow()
        {
            InitializeComponent();
            this._repository = new PharmacistRepository();
        }
        public void SetData(Pharmacist pharmacist)
        {
            this.Pharmacist = pharmacist;
            tbFirstName.Text = pharmacist.FirstName;
            tbLastName.Text = pharmacist.LastName;
            dpBirthDate.Text = pharmacist.birth_date.ToString();
            tbPrice.Text = pharmacist.PharEmail;
            cmbGender.Text = pharmacist.gender;
            string imgPath = pharmacist.image_path;
            ImgBImage.ImageSource = new BitmapImage(new Uri(imgPath, UriKind.Relative));

        }
        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Pharmacist pharmacist = new Pharmacist();
            pharmacist.FirstName = tbFirstName.Text;
            pharmacist.LastName = tbLastName.Text;
            pharmacist.gender = cmbGender.Text;
            string imagepath = ImgBImage.ImageSource.ToString();
            if (!String.IsNullOrEmpty(imagepath))
                pharmacist.image_path = await CopyImageAsync(imagepath,
                    ContentConstants.IMAGE_CONTENTS_PATH);

            pharmacist.birth_date = DateTime.Parse(dpBirthDate.Text.ToString());
            pharmacist.PharEmail = string.Empty;
            pharmacist.CreatedAT = TimeHelper.GetDateTime();
            pharmacist.UpdatedAT = TimeHelper.GetDateTime();
            var result = await _repository.UpdateAsync(Pharmacist.PharId, pharmacist);
            if (result > 0)
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
            string path = System.IO.Path.Combine(destinationDirectory, imageName);
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
                                                                    