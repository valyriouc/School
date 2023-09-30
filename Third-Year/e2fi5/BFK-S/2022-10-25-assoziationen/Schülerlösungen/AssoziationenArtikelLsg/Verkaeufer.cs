using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssoziationenArtikel {
    class Verkaeufer {
        private int VID;
        public List<Artikel> sortiment = new List<Artikel>();

        public Verkaeufer(int vid) {
            this.VID = vid;
        }

        public double getPreis(int i) {
            Artikel a = sortiment[i];
            double preis = a.getPreis();
            return preis;
        }

        public void setPreis(int i, double p) {
            Artikel a = sortiment[i];
            a.setPreis(p);
        }

        public void kaufen(int i, int b) {
            Artikel a = sortiment[i];
            a.kaufen(b);
        }

        public void rabatt(int s, int d) {
            for (int i = 0; i < sortiment.Count(); i++) {
                Artikel a = sortiment[i];
                if (a.getBestand() > s) {
                    double preisAlt = a.getPreis();
                    double preisNeu = preisAlt - preisAlt * d / 100.0;
                    a.setPreis(preisNeu);
                }
            }
        }

        public void erweitereSortiment(int n) {
            //nicht notwendig, da ArrayList unbegrenzt viele Elemente aufnimmt
        }

        public void addArtikel(Artikel artikel) {
            sortiment.Add(artikel);
        }
    }
}
