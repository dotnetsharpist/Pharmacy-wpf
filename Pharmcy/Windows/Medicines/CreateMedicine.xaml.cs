using Microsoft.Win32;
using Pharmcy.Constans;
using Pharmcy.Entities.Medicines;
using Pharmcy.Helpers;
using Pharmcy.Interfaces.Medicines;
using Pharmcy.Repostories.Medicines;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Pharmcy.Windows.Medicines
{
    /// <summary>
    /// Interaction logic for CreateMedicine.xaml
    /// </summary>
    public partial class CreateMedicine : Window
    {
        private readonly IMedicineRepository _medicineRepository;
        public CreateMedicine()
        {
            InitializeComponent();
            this._medicineRepository = new MedicineRepository();

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

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {

            Medicine m = new Medicine();
            m.Name = tbName.Text;
            m.MedCategory = cmbBoxCategory.Text;

            string imagepath = ImgBImage.ImageSource.ToString();
            if (!String.IsNullOrEmpty(imagepath))
                m.image_path = await CopyImageAsync(imagepath,
                    ContentConstants.IMAGE_CONTENTS_PATH);


            m.Description = new TextRange(rbDescription.Document.ContentStart, rbDescription.Document.ContentEnd).Text;
            m.Price = tbPrice.Text;
            m.CreatedAT = TimeHelper.GetDateTime();
            m.UpdatedAT = TimeHelper.GetDateTime();

            m.CreatTime = TimeHelper.GetDateTime();
            m.EndTime = TimeHelper.GetDateTime();



            var result = await _medicineRepository.CreateAsync(m);
            if(result>0)
            {
                MessageBox.Show("Muvaffaqqiyatli saqlandi");
                this.Close();
            }
        }
        private async Task<string> CopyImageAsync(string imgPath, string destinationDirectory)
        {
            if(!Directory.Exists(destinationDirectory))
                Directory.CreateDirectory(destinationDirectory);

            var imageName = ContentNameMaker.GetImageName(imgPath);
            string path = System.IO.Path.Combine(destinationDirectory, imageName);

            
            byte[] image = await File.ReadAllBytesAsync(imgPath);
            await File.WriteAllBytesAsync(path, image);
            return path;
        }

        private void rbDescription_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tbPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void tbPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
