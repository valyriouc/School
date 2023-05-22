using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtikelVerkaufen
{
    class Artikel
    {
        private string name;
        private string code;
        private int bestand;
        private double preis;

        public Artikel()
        {

        }

        public void setName(string n)
        {
            this.name = n;
        }

        public string getName()
        {

            return name;
        }

        public void setCode(string c)
        {
            this.code = c;
        }

        public string getCode()
        {

            return code;
        }

        public void setBestand(int s)
        {
            this.bestand = s;
        }

        public int getBestand()
        {

            return bestand;
        }

        public void setPreis(double p)
        {
            preis = p;
        }

        public double getPreis()
        {

            return preis;
        }

        public void kaufen(int b)
        {
            bestand += b;

        }

    }
}
