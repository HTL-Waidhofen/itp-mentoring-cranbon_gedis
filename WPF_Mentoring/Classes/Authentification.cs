using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Text.RegularExpressions;

namespace WPF_Mentoring.Classes
{
    public class Authentification
    {
        public static bool IsValidEmail(string email)
        {
            string pattern = @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$";
            return Regex.IsMatch(email, pattern); 
        }
        public bool IsCorrectPassword(string password,string email)
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
    }
    
}
