using System;
using System.Collections.Generic;

namespace UniversitetsSystem
{
    public class Course
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
        public int MaxStudents { get; set; }

        public List<Student> Students { get; set; }

        public Course(string code, string name, int credits, int maxStudents)
        {
            this.Code = code;
            this.Name = name;
            this.Credits = credits;
            this.MaxStudents = maxStudents;
            Students = new List<Student>();
        }

        public void VisInfo()
        {
            Console.WriteLine($"Kode: {Code}, Navn: {Name}, Studiepoeng: {Credits}, Maks plasser: {MaxStudents}");
        }
    }
}