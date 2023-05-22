using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_System
{
    class Medikament
    {
        //-------------------------------
        //        Die Attribute             
        //-------------------------------

        private string haltbarkeitsdatum;
        private string name;
        private string wirksamkeit;
        private long id;

        private Medikamentenform arzneiForm;

        //--------------------------------
        // Der parametrisierte Kontruktor
        //--------------------------------
        public Medikament(string haltbarkeitsdatum, string name, string wirksamkeit, Medikamentenform formInfos)
        {
            this.haltbarkeitsdatum = haltbarkeitsdatum;
            this.name = name;
            this.wirksamkeit = wirksamkeit;
            this.arzneiForm = formInfos;
            
        }

        //-----------------------------------
        //  Die Getter- und Setter-Methoden
        //-----------------------------------
        #region Getter- - und Setter-Methoden:
        public string getHaltbarkeitsdatum()
        {
            return haltbarkeitsdatum;
        }

        public void setHalbarkeitsdatum(string haltbarkeitsdatum)
        {
            this.haltbarkeitsdatum = haltbarkeitsdatum;
        }

        public string getName()
        {
            return name;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public string getWirksamkeit()
        {
            return wirksamkeit;
        }

        public void setWirksamkeit(string wirksamkeit)
        {
            this.wirksamkeit = wirksamkeit;
        }

        public long getId()
        {
            return id;
        }

        public void setId(long id)
        {
            this.id = id;
        }
        #endregion
    }
}
