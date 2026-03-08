using System;
using System.Collections.Generic;

namespace UniversitetsSystem
{
    public class Student : User, IBorrower // Sier at Student er en arv av User klassen og bruker IBorrower interface
    {
        public string StudentID { get; set; }

        public List<Course> Courses { get; set; }

        public Student(string studentID, string name, string email)
            : base(name, email)
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
        
        // IBorrower metoder
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