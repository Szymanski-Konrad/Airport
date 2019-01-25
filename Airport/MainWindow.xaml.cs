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

using Airport.Model;
using Airport.Page;

namespace Airport
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //NHiberControl.SaveGame();
            //NHiberControl.SaveGame();
            //NHiberControl.LoadGames();
            //NHiberControl.InsertFirm();
            NHiberControl.SaveClient();
            NHiberControl.SaveAirport("Bialystok");
            NHiberControl.SaveAirport("Kolno");
            NHiberControl.SaveConnection();
            NHiberControl.InsertConnection(2, 1, 90);
            NHiberControl.SaveFlight();
            NHiberControl.InsertFlight(2, 2, new DateTime(2019, 2, 1, 12, 30, 30), new TimeSpan(1, 30, 0));
            NHiberControl.SaveBooking();

            NHiberControl.RefreshTables();
            FirmNHiberControl.SaveAirportMarkets(CustomData.GetBuyAirportList());
            GameStats.account = 100000;
        }

        private void FirmWindow_Click(object sender, RoutedEventArgs e)
        {
            new FirmWindow().ShowDialog();
        }

        private void ClientWindow_Click(object sender, RoutedEventArgs e)
        {
            new ClientWindow().ShowDialog();
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
