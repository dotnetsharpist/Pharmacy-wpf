using Npgsql;
using Pharmcy.Constans;
using Pharmcy.Entities.Pharmacists;
using Pharmcy.Security;
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

namespace Pharmcy.Windows.Sigin
{
    /// <summary>
    /// Interaction logic for Loginwindow.xaml
    /// </summary>
    public partial class Loginwindow : Window
    {
        public Loginwindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Pharmacist pharmacist = new Pharmacist();
            //string email = email.Text;
            string email = tbEmail.Text;
            //string password = lb_password.Text;
            string password = tbPassword.ToString();
            var qwerty = await GetByEmail(email, password);
            MessageBox.Show(qwerty.ToString());
            MainWindow mainOyna1 = new MainWindow();
            mainOyna1.ShowDialog();

      
        }
        List<Pharmacist> pharmacist1 = new List<Pharmacist>();
        public async Task<bool> GetByEmail(string  email, string password_p)
        {
            int count = 0;
            await using ( var connection = new NpgsqlConnection(DBConstans.DB_CONNECTIONSTRING))
            {
                await connection.OpenAsync();
                string allview = $"select * from public.\"Pharmacist\" email = '{email}';";
                await using (var command = new NpgsqlCommand(allview, connection))
                {
                    await using (var reader = await command.ExecuteReaderAsync()) 
                    {
                        if(await reader.ReadAsync())
                        {
                            string email_check = reader.GetString(3);
                            string password_check = reader.GetString(4);
                            string salt_check = reader.GetString(7);

                            var check_all = PasswordHasher.Verify(password_p, password_check, salt_check);
                            if(check_all==true) { count += 1; }
                        }
                    }
                }
                await connection.CloseAsync();
            }
            return count > 0;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Border_MouseDown_1(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
