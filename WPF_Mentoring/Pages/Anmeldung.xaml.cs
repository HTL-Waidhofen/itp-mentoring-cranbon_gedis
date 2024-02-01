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
using WPF_Monitoring.Pages;

namespace WPF_Mentoring.Pages
{
    /// <summary>
    /// Interaktionslogik für Anmeldung.xaml
    /// </summary>
    public partial class Anmeldung : Page
    {
        public static MainWindow main;
        private string authenCode;
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
                try
                {
                    if (Authentification.IsCorrectPassword(password.Password, email.Text))
                    {
                        main.user = Server_Manager.loadAccbyEmail(email.Text);
                        main.schueler = Server_Manager.loadSchuelerbyEmail(email.Text);
                        main.mentor = Server_Manager.loadMentorbyEmail(email.Text);
                        main.rahmen_frame.Content = new Übersicht();
                        
                    }
                    else 
                    {
                        MessageBox.Show("Wrong Password", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Bitte geben Sie einen gültigen Account ein.", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(email.Text != "" && Authentification.IsValidEmail(email.Text))
            {
                authenCode = Authentification.GetAuthenCode();
                Authentification.SendEmail(email.Text, authenCode);
                InputBox.Visibility = Visibility.Visible;
                
            }
            else
            {
                MessageBox.Show("Bitte geben Sie eine gültige Email ein!","Fehler",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (InputTextBox.Text == authenCode && newPassword.Text == newPasswordCheck.Text)
                {
                    Server_Manager.updatePassword(email.Text, newPassword.Text);
                    MessageBox.Show("Ihr Passwort wurde zurückgesetzt!", "Erfolgreich", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Der Code ist falsch!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Geben Sie eine Richtige Email an", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                InputTextBox.Text = "";
                newPassword.Text = "";
                newPasswordCheck.Text = "";

                InputBox.Visibility = Visibility.Collapsed;
            }
        }
    }
}
