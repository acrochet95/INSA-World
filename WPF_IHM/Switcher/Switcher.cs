using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WPF_IHM;

namespace WPF_IHM
{
    public static class Switcher
    {
        public static MainWindow pageSwitcher;

        public static void Switch(Page newPage)
        {
            pageSwitcher.Navigate(newPage);
        }

        public static void Switch(Page newPage, object state)
        {
            pageSwitcher.Navigate(newPage, state);
        }
    }
}
