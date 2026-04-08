using System;

namespace UniversitetsSystem
{
    public abstract class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; protected set; }

        public User(string name, string email, string username, string password, UserRole role)
        {
            Name = name;
            Email = email;
            Username = username;
            Password = password;
            Role = role;
        }

        public abstract string GetID();

        public virtual void PrintInfo()
        {
            Console.WriteLine($"{Name} - {Email} - {Role}");
        }
    }
}