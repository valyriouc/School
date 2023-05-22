using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaffeemaschine
{
    abstract class Dispenser
    {
        protected MC2 muenzenwechsler = new MC2();
        public abstract void start();

        public abstract bool orderProduct(float prize);
    }
}
