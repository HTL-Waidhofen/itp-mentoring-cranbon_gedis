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
using System.Xml.Linq;
using ITP_Mentoring_WPF;

namespace WPF_Mentoring.Pages
{
    /// <summary>
    /// Interaktionslogik für Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public static MainWindow main;
        private List<object> ausgewaehlteFaecher = new List<object>();

        public Registration()
        {
            InitializeComponent();
           
        }
        private void MenuItem_Anmeldung_Click(object sender, RoutedEventArgs e)
        {
            main.rahmen_frame.Content = new Anmeldung();
        }
        private List<TreeViewItem> selectedItems = new List<TreeViewItem>();

        private void subjects_TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeViewItem selectedItem = subjects_TreeView.SelectedItem as TreeViewItem;

            if (selectedItem != null)
            {
                if (selectedItems.Contains(selectedItem))
                {
                    selectedItems.Remove(selectedItem);
                }
                else
                {
                    selectedItems.Add(selectedItem);
                }
            }
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            if (checkBox != null)
            {
                
                ausgewaehlteFaecher.Add(checkBox.Content);
                ChosenSubjectsLabelUpdater();
                // Hier kannst du die Liste 'ausgewaehlteFaecher' weiterverwenden
                // Zum Beispiel: ListBox.ItemsSource = ausgewaehlteFaecher;
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            if (checkBox != null)
            {
               
                ausgewaehlteFaecher.Remove(checkBox.Content);
                ChosenSubjectsLabelUpdater();
                // Hier kannst du die Liste 'ausgewaehlteFaecher' weiterverwenden
                // Zum Beispiel: ListBox.ItemsSource = ausgewaehlteFaecher;
            }
        }
        private void ChosenSubjectsLabelUpdater()
        {
               
                string ergebnisString = string.Join(", ", ausgewaehlteFaecher);
            chosen_subjects_label.Text = "Ausgewählte Fächer: " + ergebnisString;
        }

        
    }
}
