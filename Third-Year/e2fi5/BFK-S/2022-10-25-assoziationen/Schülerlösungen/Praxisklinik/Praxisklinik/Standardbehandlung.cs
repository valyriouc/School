using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praxisklinik
{
    class Standardbehandlung : Behandlung
    {
        //--------------------------------------
        //          Die Konstruktoren
        //--------------------------------------
        public Standardbehandlung()
        {
        }

        public Standardbehandlung(string kvNummer, string beschreibung, double kostensatz) : base(kvNummer, beschreibung, kostensatz)
        {

        }

        //--------------------------------------
        //          Die Methode(n)
        //--------------------------------------
        public override double getKosten()
        {
            return getKostensatz();
        }

    }
}
