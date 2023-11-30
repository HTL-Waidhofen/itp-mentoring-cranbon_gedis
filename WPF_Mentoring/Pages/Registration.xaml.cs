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
using ITP_Mentoring_WPF;

namespace WPF_Mentoring.Pages
{
    /// <summary>
    /// Interaktionslogik für Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public static MainWindow main;
        List<string> faecher = new List<string>();
        public Registration()
        {
            InitializeComponent();
           // GetFaecher();
        }

        /*private void GetFaecher()
        {
            faecher.Add("Mathmatik");
            faecher.Add("Deutsch");
            UpList();
        }*/

        private void MenuItem_Anmeldung_Click(object sender, RoutedEventArgs e)
        {
            main.rahmen_frame.Content = new Anmeldung();
        }



        /*private void SearchBox_TextChanged(object sender, TextChangedEventArgs e) // code for searching items in listbox
        {
            if (searchTextBox.Text != "")
            {
                string sort = searchTextBox.Text;
                sort = sort[0].ToString().ToUpper() + sort.Substring(1);
                var gesorteteFaecher =
                    from faecher in faecher
                    where faecher.StartsWith(sort)
                    select faecher;
                subjects_Listbox.Items.Clear();
                foreach (string s in gesorteteFaecher)
                {
                    subjects_Listbox.Items.Add(s);
                }
            }
            else
            {
                UpList();
            }
        }

        private void UpList()
        {
            subjects_Listbox.Items.Clear();
            foreach (string s in faecher)
            {
                subjects_Listbox.Items.Add(s);
            }
        }*/
        private List<TreeViewItem> selectedItems = new List<TreeViewItem>();

        private void myTreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeViewItem selectedItem = subjects_Listbox.SelectedItem as TreeViewItem;

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

    }
}
