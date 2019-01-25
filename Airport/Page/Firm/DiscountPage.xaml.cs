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
    /// Interaction logic for DiscountPage.xaml
    /// </summary>
    public partial class DiscountPage : UserControl
    {
        public DiscountPage()
        {
            InitializeComponent();
            foreach (var item in NHiberControl.LoadBookingsToList())
            {
                Bookings_Combo.Items.Add(item);
            }


        }

        private void Bookings_Combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Bookings_Combo.SelectedIndex >= 0)
            {
                Booking bk = Bookings_Combo.SelectedItem as Booking;

                if (bk != null)
                {
                    Booking booking = NHiberControl.LoadBookingsToList().Single(x => x.id == bk.id);
                    if (booking.price > 0)
                    {
                        booking.price = booking.price - (int)(.2f * booking.price);
                        MessageBox.Show($"New price equals {booking.price} $.");
                    }
                    FirmNHiberControl.UpdateBooking(booking);
                    Bookings_Combo.Items.Clear();
                    foreach (var item in NHiberControl.LoadBookingsToList())
                    {
                        Bookings_Combo.Items.Add(item);
                    }
                }
            }
        }
    }
}
