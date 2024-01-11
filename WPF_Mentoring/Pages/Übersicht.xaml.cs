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
using WPF_Mentoring.Classes;

namespace WPF_Mentoring.Pages
{
    /// <summary>
    /// Interaktionslogik für Übersicht.xaml
    /// </summary>
    public partial class Übersicht : Page
    {
        public static MainWindow main;
        public Übersicht()
        {
            InitializeComponent();
            main.delNav();
        }

        private void mentoren(object sender, RoutedEventArgs e)
        {
            main.rahmen_frame.Content = new Mentor();
        }

        private void einstellungen(object sender, RoutedEventArgs e)
        {
            main.rahmen_frame.Content = new Einstellungen();
        }

        private void suche(object sender, RoutedEventArgs e)
        {
            main.rahmen_frame.Content = new NAV();
        }

        private void abmelden(object sender, RoutedEventArgs e)
        {
            main.rahmen_frame.Content = new Anmeldung();
        }
    }
}
