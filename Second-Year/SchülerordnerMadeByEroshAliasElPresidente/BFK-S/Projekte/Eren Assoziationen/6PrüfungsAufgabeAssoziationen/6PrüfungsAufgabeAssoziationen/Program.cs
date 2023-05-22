namespace _04PrüfungsAufgabeAssoziationen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Verkaeufer verkaeufer1 = new(1);
            Verkaeufer verkaeufer2 = new(2);

            Artikel artikel1 = new();
            artikel1.setName("Hosen");
            artikel1.setCode("ho");
            artikel1.setBestand(300);
            artikel1.setPreis(120);
            Artikel artikel2 = new();
            artikel1.setName("Schuhe");
            artikel1.setCode("sh");
            artikel1.setBestand(400);
            artikel1.setPreis(98);
            Artikel artikel3 = new();
            artikel1.setName("Tasche");
            artikel1.setCode("ta");
            artikel1.setBestand(500);
            artikel1.setPreis(33);
            Artikel artikel4 = new();
            artikel1.setName("Mantel");
            artikel1.setCode("ma");
            artikel1.setBestand(400);
            artikel1.setPreis(55);
            Artikel artikel5 = new();
            artikel1.setName("Socken");
            artikel1.setCode("so");
            artikel1.setBestand(200);
            artikel1.setPreis(12);

            verkaeufer1.addArticle(artikel1);
            verkaeufer1.addArticle(artikel2);
            verkaeufer1.addArticle(artikel3);
            verkaeufer1.addArticle(artikel4);
            verkaeufer1.addArticle(artikel5);


            Artikel artikel6 = new();
            artikel1.setName("Handschuhe");
            artikel1.setCode("hs");
            artikel1.setBestand(100);
            artikel1.setPreis(11);
            Artikel artikel7 = new();
            artikel1.setName("Hemd");
            artikel1.setCode("he");
            artikel1.setBestand(600);
            artikel1.setPreis(22);
            Artikel artikel8 = new();
            artikel1.setName("Jacke");
            artikel1.setCode("ja");
            artikel1.setBestand(500);
            artikel1.setPreis(122);
            Artikel artikel9 = new();
            artikel1.setName("Gürtel");
            artikel1.setCode("gu");
            artikel1.setBestand(300);
            artikel1.setPreis(32);

            verkaeufer2.addArticle(artikel6);
            verkaeufer2.addArticle(artikel7);
            verkaeufer2.addArticle(artikel8);
            verkaeufer2.addArticle(artikel9);

            Console.WriteLine(verkaeufer1.Sortiment[0].getName());
        }
    }

    internal class Verkaeufer
    {
        public int VID { get; set; }
        public List<Artikel> Sortiment = new List<Artikel>();
        //public List<Artikel> Sortiment { get; set; }
        public Verkaeufer(int vId)
        {
            VID = vId;
        }

        public double getPreis(int i)
        {
            return Sortiment[i].getPreis();
        }
        public void setPreis(int i, double p)
        {
            Sortiment[i].setPreis(p);
        }
        public void kaufen(int i, int b)
        {
            Sortiment[i].setBestand(b);
        }
        public void rabatt(int s, int d)
        {
            foreach (Artikel artikel in Sortiment)
            {
                if (artikel.getBestand() > s)
                {
                    artikel.setPreis(artikel.getPreis() / 100 * d);
                }
            }
        }
        public void erweitereSortiment(int n)
        {
            //Redundant da Liste statt Array verwendet wurde
        }
        public void addArticle(Artikel artikel)
        {
            Sortiment.Add(artikel);
        }
    }

    internal class Artikel
    {
        private string name; 
        private string code;
        private int bestand; 
        private double preis;

        public void setName(string n)
        {
            name = n;
        }
        public string getName()
        {
            return name;
        }
        public void setCode(string c)
        {
            code = c;
        }
        public string getCode()
        {
            return code;
        }
        public void setBestand(int s)
        {
            bestand = s;
        }
        public int getBestand()
        {
            return bestand;
        }
        public void setPreis(double p)
        {
            preis = p;
        }
        public double getPreis()
        {
            return preis;
        }
        public void kaufen(int b)
        {
            bestand++;
        }
    }
}