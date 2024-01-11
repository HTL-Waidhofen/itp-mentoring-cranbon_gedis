﻿using System;
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
        private List<string> ausgewaehlteFaecher = new List<string>();

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
                string fachName = checkBox.Content.ToString();
                ausgewaehlteFaecher.Add(fachName);

                // Hier kannst du die Liste 'ausgewaehlteFaecher' weiterverwenden
                // Zum Beispiel: ListBox.ItemsSource = ausgewaehlteFaecher;
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            if (checkBox != null)
            {
                string fachName = checkBox.Content.ToString();
                ausgewaehlteFaecher.Remove(fachName);

                // Hier kannst du die Liste 'ausgewaehlteFaecher' weiterverwenden
                // Zum Beispiel: ListBox.ItemsSource = ausgewaehlteFaecher;
            }
        }
    }
}
