using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uebung_Pruefung1516
{
    abstract class Artikel
    {
        private int nummer;
        private string bezeichnung;

        protected double preis;

        public Artikel(int nummer,string bezeichnung,double preis) 
        { 
            this.nummer = nummer;
            this.bezeichnung = bezeichnung;
            this.preis = preis;
        }

        public int getNummer() { return this.nummer; }

        public string getBezeichnung() { return this.bezeichnung; }

        public abstract double getPreis();
    }
}
