using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lizenzen
{
    class Rechnung
    {
        List<Artikel> artikelliste = new List<Artikel>();
        Kunde kunde;
        public Rechnung(Kunde kunde)
        {
            this.kunde = kunde;
        }

        public double getGesamtbetrag()
        {
            double summe = 0;

            foreach (Artikel item in artikelliste)
            {
                summe += item.getPreis();
            }
            return summe;
        }

        public void setArtikel (Artikel artikel)
        {
            artikelliste.Add(artikel);
        }

        public void drucken()
        {
            Console.WriteLine("Kundendaten:\n");
            Console.WriteLine("Kundenname: " + kunde.getName());
            Console.WriteLine("Kundennummer: " + kunde.getKundennummer(kunde.getName()));
            Console.WriteLine("Strasse: " + kunde.getStrasse());
            Console.WriteLine("PLZ: " + kunde.getPlz()+"\n");           
            Console.WriteLine("Artikelliste:\n");

            foreach (Artikel artikel in artikelliste)
            {
                Console.WriteLine("Artikelnummer: " + artikel.getNummer());
                Console.WriteLine("Artikelbezeichnung: " + artikel.getBezeichnung());
                Console.WriteLine("Artikelpreis: " + artikel.getPreis());
                Console.WriteLine("--------------------------------");
            }

            Console.WriteLine("\nGesamtrechnungbetrag: " + getGesamtbetrag());
        }

    }
}
