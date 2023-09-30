using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KA_SozialesNetzwerk
{
    class Textnachricht : Nachricht
    {
        private String nachricht;

        public Textnachricht()
        {

        }

        public Textnachricht(String nachricht, Person absender):base(absender)
        {
            this.nachricht = nachricht;
            
        }

        public override String getNachricht()
        {
            return absender.getVorname() +" "+ absender.getNachname()+": "  + nachricht + ", Zahl der Likes: "+likes;
            // oder so:
            // return $"Die Person {absender.getVorname()} {absender.getNachname()} hat auf der Nachricht '{nachricht}' {likes} Likes.";
        }
    }
}
