using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaffeeVollautomat
{
    class Kaffeevollautomat : Geraet
    {
        private int milch = 0;
        private int kaffee = 0;
        private int tassen = 0;

        public Kaffeevollautomat(string id, Nachrichtenschlange s):base(s,id)
        {

        }

        public void fuelle(int kaffee, int milch)
        {
            if (kaffee >= 0)
                this.kaffee += kaffee;
            if (milch >= 0)
                this.milch += milch;
        }


    }
}
