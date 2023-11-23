namespace WPF_Mentoring.Classes
{
    public class Benutzer
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public bool isMentor { get; set; }
        public Benutzer() { }
        public Benutzer(string email, string name, string password, bool ismentor)
        {
            Email = email;
            Name = name;
            Password = password;
            isMentor = ismentor;
        }
    }
}