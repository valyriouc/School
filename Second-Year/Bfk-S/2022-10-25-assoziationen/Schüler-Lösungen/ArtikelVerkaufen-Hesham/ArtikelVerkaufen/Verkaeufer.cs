using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ArtikelVerkaufen
{
    class Verkaeufer
    {
        private int VID;

        private List <Artikel> sortiment;

        public Verkaeufer (int vid)
        {
            this.VID = vid;
            this.sortiment= new List <Artikel> ();
        }

        //Extra-Methode > nützlich für die Ausgabe auf der Konsole:
        public List<Artikel> getSortiment()
        {
            return sortiment;
        }

        public double getPreis(int i)
        {
            return sortiment[i].getPreis();
        }

        public void setPreis(int i, double p)
        {
            sortiment[i].setPreis(p);
        }

        public void kaufen(int i, int b)
        {
            sortiment[i].kaufen(b);
        }

        public void rabatt(int s, int d)
        {
            //foreach ist schöner als for. LG Maurice Hofmann:
            foreach(Artikel artikel in sortiment)
            {
                if (artikel.getBestand() > s)
                {
                    double alterPreis = artikel.getPreis();
                    double neuerPreis = alterPreis * (1 - d / 100);
                    //neuerPreis = alterPreis *- d/100

                    artikel.setPreis(neuerPreis);
                }
            }

        }

        public void erweitereSortiment(int n)
        {
            //nicht notwendig
        }

        public void addArtikel(Artikel artikel)
        {
            sortiment.Add(artikel);
        }

        //Nützlich für die Ausgabe auf der Console:
        public override string ToString()
        {
            return "VerkäuferID: " + VID;
        }
    }
}
