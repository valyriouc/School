using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe3
{
    internal class Quadrat : GeometricObject
    {
        public double Width { get; set; } = 0;
        public Quadrat(double width)
        {
            Width = width;
        }

        internal override double BerechneFlaecheninhalt()
        {
            return Math.Pow(Width, 2);
        }

        public override void Paint(Graphics g)
        {

        }

        public override string ToString()
        {
            return $"{GetType().Name} (Width: {Width})";
        }
    }
}
