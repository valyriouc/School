using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ERP_System
{
    class Blister
    {
        //-------------------------------
        //        Die Attribute
        //-------------------------------

        private int anzahlMulden;
        private int anzahlReihen;
        private int anzahlSpalten;
        private int anzahlMedikamente;
        private bool [,] bestandInfo;
        private long id;

        private List<Medikament> medikamente;

        //--------------------------------
        // Der parametrisierte Kontruktor
        //--------------------------------
        public Blister(int anzahlReihen, int anzahlSpalten, long id, Medikament[] produzierteMedikamente)
        {
            this.anzahlMulden = anzahlReihen * anzahlSpalten;
            this.anzahlReihen = anzahlReihen;
            this.anzahlSpalten = anzahlSpalten;            
            this.id = id;

            medikamente = new List<Medikament>();

            //Die Beschränkung durch die Anzahl der Mulden beachten!
            for (int i = 0; i < anzahlMulden; i++)
            {
                this.medikamente.Add(produzierteMedikamente[i]);
            }

            this.bestandInfo = new bool[anzahlReihen, anzahlSpalten];

            //setzen alle Werte von bestandInfo[,] auf true:
            for (int r = 0; r < anzahlReihen; r++)
            {
                for (int s = 0; s < anzahlSpalten; s++)
                {
                    bestandInfo[r,s] = true;
                }
            }

            this.anzahlMedikamente = medikamente.Count;
        }

        //Index in der Informatik is um 1 kleiner als solcher in der Realität!
        public bool entnehmen(int indexReihe, int indexSpalte)
        {
            if (bestandInfo[indexReihe - 1, indexSpalte - 1] == false)
            {
                return false;
            }
            else
            {
                //Den Platz fürs entnommene Medikament wird leer:
                bestandInfo[indexReihe - 1, indexSpalte - 1] = false;

                //Die Medikamente werden um 1 weniger:
                medikamente.RemoveAt(medikamente.Count - 1);  //Hier spielt der Index keine Rolle!
                anzahlMedikamente--;

                return true;
            }
            
        }

        public void druckeBestandInfo()
        {

            for (int r = 0; r < bestandInfo.GetLength(0); r++)
            {
                for (int s = 0; s < bestandInfo.GetLength(1); s++)
                {
                    if (bestandInfo[r, s] == true)
                    {
                        Console.Write("O ");
                    }
                    else
                    {
                        Console.Write("X ");
                    }

                }
                Console.WriteLine();
            }
        }

        //-----------------------------------
        //  Die Getter- und Setter-Methoden
        //-----------------------------------

        public int getAnzahlReihen()
        {
            return this.anzahlReihen;
        }

        public void setAnzahlReihen(int anzahlReihen)
        {
            this.anzahlReihen = anzahlReihen;
        }

        public int getAnzahlSpalten()
        {
            return this.anzahlSpalten;
        }

        public void setAnzahlSpalten(int anzahlSpaltn)
        {
            this.anzahlSpalten = anzahlSpaltn;
        }

        public long getId()
        {
            return this.id;
        }

        public void setId(long id)
        {
            this.id = id;
        }

        public bool getBestandInfo(int r, int s)
        {
            return bestandInfo[r - 1, s - 1];
        }

        public void setBestandInfo(int r, int s, bool bestandInfo)
        {
            this.bestandInfo[r - 1, s - 1] = bestandInfo;
        }
    }
}
