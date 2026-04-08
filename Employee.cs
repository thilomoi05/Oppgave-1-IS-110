using System;

namespace UniversitetsSystem
{
    public class Employee : User
    {
        public string EmployeeID { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }

        public Employee(
            string employeeID,
            string name,
            string email,
            string username,
            string password,
            string position,
            string department,
            UserRole role)
            : base(name, email, username, password, role)
        {
            EmployeeID = employeeID;
            Position = position;
            Department = department;
        }

        public override string GetID()
        {
            return EmployeeID;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Ansatt: {Name} ({EmployeeID}) - {Position} - {Department}");
        }
    }
}