using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe3 {
    class Program {
        static void Main(string[] args) {
            int[] gew = { 100,0,50,500,0,30,0,500};
            for (int i = 0; i < gew.Length; i++) {
                Console.WriteLine($"Losnr:{i+1} Gewinn:{gew[i]}");
            }

            int niete = 0, gewinn=0;
            for (int i = 0; i < gew.Length; i++) {
              if(gew[i]==0) {
                    niete++;
              } else {
                    gewinn=gewinn+gew[i];
              }
            }
            Console.WriteLine($"Nieten:{niete} Gewinn insg:{gewinn}");

            //größter Wert
            int max = -1;
            for (int i = 0; i < gew.Length; i++) {
                if (gew[i] > max) max = gew[i];
            }

            Console.WriteLine("Max2:"+gew.Max()); 

            foreach(int losWert in gew) {
                Console.WriteLine("Loswert:"+losWert);
            }

            // Listen, keine feste Größe notwendig
            List<int> liste = new List<int>();
            liste.Add(1);
            liste.Add(2);
            liste.Add(4);
            for (int i = 0; i < liste.Count; i++) {
                Console.WriteLine(liste[i]);
            }
            


                Console.ReadKey();
        }
    }
}
