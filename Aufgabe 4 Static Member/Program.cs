namespace Aufgabe_4_Static_Member
{
    public class Warenhaus
    {
    //classDiagram
    //class Warenhaus{
    //- _name: string
    //- _warenbestand: int
    //- _kassenbestand: decimal
    //    
    ////%% Statische Felder für Aufgabe d)
    ////- _anzahlWarenhaueser: int$
    //- _gesamtWarenbestand: int$
    //- _gesamtKassenbestand: decimal$
    //    
    //%% Properties(Kapselung)
    //+ >>Name: string<<
    //+ >>Warenbestand: int<<
    //+ >>Kassenbestand: decimal<<
    //    
    //%% Konstruktor
    //+ Warenhaus(name:string, startWaren:int, startKasse:decimal)
    //    
    //%% Methoden
    //+InfoAusgeben() void
    //+Einkauf(menge:int) bool
    //+Verkauf(menge:int) bool
    //    
    //%% Statische Methoden
    //+ GetGesamtStatistik() string$}
        // Konstanten für Preise (Magic Numbers vermeiden)
        private const decimal EINKAUFSPREIS = 10m;
        private const decimal VERKAUFSPREIS = 20m;

        // --- Aufgabe d: Statische Elemente (Globales Tracking) ---
        // Diese tracken den Zustand ALLER Instanzen live mit.
        private static int _globalerWarenbestand = 0;
        private static decimal _globalerKassenbestand = 0m;
        private static int _anzahlWarenhaueser = 0;

        // --- Instanz-Eigenschaften (Properties mit Kapselung) ---
        public string Name { get; }
        public int Warenbestand { get; private set; }
        public decimal Kassenbestand { get; private set; }

        // --- Konstruktor ---
        public Warenhaus(string name, int startWaren, decimal startKasse)
        {
            Name = name;
            Warenbestand = startWaren;
            Kassenbestand = startKasse;

            // Statische Zähler beim Erstellen aktualisieren
            _anzahlWarenhaueser++;
            _globalerWarenbestand += startWaren;
            _globalerKassenbestand += startKasse;
        }

        // --- Aufgabe b & c: Methoden mit Mengenparameter ---

        /// <summary>
        /// Führt einen Einkauf durch.
        /// </summary>
        /// <param name="menge">Anzahl der zu kaufenden Waren (Standard 1)</param>
        public void Einkauf(int menge = 1)
        {
            if (menge <= 0) return; // Guard Clause für ungültige Eingaben

            decimal kosten = menge * EINKAUFSPREIS;

            // Ternärer Operator für Log-Ausgabe (optional, hier zur Demo)
            string status = (Kassenbestand >= kosten) ? "erfolgreich" : "fehlgeschlagen (Zu wenig Geld)";

            if (Kassenbestand >= kosten)
            {
                // Instanz aktualisieren
                Kassenbestand -= kosten;
                Warenbestand += menge;

                // Statische Summen live aktualisieren (Aufgabe d)
                _globalerKassenbestand -= kosten;
                _globalerWarenbestand += menge;

                // Console.WriteLine($"{Name}: Einkauf von {menge} Stk. {status}.");
            }
            else
            {
                // Console.WriteLine($"{Name}: Einkauf von {menge} Stk. {status}.");
            }
        }

        /// <summary>
        /// Führt einen Verkauf durch.
        /// </summary>
        /// <param name="menge">Anzahl der zu verkaufenden Waren (Standard 1)</param>
        public void Verkauf(int menge = 1)
        {
            if (menge <= 0) return;

            // Prüfung: Haben wir genug Ware?
            if (Warenbestand >= menge)
            {
                decimal gewinn = menge * VERKAUFSPREIS;

                // Instanz aktualisieren
                Kassenbestand += gewinn;
                Warenbestand -= menge;

                // Statische Summen live aktualisieren (Aufgabe d)
                _globalerKassenbestand += gewinn;
                _globalerWarenbestand -= menge;

                // Console.WriteLine($"{Name}: Verkauf von {menge} Stk. erfolgreich.");
            }
            else
            {
                // Console.WriteLine($"{Name}: Verkauf fehlgeschlagen (Nicht genug Ware).");
            }
        }

        // Methode zur Ausgabe der Instanzdaten
        public void InfoAusgeben()
        {
            Console.WriteLine($"[Filiale: {Name}] Kasse: {Kassenbestand:C} | Bestand: {Warenbestand} Stk.");
        }

        // --- Statische Methode zur Ausgabe der Gesamtdaten ---
        public static void GlobaleStatistikAusgeben()
        {
            Console.WriteLine(new string('-', 50));
            Console.WriteLine("KONZERN STATISTIK");
            Console.WriteLine($"Anzahl Filialen: {_anzahlWarenhaueser}");
            Console.WriteLine($"Gesamtkasse:     {_globalerKassenbestand:C}");
            Console.WriteLine($"Gesamtwaren:     {_globalerWarenbestand} Stk.");
            Console.WriteLine(new string('-', 50));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Initialisierung für Zufallszahlen
            Random rnd = new Random();

            // Array von Warenhäusern erstellen (Kette eröffnen)
            Warenhaus[] filialen = new Warenhaus[]
            {
                new Warenhaus("Zentrum", 50, 1000m),
                new Warenhaus("Nord", 20, 500m),
                new Warenhaus("Süd", 100, 2000m),
                new Warenhaus("West", 10, 200m),
                new Warenhaus("Ost", 5, 100m)
            };

            Console.WriteLine("Startzustand:");
            Warenhaus.GlobaleStatistikAusgeben();

            // --- Aufgabe e: Schleife mit 100 zufälligen Aktionen ---
            Console.WriteLine("\nStarte Simulation (100 Transaktionen)...\n");

            for (int i = 0; i < 100; i++)
            {
                // 1. Zufälliges Warenhaus auswählen
                Warenhaus aktuellesHaus = filialen[rnd.Next(filialen.Length)];

                // 2. Zufällige Aktion (0 = Einkauf, 1 = Verkauf)
                int aktion = rnd.Next(0, 2);

                // Zufällige Menge zwischen 1 und 5 für etwas Varianz
                int menge = rnd.Next(1, 6);

                // Ternärer Operator zur Entscheidungsfindung (Aufgabe: Best Practice -> Code kurz halten)
                if (aktion == 0)
                    aktuellesHaus.Einkauf(menge);
                else
                    aktuellesHaus.Verkauf(menge);
            }

            // Ausgabe der Daten zu jedem einzelnen Warenhaus
            Console.WriteLine("Endzustand der einzelnen Filialen:");
            foreach (var filiale in filialen)
            {
                filiale.InfoAusgeben();
            }

            // Ausgabe der summierten Ergebnisse (über statische Variablen, nicht durch Summenbildung im Array)
            Warenhaus.GlobaleStatistikAusgeben();

            Console.ReadKey();
        }
    }
}
