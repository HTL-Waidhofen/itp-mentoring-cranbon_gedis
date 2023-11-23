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

namespace WPF_Mentoring.Pages
{
    /// <summary>
    /// Interaktionslogik für NA.xaml
    /// </summary>
    public partial class NAV : Page
    {
        public static MainWindow main;
        public NAV()
        {
            InitializeComponent();
        }

        private void einstellungen(object sender, RoutedEventArgs e)
        {
            main.rahmen_frame.Content = new Einstellungen();
        }

        private void LadeAbteilungen()
        {
            // Hier könntest du tatsächlich Daten aus einer Datenquelle laden.
            // Für dieses Beispiel fügen wir statische Abteilungen hinzu.
            // Füge die Abteilungen zur ComboBox hinzu.
        }

        private void AbteilungsComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Aktiviere die FachComboBox nur, wenn eine Abteilung ausgewählt ist.
            FachComboBox.IsEnabled = AbteilungsComboBox.SelectedIndex != 1;

            if (AbteilungsComboBox.SelectedIndex == 1)
            {

                Informatik.Visibility = Visibility.Visible;
            }
            // Zeige oder verstecke die FachComboBox je nach Auswahl.
            FachComboBox.Visibility = AbteilungsComboBox.SelectedIndex != 1 ? Visibility.Visible : Visibility.Collapsed;
        }
        private void abmelden(object sender, RoutedEventArgs e)
        {
            main.rahmen_frame.Content = new Anmeldung();
        }
    }
}
