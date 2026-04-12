using System;
using System.Collections.Generic; // Må være med når lister blir tatt i bruk
using System.Linq;

namespace UniversitetsSystem
{
    public class Course
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public int MaxStudents { get; set; }

        public List<Student> Students { get; set; } // Liste over hvilke studenter som er med i kurset
        public List<string> Syllabus { get; set; }
        public Dictionary<string, string> Grades { get; set; }

        public Course(string code, string name, int credits, int maxStudents) // Konstruktør for Course klassen
        {
            this.Code = code;
            this.Name = name;
            this.Credits = credits;
            this.MaxStudents = maxStudents;
            Students = new List<Student>();
            Syllabus = new List<string>();
            Grades = new Dictionary<string, string>();
        }

        public void VisInfo()
        {
            Console.WriteLine($"Kode: {Code}, Navn: {Name}, Studiepoeng: {Credits}, Maks plasser: {MaxStudents}");
        }

        public bool EnrollStudent(Student student)
        {
            if (Students.Count >= MaxStudents)
            {
                return false;
            }

            bool alleredePåmeldt = Students.Any(s => s.StudentID == student.StudentID);

            if (alleredePåmeldt)
            {
                return false;
            }

            Students.Add(student);
            student.Courses.Add(this);

            return true;
        }

        public bool UnenrollStudent(string studentId)
        {
            Student student = Students.FirstOrDefault(s => s.StudentID == studentId);

            if (student == null)
            {
                return false;
            }

            Students.Remove(student);
            student.Courses.Remove(this);

            return true;
        }

        public bool SetGrade(string studentId, string grade)
        {
            Student student = Students.FirstOrDefault(s => s.StudentID == studentId);

            if (student == null)
            {
                return false;
            }

            Grades[studentId] = grade;
            return true;
        }

        public string GetGrade(string studentId)
        {
            if (Grades.ContainsKey(studentId))
            {
                return Grades[studentId];
            }

            return null;
        }

        public void AddSyllabusItem(string item)
        {
            if (!string.IsNullOrWhiteSpace(item))
            {
                Syllabus.Add(item);
            }
        }
        
    }
}