using Airport.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Airport.Page.Firm
{
    /// <summary>
    /// Interaction logic for AirportPage.xaml
    /// </summary>
    public partial class AirportPage : UserControl
    {
        Model.Airport Airport;

        public AirportPage(Model.Airport airport)
        {
            InitializeComponent();
            Airport = airport;
            Airport_Workers.ItemsSource = FirmNHiberControl.GetAirportServices(Airport.id);
            Service.ItemsSource = FirmNHiberControl.GetServicesFromAirport(Airport.id);
        }

        private void Fuel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Airport_Workers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AirportService service = Airport_Workers.SelectedItem as AirportService;
            if (service != null)
            {
                FirmNHiberControl.FireAirportWorker(service);
                Airport_Workers.ItemsSource = FirmNHiberControl.GetAirportServices(Airport.id);
            }
        }

        private void Hire_Click(object sender, RoutedEventArgs e)
        {
            if (Job_Combo.SelectedIndex != -1)
            {
                AirportService airportService = new AirportService();
                airportService.idAirport = Airport.id;
                airportService.job = (Job_Combo.SelectedItem as ComboBoxItem).Content.ToString();
                airportService.SetSalary();

                FirmNHiberControl.HireAirportWorker(airportService);
                Airport_Workers.ItemsSource = FirmNHiberControl.GetAirportServices(Airport.id);
            }
        }
    }
}
