using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Drawing;

namespace WPF_Mentoring.Classes
{
    public class Authentification
    {
        public static string GetAuthenCode()
        {
            //schreibe mir einen code der eine authentifizierung durchführt und den code zurückgibt es können zahlen und buchstaben und .#&/ verwendet werden
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

