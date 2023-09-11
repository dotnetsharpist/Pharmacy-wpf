using Pharmcy.Components.Medicines;
using Pharmcy.Components.Pharmacists;
using Pharmcy.Entities.Medicines;
using Pharmcy.Entities.Pharmacists;
using Pharmcy.Interfaces.Medicines;
using Pharmcy.Interfaces.Pharmacists;
using Pharmcy.Repostories.Pharmacists;
using Pharmcy.Utils;
using Pharmcy.Windows.Pharmacists;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents.Serialization;

namespace Pharmcy.Pages
{
    /// <summary>
    /// Interaction logic for Pharmacist.xaml
    /// </summary>
    public partial class PharmacistPage : Page
    {
        private readonly IPharmacistRepository _repository;
        private IList<Pharmacist> Pharmacists { get; set; }
        public PharmacistPage()
        {
            InitializeComponent();
            this._repository = new PharmacistRepository();
        }
        private async void btnCreate_pharmacist_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            CreatePharmacist createPharmacist = new CreatePharmacist();
            createPharmacist.ShowDialog();
            await RefreshAsync();
        }
        private async Task RefreshAsync()
        {
            wrpPharmacist.Children.Clear();
            PaginationParams paginationParams = new PaginationParams()
            {
                PageNumber = 1,
                PageSize = 30

            };
            Pharmacists = await _repository.GetAllAsync(paginationParams);
            
            foreach(var phar in Pharmacists)
            {
                PharmacistViewUserControl pharmacistViewUserControl = new PharmacistViewUserControl();
                pharmacistViewUserControl.SetData(phar);
                wrpPharmacist.Children.Add(pharmacistViewUserControl);
            }
        }
        private async void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            await RefreshAsync();
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string str = tbSearch.Text;
            var resultPharmacist = Pharmacists.Where(m => m.FirstName.ToLower().StartsWith(str)).ToList();
            wrpPharmacist.Children.Clear();
            foreach(var m in resultPharmacist)
            {
                PharmacistViewUserControl pharmacistViewUserControl = new PharmacistViewUserControl();
                pharmacistViewUserControl.SetData(m);
                wrpPharmacist.Children.Add(pharmacistViewUserControl);                    
            }
        }
    }
}
