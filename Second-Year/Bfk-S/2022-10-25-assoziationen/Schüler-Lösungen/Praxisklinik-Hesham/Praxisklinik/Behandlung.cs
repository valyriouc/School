using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praxisklinik
{
    abstract class Behandlung
    {
        //--------------------------------------
        //          Die Attribute
        //--------------------------------------
        private string kvNummer;
        private string beschreibung;
        private double kostensatz;

        //--------------------------------------
        //          Die Konstruktoren
        //--------------------------------------
        public Behandlung()
        {
        }

        public Behandlung(string kvNummer, string beschreibung, double kostensatz)
        {
            this.kvNummer = kvNummer;
            this.beschreibung = beschreibung;
            this.kostensatz = kostensatz;
        }

        //--------------------------------------
        //          Die Methoden
        //--------------------------------------
        public abstract double getKosten();

        public string getKvNummer()
        {
            return kvNummer;
        }

        public string getBeschreibung()
        {
            return beschreibung;
        }

        public double getKostensatz()
        {
            return kostensatz;
        }
    }
}
