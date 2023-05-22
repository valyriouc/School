using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lizenzen
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
            this.kundennummer = kundennummer;
            this.name = name;
            this.strasse = strasse;
            if (plz > 0 && plz < 100000)
            {
                this.plz = plz;
            }
            else
            {
                this.plz = 99999;
            }
            
            this.ort = ort;
        }

        public int getKundennummer(string Kundenname)
        {
            return this.kundennummer;
        }

        public string getName()
        {
            return this.name;
        }

        public int getPlz()
        {
            return this.plz;
        }

        public string getOrt()
        {
            return this.ort;
        }

        public string getStrasse()
        {
            return this.strasse;
        } 

    }
}
