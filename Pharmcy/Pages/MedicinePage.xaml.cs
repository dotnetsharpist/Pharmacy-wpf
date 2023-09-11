using Pharmcy.Components.Medicines;
using Pharmcy.Entities.Medicines;
using Pharmcy.Interfaces.Medicines;
using Pharmcy.Repostories.Medicines;
using Pharmcy.Utils;
using Pharmcy.Windows.Medicines;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Pharmcy.Pages
{
    /// <summary>
    /// Interaction logic for Medicine.xaml
    /// </summary>
    public partial class MedicinePage : Page
    {

        private readonly IMedicineRepository _repository;
        private IList<Medicine> Medicines { get; set; }
        public MedicinePage()
        {
            InitializeComponent();
            this._repository = new MedicineRepository();
        }

        private async void btnCreate_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            CreateMedicine createMedicine = new CreateMedicine();
            createMedicine.ShowDialog();
            await RefreshAsync();
        }
        private async Task RefreshAsync()
        {
            wrpMedicine.Children.Clear();
            PaginationParams paginationParams = new PaginationParams()
            {
                PageNumber = 1,
                PageSize = 30

            };
            Medicines = await _repository.GetAllAsync(paginationParams);

            foreach (var med in Medicines)
            {
                MedicineViewUserControl medicineViewUserControl = new MedicineViewUserControl();    
                medicineViewUserControl.SetData(med);
                wrpMedicine.Children.Add(medicineViewUserControl);
            }
        }
        private void btnDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private async void Page_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            await RefreshAsync();
        }

        private async void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string str = tbSearch.Text;
            var resultMedicine = Medicines.Where(m => m.Name.ToLower().StartsWith(str)).ToList();
            wrpMedicine.Children.Clear();

            foreach(var m in resultMedicine)
            {
                MedicineViewUserControl medicineViewUserControl = new MedicineViewUserControl();
                medicineViewUserControl.SetData(m);
                wrpMedicine.Children.Add(medicineViewUserControl);
            }   
        }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
    }
}
