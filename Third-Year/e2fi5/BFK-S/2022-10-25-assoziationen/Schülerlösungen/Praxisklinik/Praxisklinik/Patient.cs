using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praxisklinik
{
    class Patient
    {
        //--------------------------------------
        //          Die Attribute
        //--------------------------------------
        private string kvNummer;
        private string name;
        private string vorname;

        //--------------------------------------
        //          Die Konstruktoren
        //--------------------------------------
        public Patient()
        {
        }

        public Patient(string kvNummer, string name, string vorname)
        {
            this.kvNummer = kvNummer;
            this.name = name;
            this.vorname = vorname;
        }

        //--------------------------------------
        //          Die Methoden
        //--------------------------------------
        public string getKvNummer()
        {
            return kvNummer;
        }

        public string getName()
        {
            return name;
        }

        public string getVorname()
        {
            return vorname;
        }
    }
}
