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
            //main.delNav();
        }
        private void anmeldung(object sender, RoutedEventArgs e)
        {
            main.rahmen_frame.Content = new Übersicht();
        }

        private void registrierung(object sender, RoutedEventArgs e)
        {
            main.rahmen_frame.Content = new Registration();
        }
        private void Button_Click_anmeldung(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(email.Text) || string.IsNullOrWhiteSpace(password.Password))
            {
                MessageBox.Show("Bitte geben Sie eine E-Mail und ein Passwort ein.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (!Authentification.IsValidEmail(email.Text))
            {
                MessageBox.Show("Bitte geben Sie eine gültige E-Mail-Adresse ein.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                main.rahmen_frame.Content = new Registration();
            }
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(email.Text != "" && Authentification.IsValidEmail(email.Text))
            {
                string authenCode = Authentification.GetAuthenCode();
                Authentification.SendEmail(email.Text, authenCode);
                MessageBox.Show("Der Code wurde an Ihre Email gesendet!", "Erfolgreich", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Bitte geben Sie eine gültige Email ein!","Fehler",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
