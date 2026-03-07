using System;
using System.Collections.Generic;

namespace UniversitetsSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Lister for Stduent og Course objekter som er laget
            List<Student> students = new List<Student>();
            List<Course> courses = new List<Course>();

            students.Add(new Student("S100", "Ola Nordmann", "ola@uia.no"));
            students.Add(new Student("S101", "Kari Hansen", "kari@uia.no"));

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
                        Console.WriteLine("Du valgte: Søk på bok");
                        break;

                    case "6":
                        Console.WriteLine("Du valgte: Lån bok");
                        break;

                    case "7":
                        Console.WriteLine("Du valgte: Returner bok");
                        break;

                    case "8":
                        Console.WriteLine("Du valgte: Registrer bok");
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
                        Console.WriteLine($"- {student.Navn} ({student.StudentID})");
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
    }
}

