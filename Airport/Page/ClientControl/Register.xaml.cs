using Airport.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Register : UserControl
    {
        public Register()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            Debug.Print($"Register.xaml.cs method RegisterButton_Click called.");
            List<Client> clients = NHiberControl.LoadClientsToList();
            if (int.TryParse(age.Text, out int n))
            {
                if (!clients.Exists(x => x.Name == name.Text && x.Surname == surname.Text))
                {
                    NHiberControl.InsertClient(name.Text, surname.Text, isMale.IsChecked.Value, 0, Int32.Parse(age.Text));
                    MessageBox.Show("UDAŁO SIĘ ZAREJESTROWAĆ");
                    Switcher.SwitchClient(new Page.ClientControl.Login());
                }
                else
                {
                    Debug.Print("Such client already exists.");
                    MessageBox.Show("KLIENT O PODANYM IMIENIU I NAZWISKU ISTNIEJE");
                }
            }
            else
            {
                Debug.Print("Age is not a number.");
            }
        }
    }
}
