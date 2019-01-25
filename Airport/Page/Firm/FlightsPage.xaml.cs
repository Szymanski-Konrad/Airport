﻿using System;
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

namespace Airport.Page.Firm
{
    /// <summary>
    /// Interaction logic for FlightsPage.xaml
    /// </summary>
    public partial class FlightsPage : UserControl
    {
        Connection selectedConnection;

        public FlightsPage()
        {
            InitializeComponent();
            FillCombos();
            Connecitons_DataGrid.ItemsSource = FirmNHiberControl.GetConnections();
        }

        private void FillCombos()
        {
            var list = FirmNHiberControl.GetAirports();
            foreach (var item in list)
            {
                Start_Combo.Items.Add(item);
                End_Combo.Items.Add(item);
            }
        }

        private void MakeConnection_Click(object sender, RoutedEventArgs e)
        {
            Model.Airport start = (Start_Combo.SelectedItem as Model.Airport);
            Model.Airport end = (End_Combo.SelectedItem as Model.Airport);
            if (start == null || end == null)
            {
                MessageBox.Show("Wybierz początek i koniec.");
                return;
            }
            if (start != end)
            {
                if (FirmNHiberControl.MakeConnection(start, end))
                {
                    MessageBox.Show("Połączenie utworzone :)");
                    Connecitons_DataGrid.ItemsSource = FirmNHiberControl.GetConnections();
                }
                else
                {
                    MessageBox.Show("Takie połączenie już istnieje");
                }
            }
            else
            {
                MessageBox.Show("Lotnisko nie może być jednocześnie początkiem i końcem.");
            }
        }

        private void MakeFlight_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Start_DatePicker.SelectedDate.ToString());
            MessageBox.Show(End_DatePicker.SelectedDate.ToString());

            selectedConnection = null;
        }

        private void Connecitons_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedConnection = Connecitons_DataGrid.SelectedItem as Connection;

            if (selectedConnection != null)
            {
                NewConnection.Visibility = Visibility.Collapsed;
                NewFlight.Visibility = Visibility.Visible;
            }
        }

        private void Hide_Click(object sender, RoutedEventArgs e)
        {
            NewFlight.Visibility = Visibility.Collapsed;
            NewConnection.Visibility = Visibility.Visible;
            selectedConnection = null;
        }
    }
}
