using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KA_SozialesNetzwerk
{
    class Program
    {
        static void Main(string[] args)
        {
            SozialesNetzwerk azubiVZ = new SozialesNetzwerk();
            Person peter = new Person("Lustig", "Peter");
            Person hermann = new Person("Paschulke", "Hermann");
            azubiVZ.hinzufuegenMitglied(peter);
            azubiVZ.hinzufuegenMitglied(hermann);
            Nachricht t1 = new Textnachricht("Hallo Hermann",peter);
            Nachricht t2 = new Textnachricht("Moin Peter",hermann);
            azubiVZ.hinzufuegenNachricht(t1);
            azubiVZ.hinzufuegenNachricht(t2);
            t1.hinzufeuegenLike();
            Console.WriteLine(azubiVZ.getAlleNachrichten());
            Console.ReadLine();
        }
    }
}
