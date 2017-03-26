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
    /// Logique d'interaction pour Page2.xaml
    /// </summary>
    public partial class Page2 : Page, ISwitchable
    {
        private const double OPACITY_HIGH = 1;
        private const double OPACITY_LOW = 0.4;

        private String race_player1 = "";
        private String race_player2 = "";
        private String mapSelected = "";

        public Page2()
        {
            InitializeComponent();

            demoMap.MouseLeftButtonUp += new MouseButtonEventHandler(chooseMap);
            smallMap.MouseLeftButtonUp += new MouseButtonEventHandler(chooseMap);
            standardMap.MouseLeftButtonUp += new MouseButtonEventHandler(chooseMap);
        }

        private void chooseMap(Object sender, RoutedEventArgs e)
        {
            StackPanel sp = sender as StackPanel;

            demoMap.Opacity = OPACITY_HIGH;
            smallMap.Opacity = OPACITY_HIGH;
            standardMap.Opacity = OPACITY_HIGH;
            if (sp == demoMap)
            {
                smallMap.Opacity = OPACITY_LOW;
                standardMap.Opacity = OPACITY_LOW;
                mapSelected = "demo";
            }
            else if (sp == smallMap)
            {
                demoMap.Opacity = OPACITY_LOW;
                standardMap.Opacity = OPACITY_LOW;
                mapSelected = "small";
            }
            else
            {
                demoMap.Opacity = OPACITY_LOW;
                smallMap.Opacity = OPACITY_LOW;
                mapSelected = "standard";
            }
        }

        private void Start_Game_Click(Object sender, RoutedEventArgs e)
        {
            if (!mapSelected.Equals("") && !name_player1.Text.Equals("") && !race_player1.Equals("") && !name_player2.Text.Equals("") && !race_player2.Equals(""))
                Switcher.Switch(new Game(mapSelected, name_player1.Text, race_player1, name_player2.Text, race_player2));
        }

        private void Cancel_Click(Object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new Page1());
        }

        private void RadioButtonChecked1(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            this.race_player1 = (String)rb.Content;

            cyclop2.IsEnabled = true;
            centaur2.IsEnabled = true;
            cerberus2.IsEnabled = true;

            RadioButton rb_player2 = null;
            if (this.race_player1.Equals("Cyclope"))
                rb_player2 = cyclop2;
            else if (this.race_player1.Equals("Centaure"))
                rb_player2 = centaur2;
            else
                rb_player2 = cerberus2;

            rb_player2.IsChecked = false;
            rb_player2.IsEnabled = false;
        }

        private void RadioButtonChecked2(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            this.race_player2 = (String)rb.Content;

            cyclop1.IsEnabled = true;
            centaur1.IsEnabled = true;
            cerberus1.IsEnabled = true;

            RadioButton rb_player1 = null;
            if (this.race_player2.Equals("Cyclope"))
                rb_player1 = cyclop1;
            else if (this.race_player2.Equals("Centaure"))
                rb_player1 = centaur1;
            else
                rb_player1 = cerberus1;

            rb_player1.IsChecked = false;
            rb_player1.IsEnabled = false;

        } 
    }
}
