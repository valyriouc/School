using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Kaffeemaschine
{
    class MC2
    {
        private Display display;
        private List<Shaft> muenzenschaechte;

        public void initialize()
        {
            display= new Display();
            muenzenschaechte = new List<Shaft>();

            Shaft ct1 = new Shaft(1, 4);
            muenzenschaechte.Add(ct1);

            Shaft ct2 = new Shaft(2, 5);
            muenzenschaechte.Add(ct2);

            Shaft ct5 = new Shaft(5, 2);
            muenzenschaechte.Add(ct5);

            Shaft ct10 = new Shaft(10, 2);
            muenzenschaechte.Add(ct10);

            Shaft ct20 = new Shaft(20, 9);
            muenzenschaechte.Add(ct20);

            Shaft ct50 = new Shaft(50, 8);
            muenzenschaechte.Add(ct50);

            Shaft ct100 = new Shaft(100, 2);
            muenzenschaechte.Add(ct100);

            Shaft ct200 = new Shaft(200, 1);
            muenzenschaechte.Add(ct200);
        }

        public Display getDisplay()
        {
            return display;
        }

        public int countShafts()
        {
            return muenzenschaechte.Count;
        }

        public Shaft getShaft(int no)
        {
            Shaft gesuchteShaft = new Shaft();
            foreach (Shaft shaft in muenzenschaechte)
            {
                if (shaft.getCoinType() == no)
                {
                    gesuchteShaft = shaft;
                }
            }
            return gesuchteShaft;
        }

        public float getInsertedCoinValue()
        {
            float coinValue = 0;

            foreach(Shaft shaft in muenzenschaechte)
            {
                coinValue += shaft.getCoinType() * shaft.getCountCoins();
            }

            return coinValue;
        }

        public void cancelPaymentOperation()
        {
            Console.WriteLine("\nDas sind die bisher eingeworfenen Muenzen:");
            foreach (Shaft shaft in muenzenschaechte)
            {
                Console.WriteLine(shaft.getCountCoins() + " * " + shaft.getCoinType() + " Ct");
            }
            Console.WriteLine("Summe: " + getInsertedCoinValue() + " Ct");
            Console.WriteLine("\nDer Muenzenzaehler wird zurueckgesetzt");
            muenzenschaechte.Clear();
        }

        //Diese Getter-Methode wird extra benötigt in "CoffeeDispenser"
        public List<Shaft> getMuenzenschaechte()
        {
            return muenzenschaechte;
        }
    }
}
