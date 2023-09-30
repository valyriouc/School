using System;
using System.Drawing;

namespace GeoFigurGUI4 {
    class Rechteck : GeoFigur {
        private float Laenge;
        private float Breite;


        /*************************/
        /* Konstruktoren         */
        /*************************/

        public Rechteck(float laenge, float breite, Brush farbe) {
            Laenge = laenge;
            Breite = breite;
            SetFarbe(farbe);
        }
        public Rechteck(float laenge, float breite) { 
            Laenge = laenge; 
            Breite = breite; 
        }
        public Rechteck(float laenge1) { 
            Laenge = laenge1; 
        }

        public Rechteck() { }

        /*********************/
        /* Getter und Setter */
        /*********************/

        public float GetLaenge() { return Laenge; }
        public void SetLaenge(float laenge) { Laenge = laenge; }
        public float GetBreite() { return Breite; }
        public void SetBreite(float breite) { Breite = breite; }


        public override float BerechneFl() { 
            float a = Laenge * Breite; 
            return a; 
        }
        public virtual void Print() {
            Console.WriteLine("Reckteck(" + Laenge + " " + Breite + ")"); 
        }

        public override string ToString() {
            return $"Rechteck({Laenge},{Breite},{GetFarbe()})";
        }

        public override void Paint(Graphics g) {
            g.FillRectangle(GetFarbe(), GetX(), GetY(), Laenge, Breite);
            
        }

    }
}
