using System.Collections.Generic;
using System.Linq;

namespace UniversitetsSystem
{
    public class UniversitySystem
    {
        public List<User> Users { get; set; }
        public List<Student> Students { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Course> Courses { get; set; }
        public List<Book> Books { get; set; }
        public List<Loan> Loans { get; set; }

        public UniversitySystem()
        {
            Users = new List<User>();
            Students = new List<Student>();
            Employees = new List<Employee>();
            Courses = new List<Course>();
            Books = new List<Book>();
            Loans = new List<Loan>();
        }

        public bool UsernameExists(string username)
        {
            return Users.Any(u => u.Username.ToLower() == username.ToLower());
        }

        public User Login(string username, string password)
        {
            return Users.FirstOrDefault(u =>
                u.Username.ToLower() == username.ToLower() &&
                u.Password == password);
        }

        public bool RegisterUser(User user)
        {
            if (UsernameExists(user.Username))
            {
                return false;
            }

            Users.Add(user);
            return true;
        }

        public bool AddCourse(Course course)
        {
            bool kursFinnes = Courses.Any(c =>
                c.Code.ToLower() == course.Code.ToLower() ||
                c.Name.ToLower() == course.Name.ToLower());

            if (kursFinnes)
            {
                return false;
            }

            Courses.Add(course);
            return true;
        }

        
    }
}