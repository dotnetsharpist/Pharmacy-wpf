using Npgsql;
using Pharmcy.Constans;
using Pharmcy.Entities.Medicines;
using Pharmcy.Interfaces.Medicines;
using Pharmcy.Pages;
using Pharmcy.Repostories.Medicines;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Pharmcy.Components.Medicines
{
    /// <summary>
    /// Interaction logic for MedicineViewUserControl1.xaml
    /// </summary>
    public partial class MedicineViewUserControl1 : UserControl
    {
        public int Sum { get; set; }
        private Medicine Medicine { get; set; }
        public int Sum1 { get; set; }
        public List<string> olingan_dorilar = new List<string>();
        private NpgsqlConnection _connection;
        public List<string> MyList { get; set; }
        public int Summa { get; set; }
        private readonly IMedicineRepository _medicineRepository;

        public MedicineViewUserControl1()
        {
            InitializeComponent();
            this._medicineRepository = new MedicineRepository();
            Medicine = new Medicine();
        }
        public void SetData(Medicine medicine)
        {
       
            ImgB.ImageSource = new BitmapImage(new System.Uri(medicine.image_path, UriKind.Relative));
            lbName.Content = medicine.Name;
            lbPrice.Content = medicine.Price;
            tbDescription.Text = medicine.Description;
            Medicine = medicine;
        }
        private void check1_Click(object sender, RoutedEventArgs e)
        {

        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            PharmacistPage pharmacistPage = new PharmacistPage();
            
            string nomi = lbName.Content.ToString();
            string narxi = lbPrice.Content.ToString();
            
            List<string> list = new List<string>();
            
            
            _connection = new NpgsqlConnection(DBConstans.DB_CONNECTIONSTRING);
            try
            {
                await _connection.OpenAsync();
                string query = "INSERT INTO public.\"olingandorilar\"(\"doriname\", \"dorinarxi\") VALUES (@doriname,@dorinarxi);";
                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@doriname", lbName.Content.ToString());
                    command.Parameters.AddWithValue("@dorinarxi", lbPrice.Content.ToString());
                    var dresult = await command.ExecuteNonQueryAsync();
                    if( dresult == 1 ) 
                    {
                        
                        Sum += int.Parse(lbPrice.Content.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                await _connection.CloseAsync();
            } 
            Sum1 += Sum;
        }
    }
}
