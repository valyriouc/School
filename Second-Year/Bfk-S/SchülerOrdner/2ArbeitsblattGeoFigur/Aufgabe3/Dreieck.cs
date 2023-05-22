using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe3
{
    internal class Dreieck : GeometricObject
    {
        public double BaseSide { get; set; }
        public double Height { get; set; }

        public Dreieck(double baseSide, double height)
        {
            BaseSide = baseSide;
            Height = height;
        }

        internal override double BerechneFlaecheninhalt()
        {
            return BaseSide * Height / 2;
        }

        public override void Paint(Graphics g)
        {

        }

        public override string ToString()
        {
            return $"{GetType().Name} (BaseSide: {BaseSide}) (Height: {Height})";
        }
    }
}
