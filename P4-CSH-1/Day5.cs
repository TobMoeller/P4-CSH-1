using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_CSH_1 {
    class Day5 : Day {
        public Day5() : base(5) {
            addAufgabe("\"Guten Morgen\" Übung", morgenUebung);
            addAufgabe("Übung 1", uebung1);
        }

        public void morgenUebung() {
            int zaehler, nenner, quotient;
            zaehler = 4;
            nenner = 0;
            try {
                quotient = zaehler / nenner;
                Console.WriteLine("Ergebnis: " + quotient);
            } catch (Exception e) {
                Console.WriteLine(e.Message);
                //throw;
            }
        }

        public void uebung1() {
            Console.WriteLine("Bitte gib dein Geburtsdatum ein (TT.MM.JJJJ)");
            DateTime geb = DateTime.Parse(Console.ReadLine());
            DateTime now = DateTime.Now;
            TimeSpan differenz = now - geb;
            
            Console.WriteLine("Du bist " + differenz.Days + " Tage alt.");
            Console.WriteLine("10000 Tage alt am: " + (geb + TimeSpan.FromDays(10000)).ToShortDateString());
            Console.WriteLine("20000 Tage alt am: " + (geb + TimeSpan.FromDays(20000)).ToShortDateString());
            Console.WriteLine("30000 Tage alt am: " + (geb + TimeSpan.FromDays(30000)).ToShortDateString());

            Console.WriteLine("Du bist " + differenz.TotalHours + " Stunden alt.");
            Console.WriteLine("200000 Stunden alt am: " + (geb + TimeSpan.FromHours(200000)).ToShortDateString());
            Console.WriteLine("300000 Stunden alt am: " + (geb + TimeSpan.FromHours(300000)).ToShortDateString());
            Console.WriteLine("500000 Stunden alt am: " + (geb + TimeSpan.FromHours(500000)).ToShortDateString());
        }
    }
}
