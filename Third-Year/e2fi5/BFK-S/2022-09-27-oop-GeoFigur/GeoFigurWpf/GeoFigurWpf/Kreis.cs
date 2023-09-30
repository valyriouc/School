using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoFigurGUI2 {
    class Kreis : GeoFigur {
        public static readonly float PI= 3.1415927f;
        private float Radius;


        /*************************/
        /* Konstruktoren         */
        /*************************/

        public Kreis(float radius1, Brush farbe) {
            Radius = radius1;
            SetFarbe(farbe);
        }
        public Kreis(float radius1) {
            Radius = radius1;
        }

        public Kreis() { }


        /*********************/
        /* Getter und Setter */
        /*********************/

        public float GetRadius() { return Radius; }
        public void SetRadius(float radius) { Radius = radius; }

        public override float BerechneFl() {
            float a = PI * Radius * Radius;
            return a;
        }
        public void Print() {
            Console.WriteLine("Kreis(" + Radius + ")");
        }
        public override string ToString() {
            return $"Kreis({Radius},{GetFarbe()})";
        }

        //public override void Paint(Graphics g) {
        //    //Form1.FillCircle(g, GetFarbe(), GetX(), GetY(), Radius);
        //    g.FillEllipse(GetFarbe(), GetX(), GetY(), Radius, Radius);
        //}
    }
}