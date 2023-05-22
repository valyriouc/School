using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaffeemaschine
{
    class CandyDispenser : Dispenser
    {
        public override void start()
        {
        }

        public override bool orderProduct(float prize)
        {
            return false;
        }
    }
}
