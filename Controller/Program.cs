using System;

namespace Controller
{
    /// <summary>
    /// Zentraler Controller für das C# OOP Einstiegs-Projekt.
    /// Steuert die Ausführung der einzelnen Aufgaben-Module.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("==============================================");
                Console.WriteLine("   C# OOP EINSTIEG - HAUPTMENÜ (Tom Selig)");
                Console.WriteLine("==============================================");
                Console.ResetColor();
                Console.WriteLine("Bitte wählen Sie eine Aufgabe:");
                Console.WriteLine();
                Console.WriteLine(" 1 - Aufgabe 01: Arrays & Grundlagen");
                Console.WriteLine(" 2 - Aufgabe 02: TV Simulation (Klassen Basics)");
                Console.WriteLine(" 3 - Aufgabe 03: Konstruktoren (Sweatshirt)");
                Console.WriteLine(" 4 - Aufgabe 04: Static Member (Warenhaus)");
                Console.WriteLine(" 5 - Aufgabe 05: IHK Theorie (Kein Code)");
                Console.WriteLine(" 6 - Aufgabe 06: Gesamtübung (MyDate)");
                Console.WriteLine(" 7 - Aufgabe 07: UML Zustandsdiagramme (Kein Code)");
                Console.WriteLine(" 8 - Aufgabe 08: Beziehungen Teil 1 (Parkplatz)");
                Console.WriteLine(" 9 - Aufgabe 09: Beziehungen Teil 2 (StudentenDB)");
                Console.WriteLine();
                Console.WriteLine(" 0 - BEENDEN");
                Console.WriteLine("==============================================");
                Console.Write("Ihre Auswahl: ");

                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Aufgabe_01_Array.App.Run();
                        break;
                    case "2":
                        Aufgabe_02_TV.App.Run();
                        break;
                    case "3":
                        Aufgabe_03_Konstruktoren.App.Run();
                        break;
                    case "4":
                        Aufgabe_04_Static_Member.App.Run();
                        break;
                    case "5":
                        ShowInfo("Aufgabe 05 enthält nur Dokumentation (Pseudocode/UML). Bitte Ordner prüfen.");
                        break;
                    case "6":
                        Aufgabe_06_Gesamt.App.Run();
                        break;
                    case "7":
                        ShowInfo("Aufgabe 07 enthält nur UML Diagramme. Bitte Ordner prüfen.");
                        break;
                    case "8":
                        Aufgabe_08_Beziehungen_Part1.App.Run();
                        break;
                    case "9":
                        Aufgabe_09_Beziehungen_Part2.App.Run();
                        break;
                    case "0":
                        running = false;
                        Console.WriteLine("Auf Wiedersehen!");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ungültige Eingabe! Bitte Zahl 0-9 wählen.");
                        Console.ResetColor();
                        Console.WriteLine("Taste drücken...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void ShowInfo(string message)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
            Console.WriteLine("\nTaste drücken zum Zurückkehren...");
            Console.ReadKey();
        }
    }
}
