using Npgsql;
using Pharmcy.Components.Medicines;
using Pharmcy.Constans;
using Pharmcy.Entities.Medicines;
using Pharmcy.Entities.Purchasing;
using Pharmcy.Interfaces.Medicines;
using Pharmcy.Interfaces.Purchasings;
using Pharmcy.Pages;
using Pharmcy.Repostories.Medicines;
using Pharmcy.Repostories.Purchasings;
using Pharmcy.Utils;
using Pharmcy.Windows;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Pharmcy.Pages
{
    /// <summary>
    /// Interaction logic for Purchasing.xaml
    /// </summary>
    public partial class PurchasingPage : Page
    {
        private readonly IMedicineRepository _repository;
        private IList<Medicine> Medicines { get; set; }
        private NpgsqlConnection _connection;
        public List<string> list = new List<string>();
        public List<int> sum = new List<int>();
        public int SUM = 0;
        public PurchasingPage()
        {
            InitializeComponent();
            this._repository = new MedicineRepository();
        }
        private async Task RefreshAsync()
        {
            wrpPurchasing.Children.Clear();
            
            PaginationParams paginationParams = new PaginationParams()
            {
                PageNumber = 1,
                PageSize = 30

            };
            var medicines = await _repository.GetAllAsync(paginationParams);

            foreach (var med in medicines)
            {
                MedicineViewUserControl1 medicineViewUserControl = new MedicineViewUserControl1();
                medicineViewUserControl.SetData(med);
                wrpPurchasing.Children.Add(medicineViewUserControl);
            }
        }
        private async void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {   
            await RefreshAsync();
        } 

        private async void buy_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _connection = new NpgsqlConnection(DBConstans.DB_CONNECTIONSTRING);
            DataTable dt = new DataTable();
            
            try
            {
                
                await _connection.OpenAsync();
                string query = "select doriname,dorinarxi from public.\"olingandorilar\";";
                await using (var command = new NpgsqlCommand(query,_connection))                
                {
                    await using (var reader = await command.ExecuteReaderAsync())
                    {
                        dt.Load(reader);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                await _connection.CloseAsync();
            }
            try
            {
                await _connection.OpenAsync();
                string query = "select doriname,dorinarxi from public.\"olingandorilar\";";
                await using (var command = new NpgsqlCommand(query, _connection))
                {
                    await using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            sum.Add(int.Parse(reader.GetString(1)));
                        }
                        SUM = sum.Sum();
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

            DataWindow dataWindow = new DataWindow(dt);

            dataWindow.ozodbek.Content = $"{SUM}";
            dataWindow.Show();

            //try
            //{
            //    await _connection.OpenAsync();
            //    string query = "DELETE FROM public.\"olingandorilar\" WHERE \"id\">0;";
            //    await using (var command = new NpgsqlCommand(query, _connection))
            //    {
            //        int natija = await command.ExecuteNonQueryAsync();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    return;
            //}
            //finally
            //{
            //    await _connection.CloseAsync();
            //}
        }
        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            //string str = tbSearch.Text;

            //if (Medicines != null)
            //{
            //    var resultMedicine = Medicines.Where(m => m.Name.ToLower().StartsWith(str)).ToList();
            //    //foreach (var m in resultMedicine)
            //    foreach (var result in resultMedicine)
            //    {
            //        MedicineViewUserControl1 medicineViewUserControl1 = new MedicineViewUserControl1();
            //        medicineViewUserControl1.SetData(result);
            //        wrpPurchasing.Children.Add(medicineViewUserControl1);
            //    }
            //}

                
        }

    }
}
