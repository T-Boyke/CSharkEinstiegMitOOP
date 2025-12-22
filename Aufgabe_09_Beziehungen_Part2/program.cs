using System;

namespace Aufgabe_09_Beziehungen_Part2
{
    /// <summary>
    /// Steuerungsklasse für Aufgabe 09 (StudentenDatenbank).
    /// </summary>
    public class App
    {
        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("=== Aufgabe 09: StudentenDatenbank (Beziehungen II) ===");
            // 1. Datenbank für 3 Studenten anlegen
            Datenbank db = new Datenbank(3);

            // 2. Studenten erstellen
            Student s1 = new Student(1, "Peter", "Informatik");
            Student s2 = new Student(2, "Anna", "BWL");
            Student s3 = new Student(3, "Max", "Physik");
            Student s4 = new Student(4, "Lisa", "Chemie"); // Passt nicht mehr rein

            // 3. Hinzufügen testen
            Console.WriteLine($"Füge Peter hinzu: {db.AddStudent(s1)}");
            Console.WriteLine($"Füge Anna hinzu: {db.AddStudent(s2)}");
            Console.WriteLine($"Füge Max hinzu: {db.AddStudent(s3)}");
            Console.WriteLine($"Füge Lisa hinzu (sollte false sein): {db.AddStudent(s4)}");

            Console.WriteLine();

            // 4. Alles ausgeben
            db.PrintMe();

            // 5. Entfernen testen
            Console.WriteLine($"Entferne Anna: {db.RemoveStudent(s2)}");

            Console.WriteLine();

            // 6. Erneute Ausgabe (Lücke im Array sollte ignoriert werden)
            db.PrintMe();

            Console.WriteLine("\nDrücke eine Taste...");
            Console.ReadKey();
        }
    }
    // a) Klasse Student
    public class Student
    {
        // Best Practice: Properties mit 'get' und 'private set' entsprechen modernen Read-Only Feldern.
        // Die Aufgabe verlangt "Get-Methoden", Properties sind in C# die syntaktisch korrekte Umsetzung dafür.
        public int MatrikelNr { get; }
        public string Name { get; }
        public string Fachrichtung { get; }

        // Konstruktor zum Setzen der Werte
        public Student(int matrikelNr, string name, string fachrichtung)
        {
            MatrikelNr = matrikelNr;
            Name = name;
            Fachrichtung = fachrichtung;
        }

        // b) Methode PrintMe
        public void PrintMe()
        {
            Console.WriteLine($"Matrikel-Nr.: {MatrikelNr}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Fachrichtung: {Fachrichtung}");
            Console.WriteLine(new string('-', 20)); // Trennlinie für bessere Lesbarkeit
        }
    }

    // c) Klasse Datenbank
    public class Datenbank
    {
        // Das interne Array (der "Setzkasten")
        private Student[] _studenten;

        // Konstruktor: Legt die Größe des Arrays fest
        public Datenbank(int kapazitaet)
        {
            _studenten = new Student[kapazitaet];
        }

        // d) AddStudent: Fügt Student an den ersten freien Platz hinzu
        public bool AddStudent(Student student)
        {
            for (int i = 0; i < _studenten.Length; i++)
            {
                // Wir suchen einen Slot, der 'null' (leer) ist
                if (_studenten[i] == null)
                {
                    _studenten[i] = student;
                    return true; // Erfolgreich hinzugefügt
                }
            }
            return false; // Kein Platz mehr frei (Array voll)
        }

        // e) RemoveStudent: Entfernt einen spezifischen Studenten
        public bool RemoveStudent(Student student)
        {
            // 1. Suche den Index effizient mit einem Prädikat (Lambda-Ausdruck)
            // Array.FindIndex gibt -1 zurück, wenn nichts gefunden wurde.
            int index = Array.FindIndex(_studenten, s => s != null && s.MatrikelNr == student.MatrikelNr);
                // 2. Prüfen und Löschen
                if (index != -1)
                {
                    _studenten[index] = null; // Platz wieder freigeben
                    return true; // Erfolgreich entfernt
                }
            return false; // Student nicht gefunden
        }

        // f) CountStudents: Zählt belegte Plätze
        public int CountStudents()
        {
            int anzahl = 0;
            foreach (var s in _studenten)
            {
                // Nur zählen, wenn der Platz nicht leer ist
                if (s != null)
                {
                    anzahl++;
                }
            }
            return anzahl;
        }

        // g) PrintMe: Gibt alle Studenten aus
        public void PrintMe()
        {
            Console.WriteLine($"--- Datenbank Inhalt ({CountStudents()} Studenten) ---");
            foreach (var s in _studenten)
            {
                // Auf die PrintMe Methode der Klasse Student zurückgreifen
                if (s != null)
                {
                    s.PrintMe();
                }
            }
        }
    }
}
