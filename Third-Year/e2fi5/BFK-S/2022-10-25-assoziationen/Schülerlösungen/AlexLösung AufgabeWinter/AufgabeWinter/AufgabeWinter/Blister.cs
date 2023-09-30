using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AufgabeWinter
{
    internal class Blister
    {
        private int anzahlMulden;
        private int anzahlReihen;
        private int anzahlSpalten;
        private int anzahlMedikamente;
        private Boolean[,] bestandInfo;
        private long id;
        private List<Medikament> medikamente = new List<Medikament>();



        public Blister(int anzahlReihen, int anzahlSpalten, long id, Medikament[] produzierteMedikamente)
        {
            this.anzahlReihen = anzahlReihen;
            this.anzahlSpalten = anzahlSpalten;
            this.id = id;
            anzahlMulden = anzahlSpalten * anzahlReihen;
            int lauf;

            bestandInfo = new Boolean[anzahlReihen, anzahlSpalten];



            if (produzierteMedikamente.Count() > anzahlMulden)
            { lauf = anzahlMulden; }
            else { lauf = produzierteMedikamente.Count(); }

            for (int i = 0; i < lauf; i++)
            {
                medikamente.Add(produzierteMedikamente[i]);
            }

            anzahlMedikamente = medikamente.Count();

            int test = 0;
            for (int i = 0; i < anzahlReihen; i++)
            {

                for (int j = 0; j < anzahlSpalten; j++)
                {
                    test++;
                    if (test <= anzahlMedikamente)
                    {
                        bestandInfo[i, j] = true;
                    }
                    else
                    {
                        bestandInfo[i, j] = false;
                    }
                }
            }

        }

        public Boolean entnehmen(int indexReihe, int indesSpalte)
        {

            if (bestandInfo[indexReihe - 1, indesSpalte - 1] == true)
            {
                bestandInfo[indexReihe - 1, indesSpalte - 1] = false;
                medikamente.RemoveAt(1);
            }
            return bestandInfo[indexReihe - 1, indesSpalte - 1];


        }

        public void druckeBestandInfo()
        {
            for (int i = 0; i < anzahlReihen; i++)
            {
                for (int j = 0; j < anzahlSpalten; j++)
                {
                    if (bestandInfo[i, j] == true)
                    {
                        Console.Write("O");
                    }
                    else { Console.Write("X"); }
                }
                Console.WriteLine();
            }
        }
    }
}
