namespace _05puefung2016
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Kunde testKunde = new(123, "Erne", "straße", 72760, "Stuggitown");

            Einzellizenz einzel1 = new(001, "einzel1", 20.00);
            Einzellizenz einzel2 = new(002, "einzel2", 12.00);

            Volumenlizenz volumen1 = new(3, 003, "volumen1", 45.50);
            Volumenlizenz volumen2 = new(2, 004, "volumen2", 41.50);

            Rechnung testKundeRechnung = new(testKunde);
            testKundeRechnung.setArtikel(volumen1);
            testKundeRechnung.drucken();
        }
    }
    internal class Kunde
    {
        private int kundennummer;
        private string name;
        private string strasse;
        private int plz;
        private string ort;

        public Kunde(int kundennummer, string name, string strasse, int plz, string ort)
        {
            this.kundennummer = kundennummer;
            this.name = name;
            this.strasse = strasse;
            if (plz < 0 || plz > 100000)
            {
                Console.WriteLine("Der Eingabewert für die Postleitzahl befindet sich außerhalb der Erlaubten Menge.");
                Console.WriteLine("Der Standartwert von 99.999 wird übernommen.");
                Console.WriteLine();
                this.plz = 99999;
            }
            else
            {
                this.plz = plz;
            }
            this.ort = ort;
        }
        public int getKundennummer()
        {
            return kundennummer;
        }
        public string getName()
        {
            return name;
        }
        public int getPlz()
        {
            return plz;
        }
        public string getStrasse()
        {
            return strasse;
        }
        public string getOrt()
        {
            return ort;
        }
    }
    internal class Rechnung
    {
        private Kunde kunde;
        private List<Artikel> artikelliste = new List<Artikel>();
        public Rechnung(Kunde kunde)
        {
            this.kunde = kunde;
        }
        public double getGesamtbetrag()
        {
            double gesamtWert = 0;
            foreach (Artikel artikel in artikelliste)
            {
                gesamtWert += artikel.getPreis();
            }
            return gesamtWert;
        }
        public void setArtikel(Artikel artikel)
        {
            artikelliste.Add(artikel);
        }
        public void drucken()
        {
            Console.WriteLine(kunde.getKundennummer());
            Console.WriteLine(kunde.getName());
            Console.WriteLine(kunde.getPlz());
            Console.WriteLine(kunde.getStrasse());
            Console.WriteLine(kunde.getOrt());
            Console.WriteLine();
            foreach (Artikel artikel in artikelliste)
            {
            Console.WriteLine(artikel.getBezeichnung());
            }
            Console.WriteLine(getGesamtbetrag());
        }
    }
    internal abstract class Artikel
    {
        private int nummer;
        private string bezeichnung;
        protected double preis;
        public Artikel(int nummer, string bezeichnung, double preis)
        {
            this.nummer = nummer;
            this.bezeichnung = bezeichnung;
            this.preis = preis;
        }
        public int getNummer()
        {
            return nummer;
        }
        public string getBezeichnung()
        {
            return bezeichnung;
        }
        public abstract double getPreis();
    }
    internal class Einzellizenz : Artikel
    {
        public Einzellizenz(int nummer, string bezeichnung, double preis) : base (nummer, bezeichnung, preis){}
        public override double getPreis()
        {
            return preis * 1.1;
        }
    }
    internal class Volumenlizenz : Artikel
    {
        private int anzahl;
        public Volumenlizenz(int anzahl, int nummer, string bezeichnung, double preis) : base (nummer, bezeichnung, preis)
        {
            if (anzahl < 10)
            {
                this.anzahl = 10;
            }
            else
            {
            this.anzahl = anzahl;
            }
        }
        public override double getPreis()
        {
            return preis * anzahl * 0.9;
        }
    }
}