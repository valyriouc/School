using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaffeemaschine
{
    class CoffeeDispenser : Dispenser
    {
        public override void start()
        {
            muenzenwechsler.initialize();
            muenzenwechsler.getDisplay().print(0, "Muenzstand im Wechsler:");

            string zweiteZeile = "";

            foreach (Shaft shaft in muenzenwechsler.getMuenzenschaechte())
            {
                zweiteZeile += "[" + shaft.getCountCoins() +"] ";
            }
            muenzenwechsler.getDisplay().print(1, zweiteZeile);
        }

        public override bool orderProduct(float prize)
        {
            bool stand = false;
            if (muenzenwechsler.getInsertedCoinValue() == prize)
            {
                muenzenwechsler.getDisplay().print(2, "Zahlvorgang erfolgreich. Bitte entnehmen Sie Ihr Getraenk!");
                stand = true;
            }
            else if (muenzenwechsler.getInsertedCoinValue() < prize)
            {
                muenzenwechsler.getDisplay().print(2, "Wechseln ist nicht möglich, entnehmen Sie Ihre Muenzen.");
                muenzenwechsler.cancelPaymentOperation();
            }
            else
            {
                muenzenwechsler.getDisplay().print(2, "Zahlung erfolgreich. Bitte entnehmen Sie bitte das Wechselgeld und Ihr Getraenk.");
                stand = true;
            }
            return stand;
        }
    }
}
