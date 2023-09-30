namespace TaskOOP {
    class Programm {
        static void Main(string[] args) {
            Auto auto = new Auto("BMW", 2020, 60000);

            Person youngMan = new Person("Tom", 16, 1005432);

            youngMan.buyAuto(auto);

            youngMan.showAutos();

            Person poorMan = new Person("Max", 45, 234);

            poorMan.buyAuto(auto);

            poorMan.showAutos();


            Person richMan = new Person("Max", 45, 234045673);

            richMan.buyAuto(auto);

            richMan.showAutos();

            Auto newAuto = new Auto("Lexus", 1997, 10000);

            richMan.buyAuto(newAuto);

            richMan.showAutos();

            richMan.sellAuto(0);

            Console.WriteLine("after sell");

            richMan.showAutos();
        }
    }
}