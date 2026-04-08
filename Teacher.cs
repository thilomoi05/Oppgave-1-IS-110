using System;
using System.Collections.Generic;

namespace UniversitetsSystem
{
    public class Teacher : Employee, IBorrower
    {
        public List<Course> TeachingCourses { get; set; }

        public Teacher(
            string employeeID,
            string name,
            string email,
            string username,
            string password,
            string department)
            : base(employeeID, name, email, username, password, "Faglærer", department, UserRole.Teacher)
        {
            TeachingCourses = new List<Course>();
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Faglærer: {Name} ({EmployeeID}) - {Department}");
        }

        public string GetBorrowerId()
        {
            return EmployeeID;
        }

        public string GetBorrowerName()
        {
            return Name;
        }
    }
}