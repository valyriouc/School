using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AufgabeWinter
{
    internal class Medikament
    {
        private String haltbarkeitsdatum;
        private String name;
        private String wirksamkeit;
        private long id;
        Medikamentenform arzneiForm;

        public Medikament(string haltbarkeitsdatum, string name, string wirksamkeit, Medikamentenform formInfos)
        {
            this.haltbarkeitsdatum = haltbarkeitsdatum;
            this.name = name;
            this.wirksamkeit = wirksamkeit;
            arzneiForm = formInfos;

        }
    }
}
