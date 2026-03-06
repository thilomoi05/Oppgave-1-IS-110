using System;

namespace UniversitetsSystem
{
    class Program
    {
        static void Main(string[] args)
        {
          Student Thilo = new Student("s100", "Thilo", "thilo@gmail.com");
          Thilo.VisInfo();
          Console.WriteLine("Trykk Enter for å gå til menyen...");
          Console.ReadLine();

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
                        Console.WriteLine("Du valgte: Opprett kurs");
                        break;

                    case "2":
                        Console.WriteLine("Du valgte: Meld student til kurs");
                        break;

                    case "3":
                        Console.WriteLine("Du valgte: Print kurs og deltagere");
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
    }
}

