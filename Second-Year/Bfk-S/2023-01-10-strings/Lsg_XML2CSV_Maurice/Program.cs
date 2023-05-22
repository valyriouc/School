using System;
using System.IO;

namespace XML2CSV
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variablen
            string dateiname = "Person.xml";
            int linkeGrenze;
            int rechteGrenze;
            string tag = string.Empty;
            string tagLine = string.Empty;
            string value = string.Empty;
            string valueLines = string.Empty;


            //Einlesen der XML-Datei
            string[] zeilen = File.ReadAllLines(dateiname);

            foreach(string zeile in zeilen)
            {
                //Ermitteln des Tags
                linkeGrenze = zeile.IndexOf("<") + 1;
                rechteGrenze = zeile.IndexOf(">");

                tag = zeile.Substring(linkeGrenze, rechteGrenze - linkeGrenze);


                if(zeile.Contains($"<{tag}>") && zeile.Contains($"</{tag}>"))
                {
                    //Wenn der Tag noch nicht vorhanden ist, dann der tagLine hinzufügen
                    if (!tagLine.Contains(tag))
                    {
                        tagLine += tag + ";";
                    }

                    //Ermitteln des Values
                    linkeGrenze = zeile.IndexOf(">") + 1;
                    rechteGrenze = zeile.IndexOf("</");
                    value = zeile.Substring(linkeGrenze, rechteGrenze - linkeGrenze);

                    valueLines += value + ";";
                }


                //Wenn Datensatz zu ende, neue Line
                //Bedingung: Die eingelesene Zeile darf keinen öffnenden Tag enthalten.
                //Daher wird der schließende Tag zu einem öffnenden in der Bedinung abgewandelt,
                //und anschließend die Bedinung negiert. --> Darf nicht enthalten: <Person>
                //In den Attributzeilen onst findet er noch ein öffnendes Tag weshalb ein logisch
                //zusammengehöriger Datensatz in verschiedene Zeilen getrennt wird.
                if(!zeile.Contains($"<{tag.Replace("/", "")}>"))
                {
                    //Letztes Semikolon in der TagLine löschen
                    valueLines = valueLines.Substring(0, valueLines.Length - 1);

                    valueLines += "\n";
                }
            }

            //Letztes Semikolon in der TagLine löschen
            tagLine = tagLine.Substring(0, tagLine.Length - 1);

            //Zur Überprüfung Ausgabe in der Konsole
            Console.WriteLine(tagLine);
            Console.WriteLine(valueLines);

            //Zusammenführung von tagLine und valueLines
            string ausgabe = tagLine + "\n" + valueLines;

            //CSV-Datei schreiben
            File.WriteAllText("Person.csv", ausgabe);
            Console.WriteLine("Schreiben der CSV-Datei war erfolgreich");

            Console.ReadKey();
        }
    }
}