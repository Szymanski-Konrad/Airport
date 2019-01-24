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

namespace Airport.Page.ClientControl
{
    /// <summary>
    /// Interaction logic for Booking.xaml
    /// </summary>
    public partial class Booking : UserControl
    {
        public Booking()
        {
            InitializeComponent();
        }

        public Booking(Client client)
        {
            InitializeComponent();
            flightsBox.ItemsSource = NHiberControl.LoadFlightsToList();
            flightsBox.Items.Refresh();
        }
    }
}
