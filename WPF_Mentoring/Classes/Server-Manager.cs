using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Mentoring.Classes
{
    public static class Server_Manager
    {
        //Account
        public static Benutzer loadAccbyEmail(string email)
        {
            using (var con = new SQLiteConnection(loadConnectionString()))
            {
                con.Open();
                Benutzer b = new Benutzer();

                using (var cmd = new SQLiteCommand(con))
                {
                    cmd.CommandText = "SELECT * FROM Account WHERE email = @email";
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            b.Email = email;
                            b.Name = rdr.GetString(1);
                            b.Password = rdr.GetString(2);
                            if (rdr.GetInt32(3) == 1)
                            {
                                b.isMentor = true;
                            }
                            else
                            {
                                b.isMentor = false;
                            }
                        }

                    }
                }
                return b;
            }
        }
        public static void AddAcc(Benutzer person)
        {
            using (var con = new SQLiteConnection(loadConnectionString()))
            {
                con.Open();

                using (var cmd = new SQLiteCommand(con))
                {
                    cmd.CommandText = "INSERT INTO Account(email, name,password,isMentor) VALUES(@email,@name,@password,@isMentor)";
                    cmd.Parameters.AddWithValue("@email", person.Email);
                    cmd.Parameters.AddWithValue("@name", person.Name);
                    cmd.Parameters.AddWithValue("@password", person.Password);
                    cmd.Parameters.AddWithValue("@isMentor", false == person.isMentor ? 0 : 1);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();

                }
            }
        }

        public static void UpdateMA(Benutzer person)
        {
            using (var con = new SQLiteConnection(loadConnectionString()))
            {
                con.Open();

                using (var cmd = new SQLiteCommand(con))
                {
                    cmd.CommandText = "UPDATE Account(email, name,password,isMentor) VALUES(@email,@name,@password,@isMentor)";
                    cmd.Parameters.AddWithValue("@email", person.Email);
                    cmd.Parameters.AddWithValue("@name", person.Name);
                    cmd.Parameters.AddWithValue("@password", person.Password);
                    cmd.Parameters.AddWithValue("@isMentor", false == person.isMentor ? 0 : 1);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void removeAcc(Benutzer person)
        {
            using (var con = new SQLiteConnection(loadConnectionString()))
            {
                con.Open();

                using (var cmd = new SQLiteCommand(con))
                {
                    cmd.CommandText = "DELETE FROM Account WHERE email=@email;";
                    cmd.Parameters.AddWithValue("@email", person.Email);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
            }
        }


        //Mentor
        public static Mentor loadMentorbyEmail(string email)
        {
            using (var con = new SQLiteConnection(loadConnectionString()))
            {
                con.Open();
                Mentor b = new Mentor();

                using (var cmd = new SQLiteCommand(con))
                {
                    cmd.CommandText = "SELECT * FROM Mentor WHERE email = @email";
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            b.Email = email;
                            b.Beschreibung = rdr.GetString(0);
                            b.KlasseOderKürzel = rdr.GetString(2);
                            b.MentoringFächer = rdr.GetString(3).Split(',').ToList();
                        }

                    }
                }
                return b;
            }
        }
        public static void AddMentor(Mentor mentor)
        {
            using (var con = new SQLiteConnection(loadConnectionString()))
            {
                con.Open();

                using (var cmd = new SQLiteCommand(con))
                {
                    cmd.CommandText = "INSERT INTO Mentor(email,beschreibung,klasseOderKürzel,mentoringFächer) VALUES(@email,@beschreibung,@klasseOderKürzel,@mentoringFächer)";
                    string faecher = "";
                    for (int i = 0; i < mentor.MentoringFächer.Count; i++)
                    {
                        faecher += mentor.MentoringFächer[i];
                        if (i != mentor.MentoringFächer.Count - 1)
                        {
                            faecher += ",";
                        }
                    }
                    cmd.Parameters.AddWithValue("@email", mentor.Email);
                    cmd.Parameters.AddWithValue("@beschreibung", mentor.Beschreibung);
                    cmd.Parameters.AddWithValue("@klasseOderKürzel", mentor.KlasseOderKürzel);
                    cmd.Parameters.AddWithValue("@mentoringFächer", mentor.MentoringFächer);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();

                }
            }
        }
        public static void UpdateMentor(Mentor mentor)
        {
            using (var con = new SQLiteConnection(loadConnectionString()))
            {
                con.Open();

                using (var cmd = new SQLiteCommand(con))
                {
                    cmd.CommandText = "UPDATE Mentor(email,beschreibung,klasseOderKürzel,mentoringFächer) VALUES(@email,@beschreibung,@klasseOderKürzel,@mentoringFächer)";
                    string faecher = "";
                    for (int i = 0; i < mentor.MentoringFächer.Count; i++)
                    {
                        faecher += mentor.MentoringFächer[i];
                        if (i != mentor.MentoringFächer.Count - 1)
                        {
                            faecher += ",";
                        }
                    }
                    cmd.Parameters.AddWithValue("@email", mentor.Email);
                    cmd.Parameters.AddWithValue("@beschreibung", mentor.Beschreibung);
                    cmd.Parameters.AddWithValue("@klasseOderKürzel", mentor.KlasseOderKürzel);
                    cmd.Parameters.AddWithValue("@mentoringFächer", mentor.MentoringFächer);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void removeMentor(Mentor mentor)
        {
            using (var con = new SQLiteConnection(loadConnectionString()))
            {
                con.Open();

                using (var cmd = new SQLiteCommand(con))
                {
                    cmd.CommandText = "DELETE FROM Mentor WHERE email=@email;";
                    cmd.Parameters.AddWithValue("@email", mentor.Email);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        //Schueler
        public static void AddSchueler(Schueler schueler)
        {
            using (var con = new SQLiteConnection(loadConnectionString()))
            {
                con.Open();

                using (var cmd = new SQLiteCommand(con))
                {

                    cmd.CommandText = "INSERT INTO Schueler(email,klasse,faecher) VALUES(@email,@klasse,@faecher)";
                    string faecher = "";
                    for (int i = 0; i < schueler.Fächer.Count; i++)
                    {
                        faecher += schueler.Fächer[i];
                        if (i != schueler.Fächer.Count - 1)
                        {
                            faecher += ",";
                        }
                    }
                    cmd.Parameters.AddWithValue("@klasse", schueler.Klasse);
                    cmd.Parameters.AddWithValue("@faecher", faecher);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();

                }
            }
        }
        public static void UpdateSchueler(Schueler schueler)
        {
            using (var con = new SQLiteConnection(loadConnectionString()))
            {
                con.Open();

                using (var cmd = new SQLiteCommand(con))
                {
                    cmd.CommandText = "UPDATE Schueler(email,klasse,faecher) VALUES(@email,@klasse,@faecher)";
                    string faecher = "";
                    for (int i = 0; i < schueler.Fächer.Count; i++)
                    {
                        faecher += schueler.Fächer[i];
                        if (i != schueler.Fächer.Count - 1)
                        {
                            faecher += ",";
                        }
                    }
                    cmd.Parameters.AddWithValue("@klasse", schueler.Klasse);
                    cmd.Parameters.AddWithValue("@faecher", schueler.Fächer);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static void removeSchueler(Schueler schueler)
        {
            using (var con = new SQLiteConnection(loadConnectionString()))
            {
                con.Open();

                using (var cmd = new SQLiteCommand(con))
                {
                    cmd.CommandText = "DELETE FROM Schueler WHERE email=@email;";
                    cmd.Parameters.AddWithValue("@email", schueler.Email);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static Schueler loadSchuelerbyEmail(string email)
        {
            using (var con = new SQLiteConnection(loadConnectionString()))
            {
                con.Open();
                Schueler b = new Schueler();

                using (var cmd = new SQLiteCommand(con))
                {
                    cmd.CommandText = "SELECT * FROM Schueler WHERE email = @email";
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                    using (SQLiteDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            b.Klasse = rdr.GetString(1);
                            b.Fächer = rdr.GetString(2).Split(',').ToList();
                        }

                    }
                }
                return b;
            }
        }
        private static string loadConnectionString()
        {
            return "DataSource=Mentoring.db;Version=3;";
        }

        internal static void updatePassword(string email, string password)
        {
            using (var con = new SQLiteConnection(loadConnectionString()))
            {
                con.Open();
                using (var cmd = new SQLiteCommand(con))
                {
                    cmd.CommandText = "UPDATE Account SET password = @password WHERE email = @email";
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Prepare();
                    cmd.ExecuteNonQuery();
                    
                }
            }
        }
    }

}
