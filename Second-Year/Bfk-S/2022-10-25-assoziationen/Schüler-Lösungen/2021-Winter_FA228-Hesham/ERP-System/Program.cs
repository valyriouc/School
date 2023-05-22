using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_System
{
    class Program
    {
        static void Main(string[] args)
        {
            Tablettenform tablette = new Tablettenform(2, 8, 3, 1508, 200);

            Medikament[] produzierteMedikamente = new Medikament[60];

            for (int i = 0; i < 60; i++)
            {
                produzierteMedikamente[i] = new Medikament("15.08.2025", "Eucaliptum", "Zur Schmerzlinderung bei Bronchialbeschwerden", tablette);
                produzierteMedikamente[i].setId(3101);
            }

            Blister blister = new Blister(2, 6, 2015, produzierteMedikamente);

            blister.entnehmen(1, 1);
            blister.entnehmen(2, 5);

            blister.druckeBestandInfo();
            Console.ReadKey();
        }
    }
}
