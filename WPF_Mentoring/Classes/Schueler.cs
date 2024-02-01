using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Mentoring.Classes
{
    public class Schueler : Benutzer
    {
        public string Klasse { get; set; }
        public List<string> Fächer { get; set; }

        public Schueler(string email, string name, string passwort, string klasse, List<string> facher) : base(email, name, passwort, false)
        {
            Klasse = klasse;
            Fächer = facher;
        }
        public Schueler() { }
    }
}
