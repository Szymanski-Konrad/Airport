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
    /// Interaction logic for AirportMarketPage.xaml
    /// </summary>
    public partial class AirportMarketPage : UserControl
    {
        public AirportMarketPage()
        {
            InitializeComponent();
        }

        private void Airport_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Model.Airport airport = Airport_DataGrid.SelectedItem as Model.Airport;
            if (airport != null)
            {
                Switcher.firmSwitcher.NavigateOnFrame(new AirportPage(airport));
            }
        }

        private void NewAirport_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AirportMarket airport = NewAirport_DataGrid.SelectedItem as AirportMarket;
            if (airport != null)
            {
                FirmNHiberControl.BuyAirport(airport);
                NewAirport_DataGrid.ItemsSource = FirmNHiberControl.GetAirportMarkets();
            }
        }

        private void NewAirport_Click(object sender, RoutedEventArgs e)
        {
            Airport_DataGrid.Visibility = Visibility.Collapsed;
            NewAirport_DataGrid.Visibility = Visibility.Visible;
            NewAirport_DataGrid.ItemsSource = FirmNHiberControl.GetAirportMarkets();
        }

        private void Airport_Click(object sender, RoutedEventArgs e)
        {
            Airport_DataGrid.Visibility = Visibility.Visible;
            NewAirport_DataGrid.Visibility = Visibility.Collapsed;
            Airport_DataGrid.ItemsSource = FirmNHiberControl.GetAirports();
        }
    }
}
