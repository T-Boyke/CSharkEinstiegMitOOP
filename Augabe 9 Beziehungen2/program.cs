using System;

namespace StudentenDatenbank
{
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
            for (int i = 0; i < _studenten.Length; i++)
            {
                // Wir müssen prüfen, ob der Slot nicht null ist UND ob es der gesuchte Student ist.
                // Best Practice: Vergleich über die eindeutige Matrikelnummer ist sicherer als reiner Objektvergleich.
                if (_studenten[i] != null && _studenten[i].MatrikelNr == student.MatrikelNr)
                {
                    _studenten[i] = null; // Platz wieder freigeben
                    return true; // Erfolgreich entfernt
                }
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
