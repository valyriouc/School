using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uebung_Pruefung1516
{
    class Kunde
    {
        private int kundennummer;
        private string name;
        private string strasse;
        private int plz;
        private string ort;
        
        public Kunde(int kundennummer, string name, string strasse, int plz, string ort) 
        {
            if(plz < 0 && plz > 99999)
            {
                this.plz = 99999;
            }
            else
            {
                this.plz=plz;
            }
            this.kundennummer = kundennummer;
            this.name = name;
            this.strasse = strasse;
            this.plz = plz;
            this.ort = ort;
        }

        public int getKundennummer() { return Convert.ToInt32(this.kundennummer); }

        public string getName() { return this.name; }

        public int getPlz() { return this.plz; }

        public string getOrt() { return this.ort; }

        public string getStrasse() { return this.strasse; }
    }
}
