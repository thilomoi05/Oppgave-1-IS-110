using System;
using System.Collections.Generic;
using System.Linq;

namespace UniversitetsSystem
{
    class Program
    {
        static void Main(string[] args)
        {   
           
           
            UniversitySystem system = new UniversitySystem();
            SeedData(system);

            bool kjører = true;

            while (kjører)
            {
                Console.Clear();
                Console.WriteLine("=== VELKOMMEN TIL UNIVERSITETSSYSTEMET ===");
                Console.WriteLine("[1] Eksisterende bruker");
                Console.WriteLine("[2] Ny bruker");
                Console.WriteLine("[0] Avslutt");
                Console.Write("Velg: ");

                string valg = Console.ReadLine();

                switch (valg)
                {
                    case "1":
                        User innloggetBruker = LoginFlow(system);

                        if (innloggetBruker != null)
                        {
                            ShowRoleMenu(innloggetBruker, system);
                        }
                        break;

                    case "2":
                        RegisterFlow(system);
                        break;

                    case "0":
                        kjører = false;
                        Console.WriteLine("Programmet avsluttes...");
                        break;

                    default:
                        Console.WriteLine("Ugyldig valg.");
                        break;
                }

                if (kjører)
                {
                    Console.WriteLine("\nTrykk Enter for å fortsette...");
                    Console.ReadLine();
                }
            }
        }

        static void SeedData(UniversitySystem system)
        {
            Student s1 = new Student("S100", "Ola Nordmann", "ola@uia.no", "ola", "1234");
            Student s2 = new Student("S101", "Kari Hansen", "kari@uia.no", "kari", "1234");

            ExchangeStudent s3 = new ExchangeStudent(
                "S102",
                "Jean Dupont",
                "jean@paris.fr",
                "jean",
                "1234",
                "Sorbonne",
                "France",
                new DateTime(2025, 8, 1),
                new DateTime(2025, 12, 20)
            );

            Teacher t1 = new Teacher("E300", "Per Lærer", "per@uia.no", "perlaerer", "1234", "IT");
            Librarian l1 = new Librarian("E200", "Anne Hansen", "anne@uia.no", "anne", "1234", "Bibliotek");

            system.Students.Add(s1);
            system.Students.Add(s2);
            system.Students.Add(s3);

            system.Employees.Add(t1);
            system.Employees.Add(l1);

            system.Users.Add(s1);
            system.Users.Add(s2);
            system.Users.Add(s3);
            system.Users.Add(t1);
            system.Users.Add(l1);

            Course c1 = new Course("IS-110", "Programmering 1", 10, 30);
            Course c2 = new Course("IS-120", "Databaser", 10, 25);
            Course c3 = new Course("IS-130", "Systemutvikling", 10, 20);

            system.Courses.Add(c1);
            system.Courses.Add(c2);
            system.Courses.Add(c3);

            Book b1 = new Book("B100", "C# for Beginners", "A. Hansen", 2023, 3);
            Book b2 = new Book("B101", "Databaser i praksis", "K. Olsen", 2022, 2);

            system.Books.Add(b1);
            system.Books.Add(b2);
        }

        static User LoginFlow(UniversitySystem system)
        {
            Console.Clear();
            Console.WriteLine("=== LOGIN ===");

            Console.Write("Brukernavn: ");
            string username = Console.ReadLine();

            Console.Write("Passord: ");
            string password = Console.ReadLine();

            User user = system.Login(username, password);

            if (user == null)
            {
                Console.WriteLine("Feil brukernavn eller passord.");
                return null;
            }

            Console.WriteLine($"Innlogging vellykket. Velkommen, {user.Name}!");
            return user;
        }

