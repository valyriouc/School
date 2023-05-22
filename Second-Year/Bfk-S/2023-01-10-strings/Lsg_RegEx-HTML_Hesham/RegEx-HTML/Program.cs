using System;
using System.IO;
using System.Text.RegularExpressions;

namespace RegEx_HTML
{
    class Program
    {
        /*-------------------------------------------------------------------------------------------
         
                                    ▀███▀▀▀██▄                 ▀███▀▀▀███           
                                      ██   ▀██▄                  ██    ▀█           
                                      ██   ▄██   ▄▄█▀██ ▄█▀█████ ██   █  ▀██▀   ▀██▀
                                      ███████   ▄█▀   ████  ██   ██████    ▀██ ▄█▀  
                                      ██  ██▄   ██▀▀▀▀▀▀█████▀   ██   █  ▄   ███    
                                      ██   ▀██▄ ██▄    ▄█        ██     ▄█ ▄█▀ ██▄  
                                    ▄████▄ ▄███▄ ▀█████▀███████▄████████████▄   ▄██▄
                                                       █▀     ██                    
                                                       ██████▀                      
        ---------------------------------------------------------------------------------------------
        */
        static void Main(string[] args)
        {
            //------------------------------------------
            //          Die Überschriften
            //------------------------------------------

            string content = File.ReadAllText("it.schule Stuttgart.html");

            //? heißt das erste > mitnehmen!
            Regex patternHeadeing = new Regex(@"<h[1-6].*?>(.*?)</h[1-6]>");

            MatchCollection HeadingsCollection = patternHeadeing.Matches(content);

            Console.WriteLine("Anzahl der gematchten Überschriften: " + HeadingsCollection.Count + "\n");


            foreach (Match heading in HeadingsCollection)
            {
                Console.WriteLine(heading.Groups[1]);

                //Zum Testen:
                //Console.WriteLine(headings);
            }

            //------------------------------------------
            //               Die Links
            //------------------------------------------

            //Mit dem {0,1} möchten wir auch die ungesicherten Seiten (mit http) berücksichtigen:
            Regex patternLinks = new Regex(@"<a.*?href=""(https{0,1}:.*?)"".*?>.*?</a>");

            MatchCollection LinksCollection = patternLinks.Matches(content);

            Console.WriteLine("\nAnzahl der gematchten Links: " + LinksCollection.Count + "\n");

            foreach (Match Link in LinksCollection)
            {
                Console.WriteLine(Link.Groups[1]);

                //Zum Testen:
                //Console.WriteLine(Link);
            }

            //------------------------------------------
            //               Die Bilder
            //------------------------------------------

            //Vor und nach dem "|" kein Leerzeichen machen!!
            Regex patternImages = new Regex(@"<img.*?>.*?</img>|<img.*?/>");

            MatchCollection ImagesCollection = patternImages.Matches(content);

            Console.WriteLine("\nAnzahl der gematchten Bilder: " + ImagesCollection.Count + "\n");

            foreach (Match img in ImagesCollection)
            {
                Console.WriteLine(img);
            }


            //------------------------------------------
            //          Die Tabellen-Spalten  (TODO)
            //------------------------------------------
            string content2 = File.ReadAllText("table.html");

            Regex patternTable = new Regex(@"<tr.*?>(.*)</tr>");

            MatchCollection TabellenCollection = patternTable.Matches(content2);

            Console.WriteLine("\nAnzahl der Tabellenzeilen: " + TabellenCollection.Count + "\n");

            foreach (Match Zeile in TabellenCollection)
            {
                //Console.WriteLine(Zeile.Groups[1]);
                Console.WriteLine(Zeile);
            }

            Console.WriteLine("\nEs geht hier weiter...\nErstmal ein schönes Wochenende!");

            Console.ReadKey();
        }
    }
}