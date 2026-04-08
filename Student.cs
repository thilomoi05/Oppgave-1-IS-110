using System;
using System.Collections.Generic;

namespace UniversitetsSystem
{
    public class Student : User, IBorrower
    {
        public string StudentID { get; set; }
        public List<Course> Courses { get; set; }

        public Student(string studentID, string name, string email, string username, string password)
            : base(name, email, username, password, UserRole.Student)
        {
            StudentID = studentID;
            Courses = new List<Course>();
        }

        public override string GetID()
        {
            return StudentID;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Student: {Name} ({StudentID}) - {Email}");
        }

        public string GetBorrowerId()
        {
            return StudentID;
        }

        public string GetBorrowerName()
        {
            return Name;
        }
    }
}