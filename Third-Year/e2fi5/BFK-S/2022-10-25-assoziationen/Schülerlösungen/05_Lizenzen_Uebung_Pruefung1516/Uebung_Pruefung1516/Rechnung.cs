using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uebung_Pruefung1516
{
    class Rechnung
    {
        Kunde kunde;

        public Rechnung(Kunde kunde)
        {
            this.kunde = kunde;
        }

        List<Artikel> artikelListe = new List<Artikel>();

        public double getGesamtbetrag() 
        {
            double gesamtbetrag = 0;

            for (int i = 0; i < artikelListe.Count; i++)
            {
                gesamtbetrag =+ Convert.ToDouble(artikelListe[i].getPreis());
            }
            
            return gesamtbetrag;
        }

        public void setArtikel(Artikel artikel) 
        {
            artikelListe.Add(artikel);
        }

        public void drucken() 
        {
            for (int i = 0; i < artikelListe.Count; i++)
            {
                Console.WriteLine(artikelListe[i]);
            }
            Console.WriteLine(kunde.getStrasse());
            Console.WriteLine(kunde.getName());
            Console.WriteLine(kunde.getOrt());
            Console.WriteLine(kunde.getKundennummer());
            Console.WriteLine(kunde.getPlz());
            Console.WriteLine(getGesamtbetrag());
            
        }
    }
}