        static void RegisterFlow(UniversitySystem system)
        {
            Console.Clear();
            Console.WriteLine("=== REGISTRER NY BRUKER ===");
            Console.WriteLine("[1] Student");
            Console.WriteLine("[2] Faglærer");
            Console.WriteLine("[3] Bibliotekar");
            Console.Write("Velg rolle: ");

            string rollevalg = Console.ReadLine();

            Console.Write("Navn: ");
            string name = Console.ReadLine();

            Console.Write("E-post: ");
            string email = Console.ReadLine();

            Console.Write("Brukernavn: ");
            string username = Console.ReadLine();

            if (system.UsernameExists(username))
            {
                Console.WriteLine("Brukernavnet finnes allerede.");
                return;
            }

            Console.Write("Passord: ");
            string password = Console.ReadLine();

            if (rollevalg == "1")
            {
                Console.Write("StudentID: ");
                string studentId = Console.ReadLine();

                Student student = new Student(studentId, name, email, username, password);

                system.Students.Add(student);
                system.Users.Add(student);

                Console.WriteLine("Student registrert.");
            }
            else if (rollevalg == "2")
            {
                Console.Write("EmployeeID: ");
                string employeeId = Console.ReadLine();

                Console.Write("Avdeling: ");
                string department = Console.ReadLine();

                Teacher teacher = new Teacher(employeeId, name, email, username, password, department);

                system.Employees.Add(teacher);
                system.Users.Add(teacher);

                Console.WriteLine("Faglærer registrert.");
            }
            else if (rollevalg == "3")
            {
                Console.Write("EmployeeID: ");
                string employeeId = Console.ReadLine();

                Console.Write("Avdeling: ");
                string department = Console.ReadLine();

                Librarian librarian = new Librarian(employeeId, name, email, username, password, department);

                system.Employees.Add(librarian);
                system.Users.Add(librarian);

                Console.WriteLine("Bibliotekar registrert.");
            }
            else
            {
                Console.WriteLine("Ugyldig rollevalg.");
            }
        }

        static void ShowRoleMenu(User user, UniversitySystem system)
        {
            if (user is Student student)
            {
                ShowStudentMenu(student, system);
            }
            else if (user is Teacher teacher)
            {
                ShowTeacherMenu(teacher, system);
            }
            else if (user is Librarian librarian)
            {
                ShowLibrarianMenu(librarian, system);
            }
        }

        
        static void ShowStudentMenu(Student student, UniversitySystem system)
        {
            bool tilbake = false;

            while (!tilbake)
            {
                Console.Clear();
                Console.WriteLine("=== STUDENTMENY ===");
                Console.WriteLine($"Innlogget som: {student.Name}");
                Console.WriteLine();
                Console.WriteLine("[1] Se mine kurs");
                Console.WriteLine("[2] Meld meg på kurs");
                Console.WriteLine("[3] Meld meg av kurs");
                Console.WriteLine("[4] Se mine lån");
                Console.WriteLine("[5] Søk på bøker");
                Console.WriteLine("[6] Lån bok");
                Console.WriteLine("[7] Returner bok");
                Console.WriteLine("[8] Se mine karakterer");
                Console.WriteLine("[0] Logg ut");
                Console.Write("Velg: ");

                string valg = Console.ReadLine();

                switch (valg)
                {
                    case "1":
                        ShowStudentCourses(student);
                        break;

                    case "2":
                        EnrollStudentInCourse(student, system);
                        break;

                    case "3":
                        UnenrollStudentFromCourse(student);
                        break;

                    case "4":
                        ShowStudentLoans(student, system);
                        break;

                    case "5":
                        SøkPåBok(system.Books);
                        break;

                    case "6":
                        BorrowBookAsStudent(student, system);
                        break;

                    case "7":
                        ReturnBookAsStudent(student, system);
                        break;

                    case "8":
                        ShowStudentGrades(student);
                        break;

                    case "0":
                        tilbake = true;
                        Console.WriteLine("Logger ut...");
                        break;

                    default:
                        Console.WriteLine("Ugyldig valg.");
                        break;
                }

                if (!tilbake)
                {
                    Console.WriteLine("\nTrykk Enter for å fortsette...");
                    Console.ReadLine();
                }
            }
        }

