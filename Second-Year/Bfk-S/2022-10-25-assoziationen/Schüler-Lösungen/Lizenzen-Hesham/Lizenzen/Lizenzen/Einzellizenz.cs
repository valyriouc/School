using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lizenzen
{
    class Einzellizenz : Artikel
    {
        //Konstruktoraufruf der Vaterklasse
        public Einzellizenz(int nummer, string bezeichnung, double preis): base(nummer, bezeichnung, preis)
        {
        }

        public override double getPreis()
        {            
            return base.preis * 1.10;
        }
    }
}
