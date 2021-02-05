using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_CSH_1 {
    class Day20 : Day {
        public Day20() : base(20) {
            addAufgabe("G34 Übung 3 - Listen", Uebung1);
            addAufgabe("G52 Übung 2 - Vererbung / Konstruktoren", Uebung2);
        }

        /*
         *      G34: Aufgabe 3
         */
        public void Uebung1() {
            List<string[]> liste = new List<string[]>();

            string condition = "";
            while (condition.ToLower() != "ende") {
                Console.WriteLine("Bitte geben Sie das deutsche Wort oder \"Ende\" ein.");
                condition = Console.ReadLine();
                if (condition.ToLower() != "ende") { // Prüfung der ersten Eingabe auf "Ende"
                    string temp = condition;

                    Console.WriteLine("Bitte geben Sie das englische Wort oder \"Ende\" ein.");
                    condition = Console.ReadLine();
                    if (condition.ToLower() != "ende") { // Prüfen der zweiten Eingabe auf "Ende"
                        liste.Add(new string[2] { temp, condition });
                    }
                }
            }

            // Ausgabe
            foreach (string[] textArray in liste) {
                Console.WriteLine("Deutsch: " + textArray[0]);
                Console.WriteLine("Englisch: " + textArray[1] + "\n");
            }
        }

        /*
         *      G52: Aufgabe 2
         */
        public void Uebung2() {
            Gebaeude gebaeude1 = new Gebaeude();
            Gebaeude gebaeude2 = new Gebaeude("Musterstraße 1");
            Villa villa1 = new Villa();
            Villa villa2 = new Villa("Musterstraße 2");
            Villa villa3 = new Villa("Musterstraße 3", 1200000);
            Gebaeude.ZeigeGebaeudeListe();
            Villa.ZeigeVillaListe();
        }
        class Gebaeude {
            public string adresse;
            public static List<Gebaeude> gebaeude = new List<Gebaeude>();
            public static void ZeigeGebaeudeListe() {
                Console.WriteLine("Liste aller Gebäude:");
                gebaeude.ForEach(x => Console.WriteLine(x.adresse));
            }
            public Gebaeude() {
                gebaeude.Add(this);
            }
            public Gebaeude(string s) {
                gebaeude.Add(this);
                adresse = s;
            }
        }
        class Villa : Gebaeude {
            public int preis;
            public static List<Villa> villen = new List<Villa>();
            public static void ZeigeVillaListe() {
                Console.WriteLine("Liste aller Villen:");
                villen.ForEach(x => Console.WriteLine(x.adresse + ": " + x.preis));
            }
            public Villa() {
                villen.Add(this);
            }
            public Villa(string s) {
                villen.Add(this);
                adresse = s;
            }
            public Villa(string s, int p) {
                villen.Add(this);
                adresse = s;
                preis = p;
            }
        }
    }
}
