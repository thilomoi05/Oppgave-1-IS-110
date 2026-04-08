using System;

namespace UniversitetsSystem
{
    public class ExchangeStudent : Student
    {
        public string HomeUniversity { get; set; }
        public string Country { get; set; }
        public DateTime PeriodFrom { get; set; }
        public DateTime PeriodTo { get; set; }

        public ExchangeStudent(
            string studentID,
            string name,
            string email,
            string username,
            string password,
            string homeUniversity,
            string country,
            DateTime periodFrom,
            DateTime periodTo)
            : base(studentID, name, email, username, password)
        {
            HomeUniversity = homeUniversity;
            Country = country;
            PeriodFrom = periodFrom;
            PeriodTo = periodTo;
        }

        public override void PrintInfo()
        {
            Console.WriteLine(
                $"Utvekslingsstudent: {Name} ({StudentID}) - {HomeUniversity}, {Country} | " +
                $"Periode: {PeriodFrom:dd.MM.yyyy} - {PeriodTo:dd.MM.yyyy}");
        }
    }
}
