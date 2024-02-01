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
            public ObservableCollection<Person> DeineObservableCollection { get; set; }

        public Mentorensuche()
        {
            InitializeComponent();
            main.createNav();
            DeineObservableCollection = new ObservableCollection<Person>
        {
            new Person { Name = "Max", Fach = "Sew" , Klasse="3"},
            new Person { Name = "Max", Fach = "Sew" , Klasse="3" },
            new Person { Name = "Max", Fach = "Sew" , Klasse="3" }
        };
            DataGridMentor.Items.Add(DeineObservableCollection);
            // Setze die Datenquelle der DataGrid
        }

        public class Person
        {
            public string Name { get; set; }
            public string Fach { get; set; }
            public string Klasse { get; set; }
            // Weitere Eigenschaften hinzufügen, falls benötigt
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}




