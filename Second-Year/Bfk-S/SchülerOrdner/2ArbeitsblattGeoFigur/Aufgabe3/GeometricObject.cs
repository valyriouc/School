﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe3
{
    internal abstract class GeometricObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        internal abstract double BerechneFlaecheninhalt();

        public abstract void Paint(Graphics g);
    }
}
