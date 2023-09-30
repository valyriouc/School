using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KA_SozialesNetzwerk
{
    class Bildnachricht : Nachricht
    {
        private String dateiname;

        public Bildnachricht()
        {

        }

        public Bildnachricht(String dateiname, Person absender):base(absender)
        {
            this.dateiname = dateiname;
        }

        public override String getNachricht()
        {
            return absender.getVorname() + " " + absender.getNachname() + ": " + dateiname + ", Zahl der Likes: "+likes;
        }
    }
}
