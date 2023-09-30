using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoFigurGUI6 {
    class Text : IPaintable {
        string text;
        int x;
        int y;

        public Text(string text,int x, int y) {
            this.text = text;
            this.x = x;
            this.y = y;
        }

        public int GetX() {
            return x;
        }
        public int GetY() {
            return y;
        }
        public void SetX(int x) {
            this.x = x;
        }
        public void SetY(int y) {
            this.y = y;
        }

        public void Paint(Graphics g) {
            g.DrawString(text, new Font("Arial", 20), Brushes.Red, x, y);
        }
    }
}
