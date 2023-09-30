using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assoziationen {
    
    class Auto {
        public string marke;
        public int baujahr;
        public override string ToString() {
            return $"Auto({marke},{baujahr})";
        }
    }

    class Person {
        public string name;
        public int alter;
        public Auto auto;
        public override string ToString() {
            return $"Person({name},{alter}) hatAuto: {auto}";
        }

    }

    class Program {
        static void Main(string[] args) {
            Auto a1 = new Auto();
            a1.marke = "VW";
            a1.baujahr = 2015;

            Auto a2 = new Auto();
            a2.marke = "Audi";
            a2.baujahr = 2020;

            Person p1 = new Person();
            p1.name = "Tim Schmitt";
            p1.alter = 19;

            p1.auto = a1;

            Console.WriteLine($"Auto:{a1}");
            Console.WriteLine($"Auto:{a2}");
            Console.WriteLine($"Person:{p1}");

            p1.auto = a2;
            Console.WriteLine($"Person:{p1}");

            Console.ReadKey();
        }
    }
}
