using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace XMLzuCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            //XML-Datei-Inhalt als string einlesen:
            string FileContent = File.ReadAllText("personXML.xml");

            //Eine Liste mit den "eindeutigen" Tags der XML-Datei
            List<string> tags = new List<string>();

            //Teste auch [0-9a-zA-ZäöüßÄÖÜ]
            Regex rTag = new Regex(@"</[0-9a-zA-Z]*>");
            MatchCollection matches = rTag.Matches(FileContent);

            //Befüllen der tags-Liste mit den eindeutigen XML-Tags
            for (int i = 0; i < matches.Count; i++)
            {
                string eintrag = matches[i].Value.Replace("</", "").Replace(">", "");

                if (!tags.Contains(eintrag))
                {
                    tags.Add(eintrag);
                }
            }

            #region Test
            //--------------------------------
            //              Test1
            //--------------------------------

            //foreach (string element in tags)
            //{
            //    Console.WriteLine(element);
            //}

            //--------------------------------
            //              Test2
            //--------------------------------

            ////Regex Name
            //Regex tag0 = new Regex($@"<{tags[0]}>[0-9a-zA-Z]*</{tags[0]}>");

            //MatchCollection matches0 = tag0.Matches(FileContent);

            //for (int i = 0; i < matches0.Count; i++)
            //{
            //    Console.WriteLine(matches0[i].Value);
            //}

            ////Regex Vorname
            //Regex tag1 = new Regex($@"<{tags[1]}>[0-9a-zA-Z]*</{tags[1]}>");

            //MatchCollection matches1 = tag1.Matches(FileContent);

            //for (int i = 0; i < matches1.Count; i++)
            //{
            //    Console.WriteLine(matches1[i].Value);
            //}

            ////Regex Alter
            //Regex tag2 = new Regex($@"<{tags[2]}>[0-9a-zA-Z]*</{tags[2]}>");

            //MatchCollection matches2 = tag2.Matches(FileContent);

            //for (int i = 0; i < matches2.Count; i++)
            //{
            //    Console.WriteLine(matches2[i].Value);
            //}
            #endregion

            string output = "";

            //Eine Liste von Attributen-Listen
            //so ist das allgemeingültiger!, weil wir nicht wissen,
            //wie viele Attribute (Name, Vorname, Alter...-Listen) wir haben!
            List<List<string>> attribute = new List<List<string>>();

            //Die letzten 2 Tags (Menschen -Klasse- & Person -Objekt-) sind für uns irrelevant.
            //Deswegen tags.Count - 2
            for (int i = 0; i < tags.Count - 2; i++)
            {
                Regex newR = new Regex($@"<{tags[i]}>[0-9a-zA-Z]*</{tags[i]}>");

                MatchCollection newMatches = newR.Matches(FileContent);

                //Neue Attributen-Liste erstellen (für den i. Tag - z.B. "Namen-Liste")
                attribute.Add(new List<string>());

                //Die Attributen-Liste mit den WERTEN befüllen
                for (int j = 0; j < newMatches.Count; j++)
                {
                    //Nur den Wert zur Liste addieren ohne die Tags um herum: <Name>Schmidt</Name>
                    attribute[i].Add(newMatches[j].Value.Replace($"</{tags[i]}>", "").Replace($"<{tags[i]}>", ""));
                }
            }


            //Dies ist die erste Zeile in der CSV-Datei mit den ATTRIBUTEN
            for (int i = 0; i < tags.Count - 2; i++)
            {
                output += tags[i] + ";";
            }

            //Das letzte ; entfernen
            output = output.Substring(0, output.Length - 1);

            //Und das sind die restlichen Zeilen mit den WERTEN

            //for (int i = 0; i < attribute[0].Count; i++)
            //{
            //    output += $"\n{attribute[0][i]};{attribute[1][i]};{attribute[2][i]}";
            //}

            for (int i = 0; i < attribute[0].Count; i++)
            {
                output += "\n";

                for (int j = 0; j < attribute.Count; j++)
                {
                    output += $"{attribute[j][i]};";
                }

                //Das letzte ; entfernen
                output = output.Substring(0, output.Length - 1);
            }

            //Zur Veranschaulichung
            Console.WriteLine(output);

            //Die CSV-Datei kriegt den Namen "ObjektTag.csv"  (wäre hier Person.csv)
            File.WriteAllText(tags[tags.Count - 2] + ".csv", output);

            Console.WriteLine("\nDie CSV-Datei wurde erfolgreich in den Debug-Ordner exportiert.");

            Console.ReadKey();
        }
    }
}