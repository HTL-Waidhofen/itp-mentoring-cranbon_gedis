using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
using WPF_Mentoring.Classes;

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
            if (string.IsNullOrWhiteSpace(Benutzername.Text) || string.IsNullOrWhiteSpace(PasswortAlt.Password) || string.IsNullOrWhiteSpace(PasswortNeu.Password) || string.IsNullOrWhiteSpace(PasswortNeuWiederholen.Password))
            {
                MessageBox.Show("Bitte füllen Sie alle Felder aus!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!Authentification.IsValidEmail(Benutzername.Text))
            {
                MessageBox.Show("Bitte geben Sie eine gültige E-Mail-Adresse ein.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                
            }
            else if (Authentification.IsValidEmail(Benutzername.Text))
            {
                main.user.Password = PasswortNeu.Password;
                main.user.Email = Benutzername.Text;

                
            }
            else if (isMentor.IsChecked == true)
            {
                main.user.isMentor = true;
            }
            else
            {
                main.user.isMentor = false;
            }


            if (PasswortNeu.Password != PasswortNeuWiederholen.Password)
            {
                // Passwörter stimmen nicht überein, Fehlermeldung anzeigen
                passwortNotMatch.Visibility = Visibility.Visible;
                return; // Stoppen Sie den weiteren Verarbeitungsfluss, um das Speichern zu verhindern.
            }
            Server_Manager.UpdateMA(main.user);
            MessageBox.Show("Ihre Daten wurden erfolgreich geändert.", "Erfolg", MessageBoxButton.OK, MessageBoxImage.Information);

        }
        private void aktualisieren(object sender, RoutedEventArgs e)
        {

        }

        private void speichernBeschreibung(object sender, RoutedEventArgs e)
        {

        }
    }
}
