using System;
using System.Collections.Generic;

namespace OO_Übung
{
    class Program
    {
        static void Main(string[] args)
        {
            Car taycan = new Car("Porsche", 2022);
            Car model_s = new Car("Tesla", 2020);
            Car dbs = new Car("Aston Martin", 1970);

            Person Julian = new Person("Julian", 20);
            Julian.buyCar(taycan);
            Julian.buyCar(model_s);
            Julian.buyCar(dbs);

            Console.WriteLine($"Person: {Julian.ToString()}");
            Julian.showCars();
            Console.WriteLine(Julian.countCars());
            
            //Verkaufe Aston Martin
            Julian.sellCar(2);
            Julian.showCars();
            Console.WriteLine(Julian.countCars());
        }
    }
}
