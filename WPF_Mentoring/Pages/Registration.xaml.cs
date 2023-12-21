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



        private void search_treeview_SelectionChanged(object sender, RoutedEventArgs e)
        {
            
        }

        private void Page_DpiChanged(object sender, DpiChangedEventArgs e)
        {

        }
    }
}
