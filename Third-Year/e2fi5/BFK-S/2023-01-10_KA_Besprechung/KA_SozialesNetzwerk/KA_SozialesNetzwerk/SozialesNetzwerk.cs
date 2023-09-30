using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KA_SozialesNetzwerk
{
    class SozialesNetzwerk
    {
        private List<Person> mitgliederliste = new List<Person>();
        private List<Nachricht> nachrichtenliste = new List<Nachricht>();

 

        public void hinzufuegenMitglied(Person person)
        {
            mitgliederliste.Add(person);
        }

        public void hinzufuegenNachricht(Nachricht nachricht)
        {
            nachrichtenliste.Add(nachricht);
        }

        public String getAlleNachrichten()
        {
            String alles = "";
            foreach (Nachricht n in nachrichtenliste)
            {
                alles += n.getNachricht() + "\n";
            }
            return alles;
        }
    }
}
