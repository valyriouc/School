using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KA_SozialesNetzwerk
{
    class Person
    {
        private String nachname;
        private String vorname;

        public Person()
        {

        }

        public Person(String nn, String vn)
        {
            nachname = nn;
            vorname = vn;
        }

        public String getVorname()
        {
            return vorname;
        }

        public String getNachname()
        {
            return nachname;
        }
    }
}
