using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_Übung
{
    class Person
    {
        public String name;
        public int age;
        public List<Car> cars = new List<Car> ();

        public Person(String name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public override string ToString()
        {
            //return $"{{ name: {name}, age: {age}, cars: {Console.WriteLine(cars.ConvertAll(c => Convert.ToString(c)))} }}"; 
            return $"{{ name: {name}, age: {age} }}";
        }

        public void buyCar(Car car)
        {
            cars.Add(car);
        }

        public void sellCar(int pos)
        {
            cars.RemoveAt(pos);
        }

        public int countCars()
        {
            return cars.Count();
        }

        public void showCars()
        {
            cars.ForEach(car => Console.WriteLine(car.ToString()));
        }
    }
}
