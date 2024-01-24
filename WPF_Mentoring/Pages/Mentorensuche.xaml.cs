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
            MeineDaten.Add(new DeinDatenTyp { Eigenschaft1 = "Wert1", Eigenschaft2 = "Wert2" });
            MeineDaten.Add(new DeinDatenTyp { Eigenschaft1 = "Wert3", Eigenschaft2 = "Wert4" });
            MeineDataGrid.ItemsSource = MeineDaten;

        }
        public class DeinDatenTyp
        {
            public string Eigenschaft1 { get; set; }
            public string Eigenschaft2 { get; set; }
            // Füge weitere Eigenschaften nach Bedarf hinzu.
        }

        private void SortierenButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}