        static void ShowStudentCourses(Student student)
        {
            Console.Clear();
            Console.WriteLine("=== MINE KURS ===");

            if (student.Courses.Count == 0)
            {
                Console.WriteLine("Du er ikke meldt på noen kurs.");
                return;
            }

            foreach (Course course in student.Courses)
            {
                Console.WriteLine($"{course.Code} - {course.Name} ({course.Credits} sp)");
            }
        }


        static void EnrollStudentInCourse(Student student, UniversitySystem system)
        {
            Console.Clear();
            Console.WriteLine("=== MELD MEG PÅ KURS ===");

            if (system.Courses.Count == 0)
            {
                Console.WriteLine("Ingen kurs er tilgjengelige.");
                return;
            }

            Console.WriteLine("Tilgjengelige kurs:");
            for (int i = 0; i < system.Courses.Count; i++)
            {
                Course course = system.Courses[i];
                Console.WriteLine($"[{i + 1}] {course.Code} - {course.Name} ({course.Credits} sp)");
            }

            Console.Write("\nVelg kursnummer: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int valg))
            {
                Console.WriteLine("Du må skrive inn et gyldig tall.");
                return;
            }

            if (valg < 1 || valg > system.Courses.Count)
            {
                Console.WriteLine("Ugyldig valg.");
                return;
            }

            Course valgtKurs = system.Courses[valg - 1];
            bool success = valgtKurs.EnrollStudent(student);

            if (success)
            {
                Console.WriteLine($"Du er nå meldt på {valgtKurs.Name}.");
            }
            else
            {
                Console.WriteLine("Kunne ikke melde deg på kurset. Du er kanskje allerede påmeldt, eller kurset er fullt.");
            }
        }

        static void UnenrollStudentFromCourse(Student student)
        {
            Console.Clear();
            Console.WriteLine("=== MELD MEG AV KURS ===");

            if (student.Courses.Count == 0)
            {
                Console.WriteLine("Du er ikke meldt på noen kurs.");
                return;
            }

            Console.WriteLine("Dine kurs:");
            for (int i = 0; i < student.Courses.Count; i++)
            {
                Course course = student.Courses[i];
                Console.WriteLine($"[{i + 1}] {course.Code} - {course.Name}");
            }

            Console.Write("\nVelg kursnummer: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int valg))
            {
                Console.WriteLine("Du må skrive inn et gyldig tall.");
                return;
            }

            if (valg < 1 || valg > student.Courses.Count)
            {
                Console.WriteLine("Ugyldig valg.");
                return;
            }

            Course valgtKurs = student.Courses[valg - 1];
            bool success = valgtKurs.UnenrollStudent(student.StudentID);

            if (success)
            {
                Console.WriteLine($"Du er nå meldt av {valgtKurs.Name}.");
            }
            else
            {
                Console.WriteLine("Kunne ikke melde deg av kurset.");
            }
        }

        
        static void ShowStudentLoans(Student student, UniversitySystem system)
        {
            Console.Clear();
            Console.WriteLine("=== MINE LÅN ===");

            var mineLån = system.Loans
                .Where(loan => loan.Borrower.GetBorrowerId() == student.StudentID && !loan.IsReturned)
                .ToList();

            if (mineLån.Count == 0)
            {
                Console.WriteLine("Du har ingen aktive lån.");
                return;
            }

            foreach (Loan loan in mineLån)
            {
                loan.PrintInfo();
            }
        }

        static void ShowStudentGrades(Student student)
        {
            Console.Clear();
            Console.WriteLine("=== MINE KARAKTERER ===");

            if (student.Courses.Count == 0)
            {
                Console.WriteLine("Du er ikke meldt på noen kurs.");
                return;
            }

            bool fantKarakter = false;

            foreach (Course course in student.Courses)
            {
                string grade = course.GetGrade(student.StudentID);

                if (grade != null)
                {
                    Console.WriteLine($"{course.Code} - {course.Name}: {grade}");
                    fantKarakter = true;
                }
            }

            if (!fantKarakter)
            {
                Console.WriteLine("Ingen karakterer registrert ennå.");
            }
        }

        static void BorrowBookAsStudent(Student student, UniversitySystem system)
        {
            Console.Clear();
            Console.WriteLine("=== LÅN BOK ===");

            Console.Write("Skriv inn bok-ID: ");
            string bookId = Console.ReadLine();

            Book funnetBok = system.Books.FirstOrDefault(book => book.Id == bookId);

            if (funnetBok == null)
            {
                Console.WriteLine("Fant ikke bok.");
                return;
            }

            if (!funnetBok.BorrowCopy())
            {
                Console.WriteLine("Ingen eksemplarer tilgjengelig.");
                return;
            }

            string loanId = "L" + (system.Loans.Count + 1);
            Loan nyttLån = new Loan(loanId, funnetBok, student);

            system.Loans.Add(nyttLån);

            Console.WriteLine("Boken ble lånt.");
            nyttLån.PrintInfo();
        }

        static void ReturnBookAsStudent(Student student, UniversitySystem system)
        {
            Console.Clear();
            Console.WriteLine("=== RETURNER BOK ===");

            var mineAktiveLån = system.Loans
                .Where(loan => loan.Borrower.GetBorrowerId() == student.StudentID && !loan.IsReturned)
                .ToList();

            if (mineAktiveLån.Count == 0)
            {
                Console.WriteLine("Du har ingen aktive lån.");
                return;
            }

            Console.WriteLine("Dine aktive lån:");
            for (int i = 0; i < mineAktiveLån.Count; i++)
            {
                Console.Write($"[{i + 1}] ");
                mineAktiveLån[i].PrintInfo();
            }

            Console.Write("\nVelg lånenummer: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int valg))
            {
                Console.WriteLine("Du må skrive inn et gyldig tall.");
                return;
            }

            if (valg < 1 || valg > mineAktiveLån.Count)
            {
                Console.WriteLine("Ugyldig valg.");
                return;
            }

            Loan valgtLån = mineAktiveLån[valg - 1];
            valgtLån.IsReturned = true;
            valgtLån.Book.ReturnCopy();

            Console.WriteLine("Boken ble returnert.");
        }


       static void ShowTeacherMenu(Teacher teacher, UniversitySystem system)
        {
            bool tilbake = false;

            while (!tilbake)
            {
                Console.Clear();
                Console.WriteLine("=== FAGLÆRERMENY ===");
                Console.WriteLine($"Innlogget som: {teacher.Name}");
                Console.WriteLine();
                Console.WriteLine("[1] Opprett kurs");
                Console.WriteLine("[2] Vis kurs og deltagere");
                Console.WriteLine("[3] Meld student på kurs");
                Console.WriteLine("[4] Meld student av kurs");
                Console.WriteLine("[5] Søk på kurs");
                Console.WriteLine("[6] Søk på bøker");
                Console.WriteLine("[7] Lån bok");
                Console.WriteLine("[8] Returner bok");
                Console.WriteLine("[9] Sett karakter");
                Console.WriteLine("[10] Registrer pensum");
                Console.WriteLine("[0] Logg ut");
                Console.Write("Velg: ");

                string valg = Console.ReadLine();

                switch (valg)
                {
                    case "1":
                        OpprettKurs(system.Courses);
                        break;

                    case "2":
                        PrintKursOgDeltagere(system.Courses);
                        break;

                    case "3":
                        MeldStudentTilKurs(system.Students, system.Courses);
                        break;

                    case "4":
                        MeldStudentAvKurs(system.Courses);
                        break;

                    case "5":
                        SøkPåKurs(system.Courses);
                        break;

                    case "6":
                        SøkPåBok(system.Books);
                        break;

                    case "7":
                        List<Teacher> teachers = system.Employees
                            .OfType<Teacher>()
                            .ToList();

                        LånBok(system.Students, teachers, system.Books, system.Loans);
                        break;

                   case "8":
                        ReturnBookAsTeacher(teacher, system);
                        break;

                    case "9":
                        SetGradeForStudent(system.Courses);
                        break;

                    case "10":
                        RegisterSyllabusForCourse(system.Courses);
                        break;

                    case "0":
                        tilbake = true;
                        Console.WriteLine("Logger ut...");
                        break;

                    default:
                        Console.WriteLine("Ugyldig valg.");
                        break;
                }

                if (!tilbake)
                {
                    Console.WriteLine("\nTrykk Enter for å fortsette...");
                    Console.ReadLine();
                }
            }
        }

        static void ReturnBookAsTeacher(Teacher teacher, UniversitySystem system)
        {
            Console.Clear();
            Console.WriteLine("=== RETURNER BOK ===");

            var mineAktiveLån = system.Loans
                .Where(loan => loan.Borrower.GetBorrowerId() == teacher.EmployeeID && !loan.IsReturned)
                .ToList();

            if (mineAktiveLån.Count == 0)
            {
                Console.WriteLine("Du har ingen aktive lån.");
                return;
            }

            Console.WriteLine("Dine aktive lån:");
            for (int i = 0; i < mineAktiveLån.Count; i++)
            {
                Console.Write($"[{i + 1}] ");
                mineAktiveLån[i].PrintInfo();
            }

            Console.Write("\nVelg lånenummer: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int valg))
            {
                Console.WriteLine("Du må skrive inn et gyldig tall.");
                return;
            }

            if (valg < 1 || valg > mineAktiveLån.Count)
            {
                Console.WriteLine("Ugyldig valg.");
                return;
            }

            Loan valgtLån = mineAktiveLån[valg - 1];
            valgtLån.IsReturned = true;
            valgtLån.Book.ReturnCopy();

            Console.WriteLine("Boken ble returnert.");
        }


        static void ShowLibrarianMenu(Librarian librarian, UniversitySystem system)
        {
            bool tilbake = false;

            while (!tilbake)
            {
                Console.Clear();
                Console.WriteLine("=== BIBLIOTEKARMENY ===");
                Console.WriteLine($"Innlogget som: {librarian.Name}");
                Console.WriteLine();
                Console.WriteLine("[1] Registrer bok");
                Console.WriteLine("[2] Søk etter bok");
                Console.WriteLine("[3] Lån ut bok");
                Console.WriteLine("[4] Returner bok");
                Console.WriteLine("[5] Vis aktive lån");
                Console.WriteLine("[6] Vis lånehistorikk");
                Console.WriteLine("[0] Logg ut");
                Console.Write("Velg: ");

                string valg = Console.ReadLine();

                switch (valg)
                {
                    case "1":
                        RegistrerBok(system.Books);
                        break;

                    case "2":
                        SøkPåBok(system.Books);
                        break;

                    case "3":
                        List<Teacher> teachers = system.Employees
                            .OfType<Teacher>()
                            .ToList();

                        LånBok(system.Students, teachers, system.Books, system.Loans);
                        break;

                    case "4":
                        ReturnerBok(system.Loans);
                        break;

                    case "5":
                        VisAktiveLån(system.Loans);
                        break;

                    case "6":
                        VisLåneHistorikk(system.Loans);
                        break;

                    case "0":
                        tilbake = true;
                        Console.WriteLine("Logger ut...");
                        break;

                    default:
                        Console.WriteLine("Ugyldig valg.");
                        break;
                }

                if (!tilbake)
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

            bool kursFinnes = courses.Any(course =>
                course.Code.ToLower() == code.ToLower() ||
                course.Name.ToLower() == name.ToLower());

            if (kursFinnes)
            {
                Console.WriteLine("Et kurs med samme kurskode eller kursnavn finnes allerede.");
                return;
            }

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
        
        // Metode for å melde student på kurs
        static void MeldStudentTilKurs(List<Student> students, List<Course> courses)
        {
            Console.Write("Skriv inn StudentID: ");
            string studentId = Console.ReadLine();

            Console.Write("Skriv inn kurskode: ");
            string courseCode = Console.ReadLine();

            // LINQ søk etter student
            Student funnetStudent = students.FirstOrDefault(student => student.StudentID == studentId);
            Course funnetKurs = courses.FirstOrDefault(course => course.Code == courseCode);

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
            bool alleredePåmeldt = funnetKurs.Students
                .Any(student => student.StudentID == funnetStudent.StudentID);

            if (alleredePåmeldt)
            {
                Console.WriteLine("Studenten er allerede meldt på kurset.");
                return;
            }

            // Hvis alt stemmer blir student lagt til i kurset og får tilbakemelding
            bool success = funnetKurs.EnrollStudent(funnetStudent);

            if (success)
            {
                Console.WriteLine("Studenten ble meldt på kurset.");
            }
            else
            {
                Console.WriteLine("Kunne ikke melde studenten på kurset.");
            }

        }

        // Metode for å melde student av kurs
        static void MeldStudentAvKurs(List<Course> courses)
        {
            Console.Write("Skriv inn kurskode: ");
            string courseCode = Console.ReadLine();

            Course funnetKurs = courses.FirstOrDefault(c => c.Code == courseCode);

            if (funnetKurs == null)
            {
                Console.WriteLine("Fant ikke kurs.");
                return;
            }

            Console.Write("Skriv inn StudentID: ");
            string studentId = Console.ReadLine();

            bool success = funnetKurs.UnenrollStudent(studentId);

            if (success)
            {
                Console.WriteLine("Studenten ble meldt av kurset.");
            }
            else
            {
                Console.WriteLine("Studenten var ikke meldt på kurset.");
            }
        }
        
        static void SetGradeForStudent(List<Course> courses)
        {
            Console.Clear();
            Console.WriteLine("=== SETT KARAKTER ===");

            Console.Write("Skriv inn kurskode: ");
            string courseCode = Console.ReadLine();

            Course funnetKurs = courses.FirstOrDefault(c => c.Code == courseCode);

            if (funnetKurs == null)
            {
                Console.WriteLine("Fant ikke kurs.");
                return;
            }

            Console.Write("Skriv inn StudentID: ");
            string studentId = Console.ReadLine();

            Console.Write("Skriv inn karakter: ");
            string grade = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(grade))
            {
                Console.WriteLine("Karakter kan ikke være tom.");
                return;
            }

            bool success = funnetKurs.SetGrade(studentId, grade.ToUpper());

            if (success)
            {
                Console.WriteLine("Karakter registrert.");
            }
            else
            {
                Console.WriteLine("Studenten er ikke meldt på dette kurset.");
            }
        }

        static void RegisterSyllabusForCourse(List<Course> courses)
        {
            Console.Clear();
            Console.WriteLine("=== REGISTRER PENSUM ===");

            Console.Write("Skriv inn kurskode: ");
            string courseCode = Console.ReadLine();

            Course funnetKurs = courses.FirstOrDefault(c => c.Code == courseCode);

            if (funnetKurs == null)
            {
                Console.WriteLine("Fant ikke kurs.");
                return;
            }

            Console.Write("Skriv inn pensumtekst: ");
            string syllabusItem = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(syllabusItem))
            {
                Console.WriteLine("Pensum kan ikke være tomt.");
                return;
            }

            funnetKurs.AddSyllabusItem(syllabusItem);
            Console.WriteLine("Pensum registrert.");
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

            var resultater = books
                .Where(book =>
                    book.Title.ToLower().Contains(søk.ToLower()) ||
                    book.Id.ToLower() == søk.ToLower())
                .ToList();

            if (resultater.Count == 0)
            {
                Console.WriteLine("Fant ingen bøker.");
                return;
            }

            Console.WriteLine("\nTreff:");
            foreach (Book book in resultater)
            {
                book.PrintInfo();
            }
        }

        // Metode for at bruker kan låne bok
        static void LånBok(List<Student> students, List<Teacher> teachers, List<Book> books, List<Loan> loans)
        {   
            // Får bokID av bruker
            Console.Write("Skriv inn bok-ID: ");
            string bookId = Console.ReadLine();

            // Sjekker om bok finnes
           Book funnetBok = books.FirstOrDefault(book => book.Id == bookId);


            if (funnetBok == null)
            {
                Console.WriteLine("Fant ikke bok."); // Hvis ikke boka finnes får bruker beskjed
                return;
            }

            if (!funnetBok.BorrowCopy())
            {
                Console.WriteLine("Ingen eksemplarer tilgjengelig.");
                return;
            }

            Console.Write("Er låner [1] Student eller [2] Faglærer? "); // Sjekker om låner er student eller ansatt
            string valg = Console.ReadLine();

            IBorrower borrower = null;

            if (valg == "1")
            {
                Console.Write("Skriv inn StudentID: "); // Skrive inn studentID hvis student
                string studentId = Console.ReadLine();

                // Sjekker om student finnes
                borrower = students.FirstOrDefault(student => student.StudentID == studentId);
            }
            else if (valg == "2")
            {
                Console.Write("Skriv inn EmployeeID: ");
                string teacherId = Console.ReadLine();

                borrower = teachers.FirstOrDefault(teacher => teacher.EmployeeID == teacherId);
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
            

            Console.WriteLine("Boken ble lånt ut.");
            nyttLån.PrintInfo();
        }

        // Metode for å returnere bok
        static void ReturnerBok(List<Loan> loans)
        {
            Console.Write("Skriv inn låne-ID: ");
            string loanId = Console.ReadLine();

            Loan funnetLån = loans.FirstOrDefault(loan => loan.LoanId == loanId);

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

            funnetLån.IsReturned = true;
            funnetLån.Book.ReturnCopy();

            Console.WriteLine("Boken ble returnert.");
        }

        // Metode som bruker link for å søke på et kurs
        static void SøkPåKurs(List<Course> courses)
        {
            Console.Write("Skriv inn kurskode eller kursnavn: ");
            string søk = Console.ReadLine();

            var resultater = courses
                .Where(course =>
                    course.Code.ToLower().Contains(søk.ToLower()) ||
                    course.Name.ToLower().Contains(søk.ToLower()))
                .ToList();

            if (resultater.Count == 0)
            {
                Console.WriteLine("Fant ingen kurs.");
                return;
            }

            Console.WriteLine("\nTreff:");
            foreach (Course course in resultater)
            {
                Console.WriteLine($"{course.Code} - {course.Name} ({course.Credits} sp)");
            }
        }

        // Metode for å vise aktive lån
        static void VisAktiveLån(List<Loan> loans)
        {
            var aktiveLån = loans.Where(l => !l.IsReturned).ToList();

            if (aktiveLån.Count == 0)
            {
                Console.WriteLine("Ingen aktive lån.");
                return;
            }

            Console.WriteLine("\n=== AKTIVE LÅN ===");

            foreach (Loan loan in aktiveLån)
            {
                loan.PrintInfo();
            }
        }

        // Metode for å vise låne historikk
        static void VisLåneHistorikk(List<Loan> loans)
        {
            var historikk = loans.Where(l => l.IsReturned).ToList();

            if (historikk.Count == 0)
            {
                Console.WriteLine("Ingen tidligere lån.");
                return;
            }

            Console.WriteLine("\n=== LÅNEHISTORIKK ===");

            foreach (Loan loan in historikk)
            {
                loan.PrintInfo();
            }
        }
    

    }
}

