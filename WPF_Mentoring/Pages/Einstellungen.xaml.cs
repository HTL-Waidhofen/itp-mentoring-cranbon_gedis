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
using WPF_Mentoring;

namespace WPF_Monitoring.Pages
{
    /// <summary>
    /// Interaktionslogik für Einstellungen.xaml
    /// </summary>
    public partial class Einstellungen : Page
    {
        public static MainWindow main;
        public Einstellungen()
        {
            InitializeComponent();
        }

        private void btnKonto_Click(object sender, RoutedEventArgs e)
        {
            ShowPanel(KontoPanel);
        }

        private void btnName_Click(object sender, RoutedEventArgs e)
        {
            ShowPanel(NamePanel);
        }

        private void btnEmail_Click(object sender, RoutedEventArgs e)
        {
            ShowPanel(EmailPanel);
        }

        private void btnBeschreibung_Click(object sender, RoutedEventArgs e)
        {
            ShowPanel(BeschreibungPanel);
        }

        private void btnFaecher_Click(object sender, RoutedEventArgs e)
        {
            ShowPanel(FaecherPanel);
        }

        private void ShowPanel(StackPanel panelToShow)
        {
            // Setze die Sichtbarkeit aller Panels auf Collapsed
            KontoPanel.Visibility = Visibility.Collapsed;
            NamePanel.Visibility = Visibility.Collapsed;
            EmailPanel.Visibility = Visibility.Collapsed;
            BeschreibungPanel.Visibility = Visibility.Collapsed;
            FaecherPanel.Visibility = Visibility.Collapsed;

            // Zeige das entsprechende Panel
            panelToShow.Visibility = Visibility.Visible;
        }
    }
}
