using System;
using System.Collections.Generic;

namespace UniversitetsSystem
{
    class Program
    {
        static void Main(string[] args)
        {   

            User u1 = new Student("S200", "Per Olsen", "per@uia.no");
            User u2 = new Employee("E10", "Anne Hansen", "anne@uia.no", "Foreleser", "IT");
            User u3 = new ExchangeStudent("S300", "Jean Dupont", "jean@paris.fr", "Sorbonne", "France");

            u1.PrintInfo();
            u2.PrintInfo();
            u3.PrintInfo();

            Console.WriteLine("Trykk Enter...");
            Console.ReadLine();

            // Lister for Stduent og Course objekter som er laget
            List<Student> students = new List<Student>();
            List<Course> courses = new List<Course>();
            List<Employee> employees = new List<Employee>();
            List<Book> books = new List<Book>();
            List<Loan> loans = new List<Loan>();

            students.Add(new Student("S100", "Ola Nordmann", "ola@uia.no"));
            students.Add(new Student("S101", "Kari Hansen", "kari@uia.no"));
            employees.Add(new Employee("E200", "Anne Hansen", "anne@uia.no", "Bibliotekar", "Bibliotek"));
            // Denne delen velger
            bool kjører = true;

            // Her er valgene som brukeren får
            while (kjører)
            {
                Console.Clear();
                Console.WriteLine("=== UNIVERSITETSSYSTEM ===");
                Console.WriteLine("[1] Opprett kurs");
                Console.WriteLine("[2] Meld student til kurs");
                Console.WriteLine("[3] Print kurs og deltagere");
                Console.WriteLine("[4] Søk på kurs");
                Console.WriteLine("[5] Søk på bok");
                Console.WriteLine("[6] Lån bok");
                Console.WriteLine("[7] Returner bok");
                Console.WriteLine("[8] Registrer bok");
                Console.WriteLine("[0] Avslutt");
                Console.Write("Velg et alternativ: ");

                string valg = Console.ReadLine();

                // Switch statement basert på hva brukeren velger
                switch (valg)
                {
                    case "1":
                        OpprettKurs(courses);
                        break;

                    case "2":
                        MeldStudentTilKurs(students, courses);
                        break;

                    case "3":
                        PrintKursOgDeltagere(courses);
                        break;

                    case "4":
                        Console.WriteLine("Du valgte: Søk på kurs");
                        break;

                    case "5":
                        SøkPåBok(books);
                        break;

                    case "6":
                        LånBok(students, employees, books, loans);
                        break;

                    case "7":
                        ReturnerBok(loans);
                        break;

                    case "8":
                        RegistrerBok(books);
                        break;

                    case "0":
                        kjører = false;
                        Console.WriteLine("Programmet avsluttes...");
                        break;

                    default:
                        Console.WriteLine("Ugyldig valg, prøv igjen.");
                        break;
                }

                if (kjører) 
                {
                    Console.WriteLine("\nTrykk Enter for å fortsette...");
                    Console.ReadLine();
                }
            }
        
        }
        // Metode for å opprette kurs
        static void OpprettKurs(List<Course> courses)
        {
            Console.Write("Skriv inn kurskode: ");
            string code = Console.ReadLine();

            Console.Write("Skriv inn kursnavn: ");
            string name = Console.ReadLine();

            int credits;

            Console.WriteLine("Hvor mange studiepoeng gir kurset?");
            // While loop som tester at inputen kan converteres fra string til int
            while (!int.TryParse(Console.ReadLine(), out credits))
            {
                Console.Write("Ugyldig input. Skriv et tall: ");
            }

            int maxStudents;

            Console.WriteLine("Hva er max antall studenter?");
            // While loop som tester at inputen kan converteres fra string til int
            while (!int.TryParse(Console.ReadLine(), out maxStudents))
            {
                Console.WriteLine("Ugyldig input. Skriv et tall:");
            }

            Course nyttKurs = new Course(code, name, credits, maxStudents);
            courses.Add(nyttKurs);

            Console.WriteLine("Kurset ble opprettet.");
        }

        // Metode for å printe hvilke kurs som er opprettet og deltagerne i kurset
        static void PrintKursOgDeltagere(List<Course> courses)
        {   
            // hvis lengden på Course listen er null er den tom og ingen kurs er opprettet
            if (courses.Count == 0)
            {
                Console.WriteLine("Ingen kurs er opprettet ennå.");
                return;
            }

            // loop som går for hvert Course objekt i course listen
            foreach (Course course in courses)
            {
                Console.WriteLine($"\nKurskode: {course.Code}");
                Console.WriteLine($"Navn: {course.Name}");
                Console.WriteLine($"Studiepoeng: {course.Credits}");
                Console.WriteLine($"Maks studenter: {course.MaxStudents}");
                Console.WriteLine($"Antall påmeldte: {course.Students.Count}");

                if (course.Students.Count == 0)
                {
                    Console.WriteLine("Ingen studenter er meldt på dette kurset.");
                }
                else
                {
                    Console.WriteLine("Deltagere:");
                    // Printer hver deltager i kurset
                    foreach (Student student in course.Students)
                    {
                        Console.WriteLine($"- {student.Name} ({student.StudentID})");
                    }
                }
            }
        }

