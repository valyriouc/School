namespace Aufgabe1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();

            #region Aufgabe1
            TestGeoFigur amina = new();
            //Console.WriteLine(amina.KombiniereFI());
            #endregion

            #region Aufgabe1.2
            
            //Console.WriteLine(r.Next(1, 100));
            //Kreis[] kreisArray100 = new Kreis[100];

            //for (int i = 0; i < kreisArray100.Length; i++)
            //{
            //    kreisArray100[i] = new Kreis(r.Next(1, 100));
            //    Console.WriteLine(kreisArray100[i].BerechneFlaecheninhalt());
            //}
            #endregion

            #region Aufgabe1.3
            //Manual Input
            //int arraySize = Convert.ToInt32(Console.ReadLine());
            //Kreis[] kreisArrayManual = new Kreis[arraySize];

            //for (int i = 0; i < kreisArrayManual.Length; i++)
            //{
            //    kreisArrayManual[i] = new Kreis(r.Next(1, 100));
            //    Console.WriteLine(kreisArrayManual[i].BerechneFlaecheninhalt());
            //}
            #endregion

            #region Aufgabe2.2
            GeometricObject[] geoArray = new GeometricObject[100];
            List<Type> types = new List<Type>();
            types.Add(typeof(Kreis));
            types.Add(typeof(Rechteck));
            types.Add(typeof(Quadrat));
            types.Add(typeof(Dreieck));
            foreach (Type type in types)
            {
                Console.WriteLine(type);
            }

            for (int i = 0; i < geoArray.Length; i++)
            {
                Console.WriteLine(types[0]);
                Console.WriteLine(types[1]);
                Console.WriteLine(types[2]);
                Console.WriteLine(types[3]);
            }
            #endregion

            #region Test
            c obj = new();
            c obj2 = new(1);
            #endregion
        }
    }
    public class a
    {
        public a() {
        Console.WriteLine($"Consturctor of Class a");
        }
        public a(int i) {
        Console.WriteLine($"Consturctor of Class a int");
        }
    }
    public class b : a
    {
        public b() {
        Console.WriteLine($"Consturctor of Class b");
        }
        public b(int i) {
        Console.WriteLine($"Consturctor of Class b int");
        }
    }
    public class c : b
    {
        public c() {
        Console.WriteLine($"Consturctor of Class c");
        }
        public c(int i) {
        Console.WriteLine($"Consturctor of Class c int");
        }
    }
}