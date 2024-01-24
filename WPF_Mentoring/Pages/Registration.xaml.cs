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
using System.Xml.Linq;
using ITP_Mentoring_WPF;
using Wpf.Ui.Controls;
using WPF_Mentoring.Classes;

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

        private static readonly PropertyInfo IsSelectionChangeActiveProperty = typeof(TreeView).GetProperty("IsSelectionChangeActive", BindingFlags.NonPublic | BindingFlags.Instance);

        
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            if (checkBox != null)
            {
                
                ausgewaehlteFaecher.Add(checkBox.Content);
                ChosenSubjectsLabelUpdater();
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            if (checkBox != null)
            {
               
                ausgewaehlteFaecher.Remove(checkBox.Content);
                ChosenSubjectsLabelUpdater();
                
            }
        }
        private void ChosenSubjectsLabelUpdater()
        {
               
                string ergebnisString = string.Join(", ", ausgewaehlteFaecher);
            chosen_subjects_label.Text = "Ausgewählte Fächer: " + ergebnisString;
        }
        private bool CheckPasswords()
        {

            string erstesPasswort = password.Password;
            string zweitesPasswort = passwortCheck_Passwordbox.Password;
            if (string.IsNullOrEmpty(erstesPasswort) == true)
            {
                return false;
            }
            else if (string.Equals(erstesPasswort, zweitesPasswort))
            {
               return true;
            }
            
            else
            {
                return false;
            }

        }

        private void passwordCheck(object sender, RoutedEventArgs e)
        {
            if (CheckPasswords())
            {

                checkpassword.Foreground = Brushes.Green;
                checkpassword.Content = "Passwörter stimmen überrein";
               
            }
            else
            {
                checkpassword.Foreground = Brushes.Red;
                checkpassword.Content = "Passwörter stimmen nicht überrein!";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(isMentor.IsChecked == true)
            {
                Benutzer benutzer = new Benutzer(email.Text, name.Text, password.Text, true);
            }
        }
    }
}
