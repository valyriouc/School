using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KA_SozialesNetzwerk
{
    abstract class Nachricht
    {
        protected int likes;
        protected Person absender;

        public Nachricht()
        {

        }
       
        public Nachricht(Person absender)
        {
            this.absender = absender;
            likes = 0;
        }

        public void hinzufeuegenLike()
        {
            likes++;
        }

        public int getLikes()
        {
            return likes;
        }

        public abstract String getNachricht();
        
    }
}
