using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe1
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
            return this.BaseSide * this.Height / 2;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} (BaseSide: {BaseSide}) (Height: {Height})";
        }
    }
}
