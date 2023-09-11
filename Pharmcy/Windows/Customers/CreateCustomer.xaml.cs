using Pharmcy.Entities.Customers;
using Pharmcy.Helpers;
using Pharmcy.Interfaces.Customers;
using Pharmcy.Repostories.Customers;
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
using System.Windows.Shapes;

namespace Pharmcy.Windows.Customers
{
    /// <summary>
    /// Interaction logic for CreateCustomer.xaml
    /// </summary>
    public partial class CreateCustomer : Window
    {
        private readonly ICustomerRepository _customerRepository;
        public CreateCustomer()
        {
            InitializeComponent();
            this._customerRepository = new CustomerRepository();
        }

        private void tbName_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Customer cust = new Customer();
            cust.FirstName = tbFirstName.Text;
            cust.LastName = tbLastName.Text;
            cust.Age = int.Parse(tbAge.Text);
            cust.ContactAdd = tbPhoneNumber.Text;
            cust.UpdatedAT = TimeHelper.GetDateTime();
            cust.CreatedAT = TimeHelper.GetDateTime();

            var result = await _customerRepository.CreateAsync(cust);
            if (result > 0)
            {
                MessageBox.Show("Muvaffaqqiyatli saqlandi");
            }
            else
            {
                MessageBox.Show("Ma'lumotlar saqanmadi");
            }
        }

    }
}
