using Microsoft.VisualBasic;
using Npgsql;
using Pharmcy.Components.Medicines;
using Pharmcy.Constans;
using Pharmcy.Windows.Customers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
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

namespace Pharmcy.Windows
{
    /// <summary>
    /// Interaction logic for DataWindow.xaml
    /// </summary>
    public partial class DataWindow : Window
    {
        private NpgsqlConnection _connection;

        public DataTable dt { get; set; }

        public DataWindow()
        {
            InitializeComponent();
        }
        public DataWindow(DataTable dt)
        {
            InitializeComponent();
            this.dt=dt;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MyDataGrid.ItemsSource = dt.DefaultView;
        }

        private async void btnSAVE_Click(object sender, RoutedEventArgs e)
        {
            //_connection = new NpgsqlConnection(DBConstans.DB_CONNECTIONSTRING);

            //try
            //{
            //    await _connection.OpenAsync();
            //    MedicineViewUserControl1 m = new MedicineViewUserControl1();

            //    //string query = $"DELETE FROM public.\"Medicines\" WHERE name={sdfsdf} ;      
            //    //string qeury = $"Delete from public.\"Medicines\" where Name={m.lbName.Content};";
            //    string query = $"DELETE FROM public.\"Medicines\"   WHERE \"Name\"='{m.lbName.Content.ToString()}';";
            //    await using (var command = new NpgsqlCommand(query,_connection))
            //    {
            //        int natija = await command.ExecuteNonQueryAsync();
            //        if(natija > 0)
            //        {
            //            MessageBox.Show("Delete boldi");
            //        }
            //        return;
            //    }
            //}
            //catch(Exception ex)  
            //{                                                
            //    MessageBox.Show($"{ex.Message}");   
            //    return;
            //}
            //finally {await _connection.CloseAsync(); }




            CreateCustomer createCustomer = new CreateCustomer();
            createCustomer.ShowDialog();
        }

        private void MyDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}                                 