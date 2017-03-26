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
using WPF_IHM.Pages;

namespace WPF_IHM
{
    /// <summary>
    /// Logique d'interaction pour Page1.xaml
    /// </summary>
    public partial class Page1 : Page, ISwitchable
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void New_Game_Click(Object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Page2(), null);
        }


        private void Help_Click(Object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Page2(), null);
        }

        private void Load(Object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Game("defaultSave.dat"), null);
        }
    }
}
