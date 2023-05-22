using System;

namespace Lizenzen
{
    class Program
    {
        static void Main(string[] args)
        {
            Kunde kunde = new Kunde(1234, "Hesham", "Musterstrasse", 12345, "Stuttgart");
            Einzellizenz einzellizenz = new Einzellizenz(4321, "Einzellizenz1", 150.99);
            Volumenlizenz volumenlizenz = new Volumenlizenz(10, 56789, "Volumenlizenz", 99.99);
            Rechnung rechnung = new Rechnung(kunde);

            rechnung.setArtikel(einzellizenz);
            rechnung.setArtikel(volumenlizenz);

            rechnung.drucken();

            Console.ReadKey();

        }
    }
}
