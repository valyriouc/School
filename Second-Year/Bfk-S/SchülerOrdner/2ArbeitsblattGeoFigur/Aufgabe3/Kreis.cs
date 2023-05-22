using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe3
{
    internal class Kreis : GeometricObject
    {
        public static double Pi { get; } = Math.PI;
        public double Radius { get; set; }

        public Kreis() { }
        public Kreis(double radius)
        {
            Radius = radius;
        }

        internal override double BerechneFlaecheninhalt()
        {
            return Pi * Math.Pow(Radius, 2);
        }

        public override void Paint(Graphics g)
        {

        }

        public override string ToString()
        {
            return $"{GetType().Name} (Radius: {Radius})";
        }
    }
}
