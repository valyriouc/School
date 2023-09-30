using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoFigurGUI6 {
    interface IPaintable {
        void Paint(Graphics g);
        void SetX(int x);
        void SetY(int y);
        int GetX();
        int GetY();

    }
}
