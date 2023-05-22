using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaffeemaschine
{
    class Shaft
    {
        private int coinType;
        private int countCoins;
        public Shaft()
        {
        }

        public Shaft(int coinType, int countCoins)
        {
            this.coinType = coinType;
            this.countCoins = countCoins;
        }

        public int getCoinType()
        {
            return coinType;
        }

        public int getCountCoins()
        {
            return countCoins;
        }

        public void disCharge()
        {
            countCoins--;
        }

    }
}
