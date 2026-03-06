namespace UniversitetsSystem
{
    public class Student
    {
        public string StudentID { get; set; }
        public string Navn { get; set; }
        public string Epost { get; set; }

        public Student(string studentID, string navn, string epost)
        {
            this.StudentID = studentID;
            this.Navn = navn;
            this.Epost = epost;
        }

        public void VisInfo()
        {
            Console.WriteLine($"StudentID: {StudentID}, Navn: {Navn}, E-post: {Epost}");
        }
    }
}