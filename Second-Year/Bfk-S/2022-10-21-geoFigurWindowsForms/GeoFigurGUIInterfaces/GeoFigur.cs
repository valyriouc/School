using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoFigurGUI6 {
    
    abstract class GeoFigur : IPaintable {
        private Brush Farbe;
        private int X, Y;

        public Brush GetFarbe() { return Farbe; }
        public void SetFarbe(Brush farbe) { Farbe=farbe; }
        public int GetX() { return X; }
        public void SetX(int x) { X=x; }
        public int GetY() { return Y; }
        public void SetY(int y) { Y = y; }

        public abstract float BerechneFl();
        public abstract void Paint(Graphics g);
    }
}
