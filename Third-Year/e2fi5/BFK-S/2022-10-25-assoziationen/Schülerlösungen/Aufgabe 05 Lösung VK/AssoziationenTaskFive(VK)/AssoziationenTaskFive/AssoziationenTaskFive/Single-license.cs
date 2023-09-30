using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssoziationenTaskFive
{
    internal class Single_license : Article
    {
        public Single_license(int number, String designation, double price) : base(number, designation, price)
        {
        }

        public double GetPrice()
        {
            return this.price *1.1;
        }
    }
}