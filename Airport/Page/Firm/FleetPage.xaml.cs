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
    /// Interaction logic for FleetPage.xaml
    /// </summary>
    public partial class FleetPage : UserControl
    {
        public FleetPage()
        {
            InitializeComponent();
        }

        private void Fleet_Click(object sender, RoutedEventArgs e)
        {
            newAirplanes_DataGrid.Visibility = Visibility.Collapsed;
            Fleet_DataGrid.Visibility = Visibility.Visible;
            Fleet_DataGrid.ItemsSource = FirmNHiberControl.GetFleets();
        }

        private void NewAirplane_Click(object sender, RoutedEventArgs e)
        {
            newAirplanes_DataGrid.ItemsSource = CustomData.GetBuyList();
            Fleet_DataGrid.Visibility = Visibility.Collapsed;
            newAirplanes_DataGrid.Visibility = Visibility.Visible;
        }

        private void NewAirplanes_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PlaneMarket plane = newAirplanes_DataGrid.SelectedItem as PlaneMarket;
            if (plane != null)
            {
                if (plane.price <= GameStats.account)
                {
                    FirmNHiberControl.BuyPlane(plane);
                    GameStats.account -= plane.price;
                    MessageBox.Show(GameStats.account.ToString());
                }
            }
        }

        private void Fleet_DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Fleet fleet = Fleet_DataGrid.SelectedItem as Fleet;
            if (fleet != null)
            {
                //GameStats.account +=
                FirmNHiberControl.SoldPlane(fleet);
                Fleet_DataGrid.ItemsSource = FirmNHiberControl.GetFleets();
            }
        }
    }
}
