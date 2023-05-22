using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe3
{
    internal class Rechteck : GeometricObject
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public Brush Colour { get; set; }

        public Rechteck() : this(0, 0, 0, 0, Brushes.Aqua) { }
        public Rechteck(double length, double width, Brush colour) :this(0, 0, length, width, colour) { }
        public Rechteck(int x, int y, double length, double width, Brush colour)
        {
            X = x;
            Y = y;
            Length = length;
            Width = width;
            Colour = colour;
        }

        internal override double BerechneFlaecheninhalt()
        {
            return Length * Width;
        }

        public override void Paint(Graphics g)
        {
            g.FillRectangle(Brushes.Khaki, new Rectangle(12, 12, Convert.ToInt32(Width), Convert.ToInt32(Length)));
        }

        public override string ToString()
        {
            return $"{GetType().Name} (Length: {Length}) (Width: {Width})";
        }
    }
}
