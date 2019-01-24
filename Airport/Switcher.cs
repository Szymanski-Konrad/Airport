using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using Airport.Page;

namespace Airport
{
    public static class Switcher
    {
        public static ClientWindow clientSwitcher;
        public static FirmWindow firmSwitcher;


        public static void SwitchClient(UserControl page)
        {
            clientSwitcher.Navigate(page);
        }

        public static void SwitchClient(UserControl newPage, object state)
        {
            clientSwitcher.Navigate(newPage, state);
        }

        public static void SwitchFirm(UserControl page)
        {
            firmSwitcher.Navigate(page);
        }

        public static void SwitchFirm(UserControl newPage, object state)
        {
            firmSwitcher.Navigate(newPage, state);
        }
    }
}
