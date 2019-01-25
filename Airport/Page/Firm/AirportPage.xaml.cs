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
            Warehouse warehouse = FirmNHiberControl.GetWarehouse(Airport.id);
            CurrentFuel.Text = warehouse.fuelAmount + "/" + warehouse.capacityGasTank;
            PlanesToSerivce_Combo.ItemsSource = FirmNHiberControl.GetFleetToService();
        }

        private void Fuel_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(AmountToBuy.Text, out int i))
            {
                if (i < 0)
                {
                    MessageBox.Show("Nie przyjmuje wartości ujemnych. Spróbuj ponownie z inną wartościa.");
                    return;
                }

                Warehouse warehouse = FirmNHiberControl.GetWarehouse(Airport.id);
                if (i <= warehouse.capacityGasTank - warehouse.fuelAmount)
                {
                    warehouse.fuelAmount += i;
                    FirmNHiberControl.BuyFuel(warehouse);
                    CurrentFuel.Text = warehouse.fuelAmount + "/" + warehouse.capacityGasTank;
                }
                else
                {
                    MessageBox.Show("Za dużo paliwa. Nie pomieścimy tyle.");
                }
            }
            else
            {
                MessageBox.Show("Przyjmuje tylko wartości liczbowe całkowite.");
            }
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

        private void Service_Click(object sender, RoutedEventArgs e)
        {
            if (PlanesToSerivce_Combo.SelectedIndex < 0)
            {
                MessageBox.Show("Wybierz samolot do serwisowania");
                return;
            }

            Fleet fleet = PlanesToSerivce_Combo.SelectedItem as Fleet;

            string type = (ServiceType_Combo.SelectedItem as ComboBoxItem).Content.ToString();
            Warehouse warehouse = FirmNHiberControl.GetWarehouse(Airport.id);

            switch (type)
            {
                case "Serwis":
                    Service service = new Service();
                    service.serviceType = "Serwis";
                    service.idPlane = fleet.id;
                    service.idAirport = Airport.id;
                    service.dateStart = DateTime.Today;
                    service.dateEnd = DateTime.Today.AddDays(3);
                    FirmNHiberControl.FleetInService(fleet);
                    FirmNHiberControl.SaveService(service);
                    Service.ItemsSource = FirmNHiberControl.GetServicesFromAirport(Airport.id);
                    break;
                case "Tankowanie":
                    if (fleet.capacityGasTank - fleet.fuel >= warehouse.fuelAmount)
                    {
                        MessageBox.Show("Nie ma tyle paliwa, żeby zatankować");
                        return;
                    }
                    service = new Service();
                    service.serviceType = "Tankowanie";
                    service.idPlane = fleet.id;
                    service.idAirport = Airport.id;
                    service.dateStart = DateTime.Today;
                    service.dateEnd = DateTime.Today.AddDays(1);
                    warehouse.fuelAmount -= (fleet.capacityGasTank - fleet.fuel);
                    FirmNHiberControl.TankFuel(warehouse);
                    FirmNHiberControl.FleetInService(fleet);
                    FirmNHiberControl.SaveService(service);
                    Service.ItemsSource = FirmNHiberControl.GetServicesFromAirport(Airport.id);
                    break;
            }
            Service.ItemsSource = FirmNHiberControl.GetServicesFromAirport(Airport.id);
            CurrentFuel.Text = warehouse.fuelAmount + "/" + warehouse.capacityGasTank;
            PlanesToSerivce_Combo.ItemsSource = FirmNHiberControl.GetFleetToService();
        }

        private void Service_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Service service = Service.SelectedItem as Service;
            if (service != null)
            {
                Fleet fleet = FirmNHiberControl.GetFleetByID(service.idPlane);
                FirmNHiberControl.FleetOutService(fleet);
                FirmNHiberControl.RemoveService(service);
                Service.ItemsSource = FirmNHiberControl.GetServicesFromAirport(Airport.id);
            }
        }
    }
}
