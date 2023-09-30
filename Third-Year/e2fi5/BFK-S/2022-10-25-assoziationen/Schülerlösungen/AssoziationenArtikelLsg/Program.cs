using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssoziationenArtikel {
    class Program {
        static void Main(string[] args) {
            String line = "1;Hosen;ho;300;120";
            String[] daten = line.Split(';');
            for (int i = 0; i < daten.Length; i++) {
                Console.WriteLine(daten[i]);
            }

            Verkaeufer v1 = new Verkaeufer(432452344);

            Artikel a1 = new Artikel();
            a1.setName("DuschDas");
            a1.setBestand(100);
            a1.setPreis(1.99);

            Artikel a2 = new Artikel();
            a2.setName("Axe");
            a2.setBestand(500);
            a2.setPreis(2.49);

            Artikel a3 = new Artikel();
            a3.setName("Fa Soft");
            a3.setBestand(300);
            a3.setPreis(0.99);

            v1.addArtikel(a1);
            v1.addArtikel(a2);
            v1.addArtikel(a3);

            for (int i = 0; i < v1.sortiment.Count; i++) {

                Console.WriteLine("Artikel " + v1.sortiment[i].getName() +
                                   "Preis   " + v1.sortiment[i].getPreis()
                        );
            }

            v1.rabatt(200, 50);

            Console.WriteLine("\nRabatt\n");

            for (int i = 0; i < v1.sortiment.Count; i++) {

                Console.WriteLine("Artikel " + v1.sortiment[i].getName() +
                                   "Preis   " + v1.sortiment[i].getPreis()
                        );

            }
            Console.ReadKey();
        }
    }
}
