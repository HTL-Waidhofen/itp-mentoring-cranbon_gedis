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
using WPF_Mentoring.Classes;
using WPF_Mentoring.Pages;
using WPF_Monitoring.Pages;

namespace WPF_Mentoring
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {


            InitializeComponent();
            rahmen_frame.Content = new Anmeldung();

            WPF_Mentoring.Pages.Anmeldung.main = this;
            Übersicht.main = this;
            Registration.main = this;
            Einstellungen.main = this;
            WPF_Mentoring.Pages.Mentor.main = this;
            Mentorensuche.main = this;
            NavTab.main = this;

        }
        public void createNav()
        {
            NavTabUI.Content = new NavTab();
        }
        public void delNav()
        {
            NavTabUI.Content = " ";
        }
    }
}
