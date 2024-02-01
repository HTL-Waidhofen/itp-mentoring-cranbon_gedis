using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Collections.ObjectModel;

namespace WPF_Mentoring.Pages
{
    /// <summary>
    /// Interaktionslogik für Mentorensuche.xaml
    /// </summary>
    public partial class Mentorensuche : Page
    {
        public static MainWindow main;
        public ObservableCollection<DeinDatenTyp> MeineDaten { get; set; }

        public Mentorensuche()
        {
            InitializeComponent();
            MeineDaten = new ObservableCollection<DeinDatenTyp>();
            MeineDaten.Add(new DeinDatenTyp { Name = "Wert1", Abteilung = "Wert2" });
            MeineDaten.Add(new DeinDatenTyp { Name = "Wert3", Abteilung = "Wert4" });
            MeineDaten.Add(new DeinDatenTyp { Name = "Wert3", Abteilung = "Wert4" });
            MeineDaten.Add(new DeinDatenTyp { Name = "Wert3", Abteilung = "Wert4" });
            MeineDaten.Add(new DeinDatenTyp { Name = "Wert3", Abteilung = "Wert4" });
            MeineDaten.Add(new DeinDatenTyp { Name = "Wert3", Abteilung = "Wert4" });
            MeineDaten.Add(new DeinDatenTyp { Name = "Wert3", Abteilung = "Wert4" });
            MeineDaten.Add(new DeinDatenTyp { Name = "Wert3", Abteilung = "Wert4" });

            MeineDataGrid.ItemsSource = MeineDaten;
            main.createNav();

        }
        public class DeinDatenTyp
        {
            public string Name { get; set; }
            public string Abteilung { get; set; }
            public string Email { get; set; }
            List<Mentor> mitarbeiterListe = new List<Mentor>
            {
                //New machen klasse Mitarbeiter gibts ned
            //new Mentor { Name = "Max Mustermann", Stufe = "Senior", Abteilung = "Entwicklung", Email = "max.mustermann@example.com" }
                
            };
            public string AusgewählterWert { get; set; }
        }

        private void SortierenButton_Click(object sender, RoutedEventArgs e)
        {
            // Liste sortieren daten fehlt datentyp
            //daten = new ObservableCollection<string>(daten.OrderBy(x => x));
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        /* using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

public partial class MainWindow : Window
{
    public ObservableCollection<DeinDatenTyp> MeineDaten { get; set; }

    public MainWindow()
    {
        InitializeComponent();

        MeineDaten = new ObservableCollection<DeinDatenTyp>();
        MeineDaten.Add(new DeinDatenTyp { Eigenschaft1 = "Wert1", Eigenschaft2 = "Wert2" });
        MeineDaten.Add(new DeinDatenTyp { Eigenschaft1 = "Wert3", Eigenschaft2 = "Wert4" });

        MeineDataGrid.ItemsSource = MeineDaten;
    }

    private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (MeineDataGrid.SelectedItem != null)
        {
            // Hier kannst du auf den ausgewählten Wert zugreifen und speichern.
            DeinDatenTyp ausgewaehlteDaten = (DeinDatenTyp)MeineDataGrid.SelectedItem;

            // Beispiel: Zeige eine MessageBox mit dem ausgewählten Wert an.
            MessageBox.Show($"Ausgewählter Wert: {ausgewaehlteDaten.Eigenschaft1}");
        }
    }
}
*/

    }
}




