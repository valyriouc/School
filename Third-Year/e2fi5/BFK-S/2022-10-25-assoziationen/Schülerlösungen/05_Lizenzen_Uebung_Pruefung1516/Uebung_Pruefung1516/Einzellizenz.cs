using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uebung_Pruefung1516
{
    class Einzellizenz:Artikel
    {
        public Einzellizenz(int nummer, string bezeichnung, double preis):base(nummer,bezeichnung,preis) { }

        public override double getPreis() 
        {
            double num = 1.1;
            preis = preis * num;
            return this.preis; 
        }
    }
}
