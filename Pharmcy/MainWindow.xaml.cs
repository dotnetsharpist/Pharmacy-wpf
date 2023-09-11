using Pharmcy.Pages;
using Pharmcy.Pages.Security;
using Pharmcy.Windows;
using System.Windows;
using System.Windows.Input;

namespace Pharmcy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void brDragable_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void BtnMinimaze_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void BtnMaxmize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
            //Application.Exit();
        }
        private void rbCustomer_Click(object sender, RoutedEventArgs e)
        {
            CustomerPage customer = new CustomerPage();
            PageNavigator.Content = customer;
        }

        private void rbMedicine_Click(object sender, RoutedEventArgs e)
        {
            MedicinePage medicine = new MedicinePage();
            PageNavigator.Content = medicine;
        }

        private void rbPurchasing_Click(object sender, RoutedEventArgs e)
        {
            PurchasingPage pur = new PurchasingPage();
            PageNavigator.Content = pur;

        }

        private void rbReport_Click(object sender, RoutedEventArgs e)
        {
            ReportPage report = new ReportPage();
            PageNavigator.Content = report;
        }

        private void rbPharmacist_Click(object sender, RoutedEventArgs e)
        {
            PharmacistPage pharmacistPage1 = new PharmacistPage();
            PageNavigator.Content = pharmacistPage1;
            //PharmacistSecurityPage pharmacistSecurityPage = new PharmacistSecurityPage();
            //PageNavigator.Content = pharmacistSecurityPage;
            //if (pharmacistSecurityPage.tbPassword.Password == "12345678" && pharmacistSecurityPage.tbEmail.Text == "jumakulovozodbek007@gmail.com")
            //{
            //    PharmacistPage pharmacistPage = new PharmacistPage();
            //    PageNavigator.Content = pharmacistPage;
            //}
        }

        private void rbInformation_Click(object sender, RoutedEventArgs e)
        {
            AboutInformationPage about = new AboutInformationPage();
            PageNavigator.Content = about;
        }

        private void rbAbout_Click(object sender, RoutedEventArgs e)
        {
            AboutInfomration aboutPage = new AboutInfomration();
            PageNavigator.Content = aboutPage;
        }

        private void rbMedicine_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rbCustomer_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rbInformation_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rbAbout_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void PageNavigator_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            
        }

        private void rbPharmacist_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
