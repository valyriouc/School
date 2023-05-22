using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Kaffeemaschine
{
    class Program
    {
        public static float prize;
        public static void eingabe()
        {
            string eingabe = Console.ReadLine();

            //Unsere Preisliste als Dictionary:
            Dictionary<string, float> priceList = new Dictionary<string, float>();
            priceList.Add("espresso", 1024);
            priceList.Add("cappuccino", 430);
            priceList.Add("coffee", 430);
            priceList.Add("latte macchiato", 1030);

            if (priceList.ContainsKey(eingabe.ToLower()))
            {
                prize = priceList[eingabe.ToLower()];
                Console.WriteLine("Perfekt! Jetzt duerfen Sie einzahlen...");
                Thread.Sleep(2000);
                Console.WriteLine("Danke!\n");
                Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine("Falsche Eingabe! Bitte versuchen Sie es erneut:");
                Program.eingabe();
            }
        }

        static void Main(string[] args)
        {
            CoffeeDispenser coffeeDispenser = new CoffeeDispenser();

            //----------------------------------------
            //  kein Teil der Aufgabe. Nur zum Testen
            //----------------------------------------

            //Diese Preisen sind imaginaer (zwecks Testen)!
            Console.WriteLine("Bitte wählen Sie aus der Liste aus:\n\nEspresso (1024 Ct)\n" +
                "Cappuccino (430 Ct)\nCoffee (390 Ct)\nLatte Macchiato (1030 Ct)");

            eingabe();

            coffeeDispenser.start();
            //Aktuell sind 1024 Ct schon drin (zum Testen):
            coffeeDispenser.orderProduct(prize);

            Console.ReadKey();
        }
    }
}
