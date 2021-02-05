using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_CSH_1 {
    class Day8 : Day {
        public Day8() : base(8) {
            addAufgabe("Beispiel String Interpolation", StringInterpolation);
            addAufgabe("Lerngruppe: Events", Lerngruppe1);
        }


        public void StringInterpolation() {
            string name = "Mark";
            int zahl1 = 7, zahl2 = 15;
            var date = DateTime.Now; // variabler datentyp
            // Quelle: https://docs.microsoft.com/de-de/dotnet/csharp/language-reference/tokens/interpolated
            // Composite Formatting:
            Console.WriteLine("Hello, {0}! Today is {1}, it's {2:HH:mm} now.", name, date.DayOfWeek, date);
            // String Interpolation
            Console.WriteLine($"\n\nHello, {name}! Today is {date.DayOfWeek}, it's {date:HH:mm} now. {zahl1}+{zahl2}={zahl1 + zahl2}");
        }

        public void Lerngruppe1() {
            Klasse1 klasse1 = new Klasse1();
            Klasse2 klasse2 = new Klasse2();
            klasse1.testVariable = klasse2.AbonnentMethode;
            klasse1.eventAufruf();
        }

        class Klasse1 {
            public delegate void delegatVar();
            public event delegatVar eventVar;
            public delegatVar testVariable;
            public void eventAufruf() {
                eventVar?.Invoke();
                testVariable?.Invoke();
            }
        }

        class Klasse2 {
            public void AbonnentMethode() {
                Console.WriteLine("Methodenaufruf des Abonnenten durch Event");
            }
        }
    }
}
