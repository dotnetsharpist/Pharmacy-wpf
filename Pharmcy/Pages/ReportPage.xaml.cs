using Npgsql;
using Pharmcy.Constans;
using Pharmcy.Entities.Medicines;
using Pharmcy.Interfaces.Medicines;
using Pharmcy.Repostories.Medicines;
using Pharmcy.Utils;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Security.Cryptography;
using System.Windows.Controls;

namespace Pharmcy.Pages
{
    /// <summary>
    /// Interaction logic for ReportPage.xaml
    /// </summary>
    public partial class ReportPage : Page
    {
        //private NpgsqlConnection _connection;
        //private readonly IXodimlarRepository _xodimRepository;
        private readonly IMedicineRepository _medicineRepostory;
        private NpgsqlConnection _connection;

        public ReportPage()
        {
            InitializeComponent();
            this._medicineRepostory =new MedicineRepository();
            //_connection = new NpgsqlConnection(DBConstans.DB_CONNECTIONSTRING);
            //_connection.Open();
            //NpgsqlCommand command = new NpgsqlCommand();
            //command.Connection = _connection;
            //command.CommandType = System.Data.CommandType.Text;
            //command.CommandText = "select * from public.\"Medicines\";";
            //NpgsqlDataReader reader = command.ExecuteReader();
            //if(reader.HasRows)
            //{
            //    DataTable dt = new DataTable();
            //    dt.Load(reader);
            //    DataGridcha.ItemsSource = dt.;   
            //}
            //command.Dispose();
            //command.Clone();

        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

       

        private void DataGridcha_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        PaginationParams paginationParams = new PaginationParams(1, 20);
        private async void outputFiles_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
            DataGridcha.Items.Clear();
            //var result = await _xodimRepository.GetAllAsync(paginationParams);
            var res = await _medicineRepostory.GetAllAsync(paginationParams);

            for (int i = 0; i < res.Count; i++)
            {
                DataGridcha.Items.Add(res[i]);
            }
        }
    }
}
