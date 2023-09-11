using Npgsql;
using Pharmcy.Constans;
using Pharmcy.Interfaces.Customers;
using Pharmcy.Windows.Customers;
using System.Windows.Controls;
using System.Data;
using Pharmcy.Repostories.Customers;
using Pharmcy.Utils;
using Pharmcy.Components.Medicines;
using Pharmcy.Entities.Medicines;
using Pharmcy.Interfaces.Medicines;
using System.Collections.Generic;
using Pharmcy.Entities.Customers;
using Pharmcy.Interfaces;
using System.Threading.Tasks;
using System.Linq;

namespace Pharmcy.Pages
{
    /// <summary>
    /// Interaction logic for CustomerPage.xaml
    /// </summary>
    public partial class CustomerPage : Page
    {
        private readonly ICustomerRepository _customerRepository;
        private IList<Customer> customers { get; set; }
        
        public CustomerPage()
        {
            InitializeComponent();
            this._customerRepository = new CustomerRepository();
        }
        private async void btnCreate_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            CreateCustomer createCustomer = new CreateCustomer();
            createCustomer.ShowDialog();
        }

        private async Task RefreshAsync()
        {
            wrpCustomer.Children.Clear();
            PaginationParams paginationParams = new PaginationParams()
            {
                PageNumber = 1,
                PageSize = 30

            };
            customers = await _customerRepository.GetAllAsync(paginationParams);

            //foreach (var med in customers)
            //{
            //    MedicineViewUserControl medicineViewUserControl = new MedicineViewUserControl();
            //    medicineViewUserControl.SetData(med);
            //    wrpMedicine.Children.Add(medicineViewUserControl);
            //}
        }


        PaginationParams paginationParams = new PaginationParams(1, 20);
        private async void Chiqarish_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            CustomerTablitsa.Items.Clear();
            var res = await _customerRepository.GetAllAsync(paginationParams);
            for (int i = 0; i < res.Count; i++)
            {
                CustomerTablitsa.Items.Add(res[i]);
            }

        }

        private void DataGridcha_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            //string str = tbSearch.Text;
            //var resultCustomer = customers.Where(m=>m.FirstName.ToLower().StartsWith(str)).ToList();
            //DataGridcha.Items.Clear();
            
            
            //var ruseltMedicines = Customers.Where(m)
            //var resultMedicine = Med1icines.Where(m => m.Name.ToLower().StartsWith(str)).ToList();
            //wrpMedicine.Children.Clear();
            


            //foreach (var m in resultMedicine)
            //{
            //    MedicineViewUserControl medicineViewUserControl = new MedicineViewUserControl();
            //    medicineViewUserControl.SetData(m);
            //    wrpMedicine.Children.Add(medicineViewUserControl);
            //}
        }
    }
}
