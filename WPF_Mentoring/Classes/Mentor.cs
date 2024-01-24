using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Mentoring.Classes
{
    public class Mentor : Benutzer
    {
        public string Beschreibung { get; set; } // generelle infos kann leer sein
        public string KlasseOderKürzel { get; set; }
        public List<string> MentoringFächer { get; set; }
        public int Bewertung { get; set; }
        public Mentor(string email, string name, string password, string beschreibung, string klasseOderKürzel, List<string> mentoringFächer, int bewertung)
        {
            base.Email = email;
            base.Name = name;
            base.Password = password;
            Beschreibung = beschreibung;
            KlasseOderKürzel = klasseOderKürzel;
            MentoringFächer = mentoringFächer;
        }

    }
}
