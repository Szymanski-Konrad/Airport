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

namespace Airport.Page
{
    /// <summary>
    /// Interaction logic for FirmWindow.xaml
    /// </summary>
    public partial class FirmWindow : Window
    {
        public FirmWindow()
        {
            InitializeComponent();
            Switcher.firmSwitcher = this;
        }

        private void FlightPage_Click(object sender, RoutedEventArgs e)
        {
            //Switcher.SwitchFirm(new Page.Firm.FleetPage());
            frame.NavigationService.Navigate(new Page.Firm.FlightsPage());
        }

        private void AirportPage_Click(object sender, RoutedEventArgs e)
        {
            //Switcher.SwitchFirm(new Page.Firm.AirportPage());
            frame.NavigationService.Navigate(new Page.Firm.AirportMarketPage());
        }

        private void Discount_Click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Page.Firm.DiscountPage());
        }

        private void Planes_Click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Page.Firm.FleetPage());
        }

        public void NavigateOnFrame(UserControl nextPage)
        {
            frame.NavigationService.Navigate(nextPage);
        }

        public void Navigate(UserControl nextPage)
        {
            this.Content = nextPage;
        }

        public void Navigate(UserControl nextPage, object state)
        {
            this.Content = nextPage;
            ISwitchable s = nextPage as ISwitchable;

            if (s != null)
                s.UtilizeState(state);
            else
                throw new ArgumentException("NextPage is not ISwitchable! " + nextPage.Name.ToString());
        }
    }
}
