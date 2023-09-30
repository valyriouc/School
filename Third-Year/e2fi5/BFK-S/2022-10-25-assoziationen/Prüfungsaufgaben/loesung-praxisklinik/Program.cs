using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praxisklinik
{
    class Program
    {
        static void Main(string[] args)
        {
            Praxis praxis = new Praxis();

            Physiobehandlung physiobehandlung1 = new Physiobehandlung("A12345", "Chirogymnastik", 12.87);
            praxis.addBehandlung(physiobehandlung1);

            Physiobehandlung physiobehandlung2 = new Physiobehandlung("A12345", "Wärmeanwendung", 4.23);
            praxis.addBehandlung(physiobehandlung2);

            Standardbehandlung standardbehandlung1 = new Standardbehandlung("A12345", "Arthrose", 45.12);
            praxis.addBehandlung(standardbehandlung1);

            Standardbehandlung standardbehandlung2 = new Standardbehandlung("A12345", "Ultraschall", 26.80);
            praxis.addBehandlung(standardbehandlung2);


            //Nicht vergessen: getKosten() bei Physiobehandlung = Kostensatz x 1.5
            //Also, nicht einfach alle Kostensätze summieren bei der Selbstkontrolle ;)
            Console.WriteLine("Die Gesamtkosten aller Behandlungen der Praxis betragen " + praxis.ermittleKosten() + " EUR");

            //----------------------------------
            //            zum Testen
            //----------------------------------
            //Patient patient = new Patient("A12345", "MUSTERMANN", "MAX");
            //praxis.patienten.Add(patient);

            //Console.WriteLine(praxis.zeigePatienten(2));
            
            Console.ReadKey();
        }
    }
}
