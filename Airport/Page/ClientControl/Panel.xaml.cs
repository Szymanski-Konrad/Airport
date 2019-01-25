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
    /// Interaction logic for Panel.xaml
    /// </summary>
    public partial class Panel : UserControl
    {
        Client client;
        public Panel()
        {
            InitializeComponent();
        }

        public Panel(Client client)
        {
            this.client = client;
            InitializeComponent();
            name.Content = client.Name;
            surname.Content = client.Surname;
            if (client.isMale)
            {
                sex.Content = "male";
            }
            else
            {
                sex.Content = "female";
            }
            miles.Content = client.milesTraveled;
            age.Content = client.age.ToString();
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            Switcher.SwitchClient(new Page.ClientControl.Login());
        }

        private void BookingButton_Click(object sender, RoutedEventArgs e)
        {
            Switcher.SwitchClient(new Page.ClientControl.Booking(client));
        }

        private void BookedButton_Click(object sender, RoutedEventArgs e)
        {
            Switcher.SwitchClient(new Page.ClientControl.Booked(client));
        }
    }
}
