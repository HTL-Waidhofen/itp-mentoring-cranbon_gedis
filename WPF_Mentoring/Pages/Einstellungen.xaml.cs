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
            main.createNav();
        }

        private void btnKonto_Click(object sender, RoutedEventArgs e)
        {
            ShowPanel(KontoPanel);
        }

        private void btnBeschreibung_Click(object sender, RoutedEventArgs e)
        {
            ShowPanel(BeschreibungPanel);
        }

        private void btnFaecher_Click(object sender, RoutedEventArgs e)
        {
            ShowPanel(FaecherPanel);
        }

        private void btnUebersicht_Click(object sender, RoutedEventArgs e)
        {
            ShowPanel(ÜbersichtPanel);
        }
        private void ShowPanel(StackPanel panelToShow)
        {
            // Setze die Sichtbarkeit aller Panels auf Collapsed
            KontoPanel.Visibility = Visibility.Collapsed;
            BeschreibungPanel.Visibility = Visibility.Collapsed;
            FaecherPanel.Visibility = Visibility.Collapsed;
            ÜbersichtPanel.Visibility = Visibility.Collapsed;

            // Zeige das entsprechende Panel
            panelToShow.Visibility = Visibility.Visible;
        }

        private void speichern(object sender, RoutedEventArgs e)
        {
            if (Passwort.Password != PasswortWiederholen.Password)
            {
                // Passwörter stimmen nicht überein, Fehlermeldung anzeigen
                passwortNotMatch.Visibility = Visibility.Visible;
                return; // Stoppen Sie den weiteren Verarbeitungsfluss, um das Speichern zu verhindern.
            }

            // Hier können Sie den Code für das Speichern der Kontoinformationen implementieren

            // Wenn das Speichern erfolgreich war, können Sie das Label zurücksetzen
            passwortNotMatch.Visibility = Visibility.Collapsed;
        }

        private void aktualisieren(object sender, RoutedEventArgs e)
        {

        }

        private void speichernBeschreibung(object sender, RoutedEventArgs e)
        {

        }
    }
}
