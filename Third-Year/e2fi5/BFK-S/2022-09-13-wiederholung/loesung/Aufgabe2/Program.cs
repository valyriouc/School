using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe2 {
    class Program {
        static void Main(string[] args) {
            string zahlS = "";
            do {
                Console.Write("Zahl eingeben: ");
                zahlS = Console.ReadLine();
                int zahl = int.Parse(zahlS);
                //Alternative Convert.ToInt32(zahlS)
                if (zahl != 0) {
                    double kehrwert = 1.0 / zahl;
                    Console.WriteLine($"Zahl:{zahl} Kehrwert:{kehrwert}");
                }
            } while (zahlS != "0");
            Console.ReadKey();
        }
    }
}
