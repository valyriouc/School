namespace TaskOOP {

    class Auto {
        public string mark;
        public int year;
        public double price;

        public Auto(string m, int y, double p) {
            mark = m;
            year = y;
            price = p;
        }

        public override string ToString() {
            return mark + ":" + year.ToString() + ":" + Convert.ToString(price);
        }
    }
}