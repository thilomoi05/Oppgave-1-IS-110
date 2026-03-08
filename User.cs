namespace UniversitetsSystem
{
    public abstract class User
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public User(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public abstract string GetID();

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Navn: {Name}, Email: {Email}");
        }
    }
}