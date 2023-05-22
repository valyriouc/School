using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aufgabe1
{
    internal class TestGeoFigur
    {
        public double GemeinsamerFlaecheninhalt { get; set; }
        //IDK
        Kreis kreis1 = new(10);
        Kreis kreis2 = new(11);
        Dreieck dreieck1 = new(12, 13);
        Dreieck dreieck2 = new(14, 15);
        Rechteck rechteck1 = new(16, 17);
        Rechteck rechteck2 = new(17, 18);
        List<GeometricObject> list1 = new List<GeometricObject>();
        

        public double KombiniereFI()
        {
            double combinedValue = 0;

            list1.Add(kreis1);
            list1.Add(kreis2);
            list1.Add(dreieck1);
            list1.Add(dreieck2);
            list1.Add(rechteck1);
            list1.Add(rechteck2);

            foreach (GeometricObject item in list1)
            {
                combinedValue += item.BerechneFlaecheninhalt();
            }
            return combinedValue;
        }
    }
}
