namespace UniversitetsSystem
{
    public abstract class User // Abstrakt klasse som andre bruker klasser arver fra
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public abstract string GetID(); // Metode som alle arve klasser av User klassen må ha

        public virtual void PrintInfo() // Metode som må være med i arve klasser men kan modifiseres (virtual)
        {
            Console.WriteLine($"Navn: {Name}, Email: {Email}");
        }
    }
}