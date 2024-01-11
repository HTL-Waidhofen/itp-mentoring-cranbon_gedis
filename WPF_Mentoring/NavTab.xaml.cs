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
using WPF_Mentoring.Pages;

namespace WPF_Mentoring
{
    /// <summary>
    /// Interaktionslogik für NavTab.xaml
    /// </summary>
    public partial class NavTab : Page
    {
        public static MainWindow main;
        public NavTab()
        {
            InitializeComponent();
        }
        private void Grid_Click(object sender, RoutedEventArgs e)
        {
            var ClickedButton = e.OriginalSource as NavButton;
            switch (ClickedButton.Text)
            {
                case "Übersicht":
                    main.rahmen_frame.Content = new Übersicht();
                    break;
                case "NAV":
                    main.rahmen_frame.Content = new NAV();
                    break;
                case "Mentoren":
                    main.rahmen_frame.Content = new Mentor();
                    break;
                case "Einstellungen":
                    main.rahmen_frame.Content = new Einstellungen();
                    break;
            }

            
        }
    }
}