        static void MeldStudentTilKurs(List<Student> students, List<Course> courses)
        {
            Console.Write("Skriv inn StudentID: ");
            string studentId = Console.ReadLine();

            Console.Write("Skriv inn kurskode: ");
            string courseCode = Console.ReadLine();

            // Referanser til Student ogCourse klassene
            Student funnetStudent = null;
            Course funnetKurs = null;

            // Sjekker listene om input matcher 
            foreach (Student student in students)
            {
                if (student.StudentID == studentId)
                {
                    funnetStudent = student;
                    break;
                }
            }

            foreach (Course course in courses)
            {
                if (course.Code == courseCode)
                {
                    funnetKurs = course;
                    break;
                }
            }

            // Hvis ikke det er noe match får bruke beskjed
            if (funnetStudent == null)
            {
                Console.WriteLine("Fant ikke student.");
                return;
            }

            if (funnetKurs == null)
            {
                Console.WriteLine("Fant ikke kurs.");
                return;
            }
            
            if (funnetKurs.Students.Count >= funnetKurs.MaxStudents)
            {
                Console.WriteLine("Kurset er fullt.");
                return;
            }

            // Sier ifra at student allerede er i kurset hvis navnet eksisterer
            foreach (Student student in funnetKurs.Students)
            {
                if (student.StudentID == funnetStudent.StudentID)
                {
                    Console.WriteLine("Studenten er allerede meldt på kurset.");
                    return;
                }
            }

            // Hvis alt stemmer blir student lagt til i kurset og får tilbakemelding
            funnetKurs.Students.Add(funnetStudent);
            Console.WriteLine("Studenten ble meldt på kurset.");
        }
        
        // Metode som lar brukeren registrere en ny bok ved å fylle inn informasjon som trengs
        static void RegistrerBok(List<Book> books)
        {
            Console.Write("Skriv inn bok-ID: ");
            string id = Console.ReadLine();

            Console.Write("Skriv inn tittel: ");
            string title = Console.ReadLine();

            Console.Write("Skriv inn forfatter: ");
            string author = Console.ReadLine();

            Console.Write("Skriv inn årstall: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Skriv inn antall eksemplarer: ");
            int copies = int.Parse(Console.ReadLine());

            Book newBook = new Book(id, title, author, year, copies);
            books.Add(newBook);

            Console.WriteLine("Boken ble registrert.");
        }

        // Metode for at bruker skal søke etter bok med navn eller bokID
        static void SøkPåBok(List<Book> books)
        {
            Console.Write("Skriv inn boktittel eller ID: ");
            string søk = Console.ReadLine();

            bool fantNoe = false;

            // Loop som sjekker alle bøker i bok lista for input
            foreach (Book book in books)
            {
                if (book.Title.ToLower().Contains(søk.ToLower()) || book.Id.ToLower() == søk.ToLower())
                {
                    book.PrintInfo(); // Bokinformasjon printes hvis det er en match
                    fantNoe = true; // Og fantNoe blir true
                }
            }

            if (!fantNoe) // Hvis fantNoe fortsatt er false etter foreach loopen finnes ikke boka
            {
                Console.WriteLine("Fant ingen bøker.");
            }
        }

        // Metode for at bruker kan låne bok
        static void LånBok(List<Student> students, List<Employee> employees, List<Book> books, List<Loan> loans)
        {   
            // Får bokID av bruker
            Console.Write("Skriv inn bok-ID: ");
            string bookId = Console.ReadLine();

            Book funnetBok = null;

            // Sjekker om boka finnes 
            foreach (Book book in books)
            {
                if (book.Id == bookId)
                {
                    funnetBok = book;
                    break;
                }
            }


            if (funnetBok == null)
            {
                Console.WriteLine("Fant ikke bok."); // Hvis ikke boka finnes får bruker beskjed
                return;
            }

            if (funnetBok.AvailableCopies <= 0)
            {
                Console.WriteLine("Ingen eksemplarer tilgjengelig."); // Hvis alle bøkene er lånt ut får bruker beskjed
                return;
            }

            Console.Write("Er låner [1] Student eller [2] Ansatt? "); // Sjekker om låner er student eller ansatt
            string valg = Console.ReadLine();

            IBorrower borrower = null;

            if (valg == "1")
            {
                Console.Write("Skriv inn StudentID: "); // Skrive inn studentID hvis student
                string studentId = Console.ReadLine();

                // Sjekker om student finnes
                foreach (Student student in students)
                {
                    if (student.StudentID == studentId)
                    {
                        borrower = student;
                        break;
                    }
                }
            }
            else if (valg == "2")
            {
                Console.Write("Skriv inn EmployeeID: ");
                string employeeId = Console.ReadLine();

                foreach (Employee employee in employees)
                {
                    if (employee.EmployeeID == employeeId)
                    {
                        borrower = employee;
                        break;
                    }
                }
            }

            if (borrower == null)
            {
                Console.WriteLine("Fant ikke låner."); // Beskjed hvis ikke låner er funnet i systemet
                return;
            }

            // Oppdaterer informasjon hvis lån blir gjennomført
            string loanId = "L" + (loans.Count + 1);
            Loan nyttLån = new Loan(loanId, funnetBok, borrower);

            loans.Add(nyttLån);
            funnetBok.AvailableCopies--;

            Console.WriteLine("Boken ble lånt ut.");
            nyttLån.PrintInfo();
        }

        // Metode for å returnere bok
        static void ReturnerBok(List<Loan> loans)
        {   
            // Input for hvilken bok som skal returneres
            Console.Write("Skriv inn låne-ID: ");
            string loanId = Console.ReadLine();

            Loan funnetLån = null;

            // Sjekker etter lånt bok
            foreach (Loan loan in loans)
            {
                if (loan.LoanId == loanId)
                {
                    funnetLån = loan;
                    break;
                }
            }

            if (funnetLån == null)
            {
                Console.WriteLine("Fant ikke lån.");
                return;
            }

            if (funnetLån.IsReturned)
            {
                Console.WriteLine("Boken er allerede returnert.");
                return;
            }

            // Oppdaterer etter bok er returnert
            funnetLån.IsReturned = true;
            funnetLån.Book.AvailableCopies++;

            Console.WriteLine("Boken ble returnert.");
        }

    }
}

