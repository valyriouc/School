using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praxisklinik
{
    class Praxis
    {
        //-----------------------------------------
        //              Die Attribute
        //-----------------------------------------
        private List<Patient> patienten = new List<Patient>();

        private List<Behandlung> behandlungen = new List<Behandlung>();

        //-----------------------------------------
        //              Die Methoden
        //-----------------------------------------
        public List<Patient> getPatient(string name)
        {
            List<Patient> gesuchtePatienten = new List<Patient>();

            foreach (var patient in patienten)
            {
                if (patient.getName() == name)
                {
                    gesuchtePatienten.Add(patient);
                }
            }
            return gesuchtePatienten;
        }

        public List<Behandlung> GetBehandlungen(string kvNummer)
        {
            List<Behandlung> gesuchteBehandlungen = new List<Behandlung>();
            foreach (var behandlung in behandlungen)
            {
                if(behandlung.getKvNummer() == kvNummer)
                {
                    gesuchteBehandlungen.Add(behandlung);
                }
            }
            return gesuchteBehandlungen;
        }

        public int anzBehandlungen(string kvNummer)
        {         
            return GetBehandlungen(kvNummer).Count;
        }

        public string zeigePatienten(int anzBehandlungen)
        {
            string ausgabe = "";

            foreach (var patient in patienten)
            {
                if (this.anzBehandlungen(patient.getKvNummer()) >= anzBehandlungen)
                {
                     ausgabe += patient.getName() + ";";
                }
            }
            return ausgabe;
        }

        public void addBehandlung(Behandlung b)
        {
            behandlungen.Add(b);
        }
        
        public double ermittleKosten()
        {
            double gesamtKosten = 0;
            foreach(var behandlung in behandlungen)
            {
                gesamtKosten += behandlung.getKosten();
            }
            return gesamtKosten;
        }

    }
}
