using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Uebung_Pruefung1516
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Kunde kunde1 = new Kunde(00001,"Mustermann Max","Musterstaße",70565,"Stuttgart");
            Einzellizenz einzellizenz1 = new Einzellizenz(001, "Deo", 99.99);
            Volumenlizenz volumenlizenz1 = new Volumenlizenz(80, 001, "Deo", 99.99);
            Rechnung rechnung1 = new Rechnung(kunde1);
            rechnung1.setArtikel(einzellizenz1);
            rechnung1.setArtikel(volumenlizenz1);
            rechnung1.drucken();
            Console.ReadKey();
        }
    }
}
