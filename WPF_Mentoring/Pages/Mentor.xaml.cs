using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
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

namespace WPF_Mentoring.Pages
{
    /// <summary>
    /// Interaktionslogik für Mentor.xaml
    /// </summary>
    public partial class Mentor : Page
    {
        public static MainWindow main;
        public Mentor()
        {
            InitializeComponent();
            main.createNav();
            name.Text = main.user.Name;
            klasse.Text = main.mentor.KlasseOderKürzel;
            faecher.Text = string.Join(",",main.mentor.MentoringFächer);
            beschreibung.Text = main.mentor.Beschreibung;
        }

        private void absenden_Click(object sender, RoutedEventArgs e)
        {
            Authentification.SendEmail(main.user.Email,terminvereinbarung.Text +"\nSender: "+main.user.Email);
        }
    }
}
