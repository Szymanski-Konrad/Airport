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

namespace Airport.Page.ClientControl
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            List<Client> clients = NHiberControl.LoadClientsToList();
            if (clients.Exists(x => x.Name == name.Text && x.Surname == surname.Text))
            {
                Switcher.SwitchClient(new Page.ClientControl.Panel(clients.Single(x => x.Name == name.Text && x.Surname == surname.Text)));
            }
            else
            {
                MessageBox.Show("PODANE DANE SĄ NIEPRAWIDŁOWE");
            }
        }

        private void Name_GotFocus(object sender, RoutedEventArgs e)
        {
            name.CaptureMouse();
        }

        private void Name_GotMouseCapture(object sender, MouseEventArgs e)
        {
            name.SelectAll();
        }

        private void Name_IsMouseCaptureWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            name.SelectAll();
        }

        private void Surname_GotFocus(object sender, RoutedEventArgs e)
        {
            surname.CaptureMouse();
        }

        private void Surname_GotMouseCapture(object sender, MouseEventArgs e)
        {
            surname.SelectAll();
        }

        private void Surname_IsMouseCaptureWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            surname.SelectAll();
        }
    }
}
