using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaffeemaschine
{
    class Display
    {
        private int type;

        //Zur Abhilfe/zum Testen:
        string[] ausgabe = new string[3];
        public void print(int line, string text)
        {
            ausgabe[line] = text;

            //Fineheit:
            //Solange einer der 3 Zeilen des Displays noch nicht befüllt ist (leer), wird noch nix ausgegebe:
            if(!ausgabe.Contains(null))
            {
                foreach (string zeile in ausgabe)
                {
                    Console.WriteLine(zeile);
                }
            }
        }
        public int getType()
        {
            return type;
        }

        public void clear()
        {
            for (int i = 0; i <= type +1; i++)
            {
                print(i, "");
            }
        }
    }
}
