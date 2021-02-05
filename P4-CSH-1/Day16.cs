using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_CSH_1 {
    class Day16 : Day {
        public Day16() : base(16) {
            addAufgabe("Aufgabe 3, Interfaces", Uebung1);
        }

        public void Uebung1() {
            // Aufgabe 3
            Flugzeug flugzeug = new Flugzeug();
            Auto auto = new Auto();
            Panzer panzer = new Panzer();
            Boot boot = new Boot();
            foreach (Fahrzeug fahrzeug in Fahrzeug.Fahrzeuge) {
                // erster versuch, gibt besseren weg.
                //if (fahrzeug is Flugzeug) {
                //    (fahrzeug as Flugzeug).Fliegen();
                //    (fahrzeug as Flugzeug).Fahren();
                //} else if (fahrzeug is Auto) {
                //    (fahrzeug as Auto).Fahren();
                //} else if (fahrzeug is Panzer) {
                //    (fahrzeug as Panzer).Fahren();
                //    (fahrzeug as Panzer).Schwimmen();
                //} else if (fahrzeug is Boot) {
                //    (fahrzeug as Boot).Schwimmen();
                //}

                // Bessere Lösung:
                // "as" versucht das Objekt in den gegebenen Typ zu konvertieren und gibt null zurück, falls es nicht geht
                // "?" prüft ob der vorherige ausdruck nicht null ist
                (fahrzeug as IFlugfaehig)?.Fliegen();
                (fahrzeug as IFahrbar)?.Fahren();
                (fahrzeug as ISchwimmfaehig)?.Schwimmen();
            }
        }

        interface IFlugfaehig {
            void Fliegen();
        }
        interface IFahrbar {
            void Fahren();
        }
        interface ISchwimmfaehig {
            void Schwimmen();
        }

        abstract class Fahrzeug {
            public static List<Fahrzeug> Fahrzeuge = new List<Fahrzeug>();
            public Fahrzeug() {
                Fahrzeuge.Add(this);
            }
        }
        class Flugzeug : Fahrzeug, IFlugfaehig, IFahrbar {
            public void Fahren() {
                Console.WriteLine("Flugzeug: Fahrifahr");
            }

            public void Fliegen() {
                Console.WriteLine("Flugzeug: Fliegiflieg");
            }
        }
        class Auto : Fahrzeug, IFahrbar {
            public void Fahren() {
                Console.WriteLine("Auto: Fahrifahr");
            }
        }
        class Panzer : Fahrzeug, IFahrbar, ISchwimmfaehig {
            public void Fahren() {
                Console.WriteLine("Panzer: Fahrifahr");
            }

            public void Schwimmen() {
                Console.WriteLine("Panzer: Schwimmischwimm");
            }
        }
        class Boot : Fahrzeug, ISchwimmfaehig {
            public void Schwimmen() {
                Console.WriteLine("Boot: Schwimmischwimm");
            }
        }
    }
}
