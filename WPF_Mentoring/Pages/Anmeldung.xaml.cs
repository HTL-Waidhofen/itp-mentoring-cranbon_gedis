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
    /// Interaktionslogik für Anmeldung.xaml
    /// </summary>
    public partial class Anmeldung : Page
    {
        public static MainWindow main;
        public Anmeldung()
        {
            InitializeComponent();
        }
        private void anmeldung_Click(object sender, RoutedEventArgs e)
        {
            main.rahmen_frame.Content = new Übersicht();
        }

        private void registrierung(object sender, RoutedEventArgs e)
        {
            main.rahmen_frame.Content = new Registration();
        }
    }
}
