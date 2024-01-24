using Microsoft.AspNetCore.Mvc.ModelBinding;
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
namespace WPF_Mentoring.Pages
{
    /// <summary>
    /// Interaktionslogik für Mentorensuche.xaml
    /// </summary>
    public partial class Mentorensuche : Page
    {
        private ObservableCollection<string> daten = new ObservableCollection<string>();
        public static MainWindow main;

        public Mentorensuche()
        {
            InitializeComponent();

            main.createNav();
        }
        public class Mitarbeiter
        {
            public string Name { get; set; }
            public string Stufe { get; set; }
            public string Abteilung { get; set; }
            public string Email { get; set; }
            List<Mitarbeiter> mitarbeiterListe = new List<Mitarbeiter>
            {
            new Mitarbeiter { Name = "Max Mustermann", Stufe = "Senior", Abteilung = "Entwicklung", Email = "max.mustermann@example.com" }
                // Füge weitere Mitarbeiter hinzu...
            };

            // Beispiel-Daten hinzufügen
            daten.Add("Banane");
            daten.Add("Apfel");
            daten.Add("Orange");
            daten.Add("Erdbeere");

            // ListBox mit Datenquelle verbinden
            MeineListBox.ItemsSource = daten;
        }

        private void SortierenButton_Click(object sender, RoutedEventArgs e)
        {
            // Liste sortieren
            daten = new ObservableCollection<string>(daten.OrderBy(x => x));
            MeineListBox.ItemsSource = daten;
        }
    }
}




