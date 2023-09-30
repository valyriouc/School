using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssoziationenTaskFive
{
    internal class Volum_license : Article
    {
        private int quantity; //anzahl
        public Volum_license(int quantity, int number, String designation, double price) : base(number, designation, price)
        {
            //Wenn eine Anzahl kleiner als 10 übergeben wird, wird Anzahl auf den Wert 10 gesetzt
            if (quantity >= 10)
            {
                this.quantity = quantity;
            }
            else
            {
                this.quantity = 10;
            }
        }
        public double GetPrice()
        {
            return this.quantity * this.price * 0.9;
        }
    }
}