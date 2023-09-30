using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_Übung
{
    class Car
    {
        public String brand;
        public int year_of_manufacture;

        public Car(String brand, int yom)
        {
            this.brand = brand;
            this.year_of_manufacture = yom;
        }
        public override string ToString()
        {
            return $"Car: {{ brand: {brand}, Year Of Manufacture: {year_of_manufacture} }}";
        }
    }
}
