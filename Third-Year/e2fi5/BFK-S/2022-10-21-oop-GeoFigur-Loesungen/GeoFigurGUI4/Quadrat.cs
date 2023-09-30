using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoFigurGUI4 {
    class Quadrat : Rechteck {


        /*************************/
        /* Konstruktoren         */
        /*************************/

        public Quadrat(float laenge, Brush farbe)
            : base(laenge, laenge, farbe){}
        public Quadrat(float laenge)
            : base(laenge, laenge) { } 
        public Quadrat() { }


        /*********************/
        /* Getter und Setter */
        /*********************/

        public override void Print() {
            Console.WriteLine("Quadrat(" + GetLaenge() + ")");
        }

        public override string ToString() {
            return $"Quadrat({GetLaenge()},{GetFarbe()})";
        }
    }
}