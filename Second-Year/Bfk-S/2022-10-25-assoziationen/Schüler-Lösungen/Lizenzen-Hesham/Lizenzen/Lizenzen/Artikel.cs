using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lizenzen
{
    abstract class Artikel
    {
        private int nummer;
        private string bezeichnung;
        protected double preis;

        public Artikel(int nummer, string bezeichnung, double preis)
        {
            this.nummer = nummer;
            this.bezeichnung = bezeichnung;
            this.preis = preis;
        }

        public int getNummer()
        {
            return nummer;
        }

        public string getBezeichnung()
        {
            return bezeichnung;
        }

        abstract public double getPreis();

    }
}
