using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace P4_CSH_1 {
    class Day3 : Day {
        public Day3() : base(3) {
            addAufgabe("Kleine C# Übung", Uebung1);
            addAufgabe("ThreadingBeispiel", ThreadingExample);
        }

        public void Uebung1() {
            // S. 54 "Kleine C# Übung"
            Console.WriteLine("Ergebnis: " + Multipliziere(3, 5));

        }
        public int Multipliziere(int multiplikand, int multiplikator) {
            int produkt = 0;
            int i = 0;
            while (i < Math.Abs(multiplikand)) {
                if (multiplikand >= 0) {
                    produkt += multiplikator;
                } else {
                    produkt -= multiplikator;
                }
                i++;
            }
            return produkt;
        }

        // Threading Beispiel (nicht Kursrelevant)
        public class Zaehler {
            private string name;
            private int zahl;

            public Zaehler(string name, int zahl) {
                this.zahl = zahl;
                this.name = name;
            }

            public void Zaehle() {
                for (int i = 1; i <= zahl; i++) {
                    Console.WriteLine(name + ": " + i);
                    Thread.Sleep(100);
                }
            }
        }

        public void ThreadingExample() {
            Console.WriteLine("Zählen beginnt");

            Zaehler zaehler1 = new Zaehler("Thread A", 3);
            Zaehler zaehler2 = new Zaehler("Thread B", 6);

            Thread thread1 = new Thread(zaehler1.Zaehle);
            Thread thread2 = new Thread(zaehler2.Zaehle);

            thread1.Start();
            thread2.Start();

            thread1.Join();
            thread2.Join();

            Console.WriteLine("Zählen beendet");
            Console.ReadKey();
        }
        
    }
}
