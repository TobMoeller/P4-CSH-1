using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P4_CSH_1 {
    class Day17 : Day {
        public Day17() : base(17) {
            addAufgabe("Übung 6, Delegates und Events", Uebung1);
            addAufgabe("Code Review ILP Events Beispiel3", Uebung2);
        }

        // Aufgabe 6, Delegates und Events
        public void Uebung1() {
            DateTime today = DateTime.Now;
            Baeckerei baeckerei = new Baeckerei();
            Kunde kunde1 = new Kunde("Guenther", new DateTime(2021, 1, 29), "Erdbeere", baeckerei.GeburtstagskuchenBacken);
            Kunde kunde2 = new Kunde("Manfred", new DateTime(2021, 2, 2), "Himbeere", baeckerei.GeburtstagskuchenBacken);

            while (today <= DateTime.Now.AddDays(50)) {
                Console.WriteLine(today.ToShortDateString());
                foreach (Kunde kunde in Kunde.kunden) {
                    kunde.GeburtstagPruefen(today);
                }
                Thread.Sleep(100);
                today = today.AddDays(1);
            }
        }

        class Baeckerei {
            public void GeburtstagskuchenBacken(string geschmacksrichtung, string name) {
                Console.WriteLine($"Wir backen für {name} zum Geburtstag einen Kuchen mit seiner Lieblingsgeschmacksrichtung {geschmacksrichtung}");
            }
        }
        class Kunde {
            public static List<Kunde> kunden = new List<Kunde>();
            public string Name { get; set; }
            public DateTime Geburtstag { get; set; }
            public string Lieblingsgeschmacksrichtung { get; set; }

            public delegate void geburtstagshandler(string geschmacksrichtung, string name);
            public event geburtstagshandler geburtstagsevent;
            public Kunde(string name, DateTime geburtstag, string geschmacksrichtung, geburtstagshandler geburtstagsabonnent) {
                Name = name;
                Geburtstag = geburtstag;
                Lieblingsgeschmacksrichtung = geschmacksrichtung;
                kunden.Add(this);
                geburtstagsevent += geburtstagsabonnent;
            }
            public void GeburtstagPruefen(DateTime tag) {
                if (Geburtstag.Date == tag.Date) {
                    geburtstagsevent?.Invoke(Lieblingsgeschmacksrichtung, Name);
                }
            }
        }

        /*
         *      Übung 2, ILP Events Beispiel 3
         */
        public void Uebung2() {
            Auto auto = new Auto(40);
            Fahrer fahrer = new Fahrer();

            auto.TankfüllstandNiedrig += fahrer.OnTankfüllstandNiedrig; // Event abonnieren

            auto.Fahren();
        }
        // Ein Paket an Informationen, die der Sender dem Empfänger mitteilen möchte
        class TankfüllstandEventArgs : EventArgs {
            public string Farbe { get; private set; }
            // Erweiterbar durch weitere Eigenschaften...
            public TankfüllstandEventArgs(string farbe) {
                Farbe = farbe;
            }
        }

        // Sender
        class Auto {
            public event EventHandler TankfüllstandNiedrig;

            public int Tankfüllstand { get; set; }

            public Auto(int tankfüllstand) {
                Tankfüllstand = tankfüllstand;
            }

            public void Fahren() {
                // Endlosschleife
                while (true) {
                    // Wenn Tankfüllstand größer 0
                    if (Tankfüllstand > 0) {
                        // Ziehe vom Tank ab
                        Tankfüllstand--;
                        Console.WriteLine("Auto: Brumm...");
                        Thread.Sleep(500); // Warte eine halbe Sekunde

                        if (Tankfüllstand < 10) {
                            Console.WriteLine("Tankleuchte blinkt rot");
                            TankfüllstandEventArgs eventArgs = new TankfüllstandEventArgs("ROT"); // Objekt von EventArgs erzeugen
                            TankfüllstandNiedrig?.Invoke(this, eventArgs); // Event auslösen
                        } else if (Tankfüllstand < 15) {
                            Console.WriteLine("Tankleuchte blinkt gelb");
                            TankfüllstandNiedrig?.Invoke(this, new TankfüllstandEventArgs("GELB"));
                        }
                    } else if (Tankfüllstand <= 0)
                        break;
                }
            }
        }

        // Empfänger
        class Fahrer {
            public void Tanken(Auto auto) {
                auto.Tankfüllstand += 30;
            }

            // Methode, mit der der Empfänger das Event abonniert hat
            public void OnTankfüllstandNiedrig(object sender, EventArgs e) {
                if (sender is Auto) {
                    // Wenn die EventArgs in TankfüllstandEventArgs konvertiert werden können...
                    TankfüllstandEventArgs eventArgs = e as TankfüllstandEventArgs;
                    if (eventArgs != null) {
                        if (eventArgs.Farbe == "GELB")
                            Console.WriteLine("Fahrer: Ach, hat noch Zeit...");
                        else if (eventArgs.Farbe == "ROT") {
                            Console.WriteLine("Fahrer: Jetzt aber dringend Tanken...");
                            Tanken(sender as Auto);
                        }
                    }
                }

            }
        }
    }
}
