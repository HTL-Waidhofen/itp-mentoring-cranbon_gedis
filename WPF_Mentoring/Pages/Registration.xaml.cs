using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
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
using WPF_Mentoring.Classes;

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
            AllowMultiSelection(subjects_TreeView);
        }
        private void MenuItem_Anmeldung_Click(object sender, RoutedEventArgs e)
        {
            main.rahmen_frame.Content = new Anmeldung();
        }
        private List<TreeViewItem> selectedItems = new List<TreeViewItem>();

        private static readonly PropertyInfo IsSelectionChangeActiveProperty = typeof(TreeView).GetProperty("IsSelectionChangeActive", BindingFlags.NonPublic | BindingFlags.Instance);

        public static void AllowMultiSelection(TreeView treeView)
        {
            string[] treeViewNotSel = new string[] { "Mechatronik Fachschule", "Allgemeine Fächer", "Maschinenbau", "Elektrotechnik", "Wirtschaftsingenieure – Maschinenbau", "Informationstechnik"};
            if (IsSelectionChangeActiveProperty == null) return;

            var selectedItems = new List<TreeViewItem>();
            treeView.SelectedItemChanged += (a, b) =>
            {
                var treeViewItem = treeView.SelectedItem as TreeViewItem;
                if (treeViewItem == null) 
                { 
                    return;
                }

                // allow multiple selection
                // when control key is pressed
                if (!treeViewNotSel.Contains(treeViewItem.Header))
                {
                    // suppress selection change notification
                    // select all selected items
                    // then restore selection change notifications
                    var isSelectionChangeActive =
                      IsSelectionChangeActiveProperty.GetValue(treeView, null);

                    IsSelectionChangeActiveProperty.SetValue(treeView, true, null);
                    selectedItems.ForEach(item => item.IsSelected = true);

                    IsSelectionChangeActiveProperty.SetValue
                    (
                      treeView,
                      isSelectionChangeActive,
                      null
                    );
                }
                else
                {
                    /*
                    deselect all selected items except the current one
                    selectedItems.ForEach(item => item.IsSelected = (item == treeViewItem));
                    selectedItems.Clear();*/

                    treeViewItem.IsSelected = false;
                    //selectedItems.Remove(treeViewItem);

                }

                if (!selectedItems.Contains(treeViewItem)&& !treeViewNotSel.Contains(treeViewItem.Header))
                {
                    selectedItems.Add(treeViewItem);
                }
            };

        }
    }
}
