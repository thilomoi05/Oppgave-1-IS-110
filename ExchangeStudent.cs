namespace UniversitetsSystem
{
    public class ExchangeStudent : Student
    {
        public string HomeUniversity { get; set; }
        public string Country { get; set; }

        public ExchangeStudent(string studentID, string name, string email,
                               string homeUniversity, string country)
            : base(studentID, name, email)
        {
            HomeUniversity = homeUniversity;
            Country = country;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Utvekslingsstudent: {Name} ({StudentID}) - {HomeUniversity}, {Country}");
        }
    }
}
