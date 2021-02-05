using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_CSH_1 {
    class Day4 : Day {
        public Day4() : base(4) {
            addAufgabe("Übung 1, S. 61", uebung1);
            addAufgabe("Übung 2, S. 64", uebung2);
        }

        public void uebung1() {
            string text = "TestiTest";
            int klein = 0;
            int gross = 0;
            int i = 0;

            while (i < text.Length) {
                if (Char.IsUpper(text[i])) {
                    gross++;
                } else {
                    klein++;
                }
                i++;
            }

            Console.WriteLine("Grossbuchstanden: " + gross + "\nKleinbuchstaben: " + klein);
        }

        public void uebung2() {
            int zahl = 4;

            if (zahl == 1) {
                Console.WriteLine("eins");
            } else if (zahl == 2) {
                Console.WriteLine("zwei");
            } else if (zahl == 3) {
                Console.WriteLine("drei");
            } else {
                Console.WriteLine("unbekannte zahl");
            }

            // oder mit switch(case)
        }
    }
}
