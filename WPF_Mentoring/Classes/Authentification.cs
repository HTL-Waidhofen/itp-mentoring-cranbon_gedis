using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Mail;
using System.Drawing;

namespace WPF_Mentoring.Classes
{
    public class Authentification
    {
        public static bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z]+\.[a-zA-Z]+@htlwy\.at$";
            return Regex.IsMatch(email, pattern);
        }
        public bool IsCorrectPassword(string password, string email)
        {
            string connectionString = "Data Source=Mentoring.db;Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand("SELECT password FROM Users WHERE email = @Email", connection))
                {
                    command.Parameters.AddWithValue("@Email", email);

                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string correctPassword = reader.GetString(2);
                            return password == correctPassword;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }
        public static string GetAuthenCode()
        {
            Random rnd = new Random();
            string authenSymbols = "qwertzuiopasdfghjklyxcvbnm1234567890#.-/";
            int length = 6;
            string authenCode = "";
            for (int i = 0; i < length; i++)
            {
                authenCode += authenSymbols[rnd.Next(0, authenSymbols.Length)];
            }
            return authenCode;
        }
        public void SendEmail(string toEmail)
        {
            string code = GetAuthenCode();
            var fromAddress = new MailAddress("CranbonGedis@outlook.de");
            var toAddress = new MailAddress(toEmail);
            const string fromPassword = "CraN8onGeydis#3AHIT";
            const string subject = "Authentification für Mentoring App";
            string body = $"Email: {toEmail}\nAuthentification Code: {code}";

            var smtp = new SmtpClient
            {
                Host = "smtp-mail.outlook.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}
    


