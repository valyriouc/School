namespace TaskOOP {

    class Person {
        public string name;
        public int old;
        public double budget;
        public List<Auto> autos = new List<Auto>();

        public Person(string n, int o, double b) {
            name = n;
            old = o;
            budget = b;
        }

        public void buyAuto(Auto auto) {
            if (old < 18) {
                Console.WriteLine("You may not buy auto yourself. Please come with your father or mother. ");
            } else if(budget < auto.price) {
                Console.WriteLine("Your budget is not enough!");
            }
            else {
                budget -= auto.price;
                autos.Add(auto);
                Console.WriteLine("Successfully buyed Auto " + auto.mark + ". Your current budget now is " + budget);
            }
        }

        public void sellAuto(int position) {
            Auto auto = autos[position];
            budget += auto.price;
            autos.Remove(auto);
            Console.WriteLine("Successfully selled Auto " + auto.mark + ". Your current budget now is " + budget);
        }

        public int autosCount() {
            return autos.Count;
        }

        public void showAutos() {
            for (int i = 0; i < autos.Count; i++) {
                Console.WriteLine(autos[i]);
            }
        }
    }
}