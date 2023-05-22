using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe1
{
    internal class Rechteck : GeometricObject
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public Rechteck(double length, double width)
        {
            Length = length;
            Width = width;
        }

        internal override double BerechneFlaecheninhalt()
        {
            return this.Length * this.Width;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} (Length: {Length}) (Width: {Width})";
        }
    }
}
