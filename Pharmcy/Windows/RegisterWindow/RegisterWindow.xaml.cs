using Npgsql;
using Pharmcy.Constans;
using Pharmcy.Entities.Pharmacists;
//using Pharmcy.Entities.Pharmacist;
using Pharmcy.Security;
using Pharmcy.Windows.Sigin;
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

namespace Pharmcy.Windows.Register
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }
        private async void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Pharmacist pharmacist = new Pharmacist();
            pharmacist.FirstName = tbFirstName.Text;
            pharmacist.LastName = tbLastName.Text;
            if(tbEmail.Text.EndsWith("@gmail.com"))
            {
                pharmacist.PharEmail = tbEmail.Text;
                pharmacist.PharPass = tbPassword.Password.ToString();
                var hasherResult = PasswordHasher.Hash(pharmacist.PharPass);
                pharmacist.salt = hasherResult.Salt;
                try
                {
                    bool dbresult = await RegisterAsync(pharmacist);
                    if(dbresult)
                    {
                        MessageBox.Show("Muvaffaqiyatli saqlandi!");
                        this.Hide();
                        MainWindow MainOyna = new MainWindow();
                        MainOyna.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Malumotlar saqlanmadi ");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Xatolik yuz berdi {ex}");
                }

            }
            else
            {
                MessageBox.Show("Nimadirni xato tarzda kiritdingiz qaytadan kiriting");
            }
                
            
        }
        public async Task<bool> RegisterAsync(Pharmacist pharmacist)
        {
            int result = 0;
            await using ( var connection = new NpgsqlConnection(DBConstans.DB_CONNECTIONSTRING))
            {
                await connection.OpenAsync();
                string query = "INSERT INTO public.\"Pharmacist\"(\"FirstName\", " +
                    "\"LastName\", " +
                    "\"PharEmail\", " +
                    "\"PharPass\", " +
                    "salt) VALUES (@FirstName,@LastName,@PharEmail,@PharPass,@salt);";
                await using (var command = new NpgsqlCommand(query, connection))
                {
                    pharmacist.Age = 24;
                    command.Parameters.AddWithValue("FirstName", pharmacist.FirstName);
                    command.Parameters.AddWithValue("LastName",pharmacist.LastName);
                    command.Parameters.AddWithValue("PharEmail", pharmacist.PharEmail);
                    command.Parameters.AddWithValue("PharPass", pharmacist.PharPass);
                    command.Parameters.AddWithValue("salt", pharmacist.salt);
                    result = await command.ExecuteNonQueryAsync();
                }
                await connection.CloseAsync();
            }
            return result > 0;   
            
        }
        private void Border_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            Loginwindow loginwindow = new Loginwindow();
            loginwindow.ShowDialog();
        }
    }

}

