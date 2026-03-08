namespace UniversitetsSystem
{
    public class Employee : User, IBorrower
    {
        public string EmployeeID { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }

        // Konstruktør for Employee klassen
        public Employee(string employeeID, string name, string email, string position, string department)
            : base(name, email)
        {
            EmployeeID = employeeID;
            Position = position;
            Department = department;
        }

        public override string GetID()
        {
            return EmployeeID;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Ansatt: {Name} ({EmployeeID}) - {Position} - {Department}");
        }

        // IBorrower interface metoder
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