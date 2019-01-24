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
    }
}
