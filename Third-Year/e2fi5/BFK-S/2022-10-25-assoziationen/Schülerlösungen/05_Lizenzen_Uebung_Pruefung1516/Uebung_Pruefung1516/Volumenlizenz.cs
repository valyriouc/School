using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uebung_Pruefung1516
{
    class Volumenlizenz:Artikel
    {
        private int anzahl;

        public Volumenlizenz(int anzahl, int nummer, string bezeichnung, double preis) :base(nummer, bezeichnung, preis)
        {
            if (anzahl < 10)
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
            double num = 0.9;
            preis = anzahl * preis * num;
            return preis; 
        }
    }
}
