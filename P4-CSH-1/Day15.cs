using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_CSH_1 {
    class Day15 : Day {
        public Day15() : base(15) {
            addAufgabe("Übung 1, Wiederholung Listen", Uebung1);
        }

        public void Uebung1() {
            // Option 1
            schreibgeschuetzteListe liste = new schreibgeschuetzteListe();
            Console.WriteLine(liste);

            // Option 2
            Adresse a1 = new Adresse("Müller", "Markus", "12345");
            Adresse a2 = new Adresse("Möller", "Murkus", "54321");
            Console.WriteLine(Adresse.alleAdressen());
        }

        // Option 1 mit Structure
        struct AdressDaten {
            public string name;
            public string vorname;
            public string strasse;
            public string ort;
            public string plz;
        }
        class schreibgeschuetzteListe {
            private List<AdressDaten> liste = new List<AdressDaten>();
            public schreibgeschuetzteListe() {
                AdressDaten test = new AdressDaten() { name = "Guenther" };
                liste.Add(new AdressDaten() { name = "Guenther", vorname="Alfred", strasse = "Hauptstr. 1", ort="Musterort", plz = "12345"});
                liste.Add(new AdressDaten() { name = "Florentin", vorname = "Minni", strasse = "Hauptstr. 2", ort = "Musterstadt", plz = "67890" });
            }

            public override string ToString() {
                string ausgabe = "";
                foreach (AdressDaten datum in liste) {
                    ausgabe += $"Name: {datum.name}, Vorname: {datum.vorname}, Strasse: {datum.strasse}, Ort: {datum.ort}, PLZ: {datum.plz}\n";
                }
                return ausgabe;
            }
        }

        // Option 2 mit Klasse
        class Adresse {
            public static readonly List<Adresse> Adressen = new List<Adresse>();
            public string Name { get; set; }
            public string Vorname { get; set; }
            public string PLZ { get; set; }

            public Adresse(string name, string vorname, string plz) {
                Name = name;
                Vorname = vorname;
                PLZ = plz;
                Adressen.Add(this);
            }

            public static string alleAdressen() {
                string ausgabe = "";
                foreach (Adresse adresse in Adressen) {
                    ausgabe += $"Name: {adresse.Name}, Vorname: {adresse.Vorname}, PLZ: {adresse.PLZ}\n";
                }
                return ausgabe;
            }
        }
    }
}
