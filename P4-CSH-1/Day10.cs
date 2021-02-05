using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4_CSH_1 {
    class Day10 : Day {
        public Day10() : base(10) {
            addAufgabe("Lerngruppe: Delegate / Lambda", Lerngruppe1);
        }
        
        public void Lerngruppe1() {
            int[] testArray = new int[] {1, 2, 3};

            testClass.testMethode((i, j) => {
                int v = i - j;
                return 12 - v; 
            });
            testClass.testMethode(testClass.mehrTest);
        }
        class testClass {
            public delegate int testDelegate(int k, int guenther);
            public static int mehrTest (int k, int j) { return 7 - k - j; }

            public static void testMethode(testDelegate variabel) {
                Console.WriteLine("Ausgabe des berechneten Integers: " + variabel(5, 3));
            }
        }
    }
}
