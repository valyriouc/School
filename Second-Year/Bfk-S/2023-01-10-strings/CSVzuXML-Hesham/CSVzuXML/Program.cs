using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVzuXML
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] datei = File.ReadAllLines("person.csv");

            string[] attribute = datei[0].Split(';');

            string XML = "<Alle>";

            for(int i = 1; i < datei.Length - 1; i++)
            {
                XML += "\n\t<Person>" +
                       "\n\t\t<"+ attribute[0] + ">" + datei[i].Split(';')[0] + "</" + attribute[0] + ">" +
                       "\n\t\t<"+ attribute[1] + ">" + datei[i].Split(';')[1] + "</" + attribute[1] + ">" +
                       "\n\t\t<"+ attribute[2] + ">" + datei[i].Split(';')[2] + "</" + attribute[2] + ">";
                XML += "\n\t</Person>";
            }

            XML += "\n</Alle>";

            File.WriteAllText("personXML.xml", XML);

            Console.WriteLine("Die XML-Datei erfolgreich zum Debug-Ordner exportiert");

            Console.ReadKey();

        }
    }
}
