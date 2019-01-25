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
    public partial class Booked : UserControl
    {
        Client client;
        int? selectedBooking;
        public Booked()
        {
            InitializeComponent();
        }

        public Booked(Client client)
        {
            InitializeComponent();
            this.client = client;
            bookingsBox.ItemsSource = NHiberControl.LoadBookingsToList().Where(x=>x.idClient == client.id);
            bookingsBox.Items.Refresh();
            selectedBooking = null;
        }

        private void BookingsBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedBooking = bookingsBox.SelectedIndex + 1;

            Switcher.SwitchClient(new Page.ClientControl.Panel(client));
        }
    }
}
