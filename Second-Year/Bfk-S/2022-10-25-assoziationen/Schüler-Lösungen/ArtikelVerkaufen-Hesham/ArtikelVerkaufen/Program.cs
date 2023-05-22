using ArtikelVerkaufen;

string[] zeilen = File.ReadAllLines("Artikelliste.csv");

//Um zu bestimmen, welche (eindeutige/unique) VerkaeuferID wir haben in der Tabelle (ohne Verdopplung zum Beispiel):
//,damit wir die Anzahl der Verkaufer feststellen können:
HashSet<int> verkaeuferID = new HashSet<int>();

foreach (string jedeZeile in zeilen)
{
    //Entfernen der nervigen " Zeichen am Anfang und Ende jeder Zeile:
    string jedeZeileNeu = jedeZeile.TrimStart('"').TrimEnd('"');

    //Jede Zeile splitten:
    string[] spaltenEintarg = jedeZeileNeu.Split(';');

    verkaeuferID.Add(Convert.ToInt32(spaltenEintarg[0]));
}

//Somit haben wir die Anzahl der Verkaeufer festgestellt:
Verkaeufer[] verkaeufer = new Verkaeufer[verkaeuferID.Count];

//Angenommen VerkäuferID ist mit "Autoinkrement 1,2,3..." festgelegt, und ab ID = 1 anfängt:
foreach (int i in verkaeuferID)
{
    //Somit bekommt jeder Verkaeufer seine ID:
    verkaeufer[i-1] = new Verkaeufer(i);

}

//Die Anzahl der Artikel entspricht der Anzahl der Zeilen:
Artikel[] artikel = new Artikel[zeilen.Length];

//Hilfszähler für die Elemente von Artikel[]:
int z = 0;

int VerkaeuferID;

foreach (string jedeZeile in zeilen)
{
    //Jede Zeile bedeutet neues Artikel anlegen:
    artikel[z] = new Artikel();

    //Entfernen der nervigen " Zeichen am Anfang und Ende jeder Zeile:
    string jedeZeileNeu = jedeZeile.TrimStart('"').TrimEnd('"');

    //Jede Zeile splitten:
    string[] spaltenEintarg = jedeZeileNeu.Split(';');

    //Jedes Artikel wird dem entsprechenden Verkaeufer (je nach ID) hinzugefügt:
    VerkaeuferID = Convert.ToInt32(spaltenEintarg[0]);
    verkaeufer[VerkaeuferID - 1].addArtikel(artikel[z]);

    //Artikel-Attribute werden gesetzt:
    artikel[z].setName(spaltenEintarg[1]);
    artikel[z].setCode(spaltenEintarg[2]);
    artikel[z].setBestand(Convert.ToInt32(spaltenEintarg[3]));
    artikel[z].setPreis(Convert.ToInt32(spaltenEintarg[4]));

    //Es wird hochgezählt > neues Artikel:
    z++;
}

foreach(Verkaeufer V in verkaeufer)
{
    //Ausgabe der VerkäuferID (ToString() wurde überschrieben)
    Console.WriteLine(V);
    Console.WriteLine("\nSortiment:\n");

    //TODO: Rabatt() anwenden!
    //V.rabatt(200, 10);

    for(int i = 0; i < V.getSortiment().Count; i++)
    {
        Console.WriteLine("Artikel-Name: " + V.getSortiment()[i].getName());
        Console.WriteLine("Artikel-Code: " + V.getSortiment()[i].getCode());
        Console.WriteLine("Artikel-Bestand: " + V.getSortiment()[i].getBestand());
        Console.WriteLine("Artikel-Preis: " + V.getSortiment()[i].getPreis() + "\n");
    }

    Console.WriteLine("-------------------------");

}

Console.ReadKey();

