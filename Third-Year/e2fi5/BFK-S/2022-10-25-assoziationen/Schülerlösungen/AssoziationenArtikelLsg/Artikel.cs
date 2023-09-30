using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssoziationenArtikel {
    class Artikel {
        private String name;
        private String code;
        private int bestand;
        private double preis;

        public Artikel() {

        }

        public void kaufen(int b) {
            bestand = bestand + b;
        }

        public String getName() {
            return name;
        }

        public void setName(String name) {
            this.name = name;
        }

        public String getCode() {
            return code;
        }

        public void setCode(String code) {
            this.code = code;
        }

        public int getBestand() {
            return bestand;
        }

        public void setBestand(int bestand) {
            this.bestand = bestand;
        }

        public void setPreis(double preis) {
            this.preis = preis;
        }

        public double getPreis() {
            return preis;
        }
    }
}
