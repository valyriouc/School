using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lizenzen
{
    class Volumenlizenz : Artikel
    {
        private int anzahl;

        //Konstruktoraufruf der Vaterklasse
        public Volumenlizenz(int anzahl, int nummer, string bezeichnung, double preis) : base(nummer, bezeichnung, preis)
        {
            if(anzahl < 10)
            {
                this.anzahl = 10;
            }
            else
            {
                this.anzahl = anzahl;
            }
            
        }

        public override double getPreis()
        {
            return anzahl * base.preis * 0.9;
        }
    }
}
