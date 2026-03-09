using System.Collections.Generic;

namespace UniversitetsSystem
{
    public class UniversitySystem
    {
        public List<Student> Students { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Course> Courses { get; set; }
        public List<Book> Books { get; set; }
        public List<Loan> Loans { get; set; }

        public UniversitySystem()
        {
            Students = new List<Student>();
            Employees = new List<Employee>();
            Courses = new List<Course>();
            Books = new List<Book>();
            Loans = new List<Loan>();
        }
    }
}