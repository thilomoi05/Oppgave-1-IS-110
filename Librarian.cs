using System;

namespace UniversitetsSystem
{
    public class Librarian : Employee
    {
        public Librarian(
            string employeeID,
            string name,
            string email,
            string username,
            string password,
            string department)
            : base(employeeID, name, email, username, password, "Bibliotekar", department, UserRole.Librarian)
        {
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Bibliotekar: {Name} ({EmployeeID}) - {Department}");
        }
    }
}