using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSV2XML {
    public class CSV2XML {
        static string xmlTagOpen(string name) {
            return "<" + name + ">";
        }

        static string xmlTagClose(string name) {
            return "</" + name + ">";
        }

        static string indention(int n) {
            string res = "";
            for (int i = 0; i < n; i++) {
                res = res + "   ";
            }
            return res;
        }

        public static void Main1(string[] args) {
            string file0 = "person.csv";
            string rootNodeName = "Alle";
            string file = @"..\..\" + file0;
            string[] lines = File.ReadAllLines(file);

            string xmlTagFromFilename = file0.Split('.')[0];

            string[] colNames = lines[0].Split(';');

            string xml = "";
            for (int i = 1; i < lines.Length; i++) {
                string line = lines[i];
                string[] data = line.Split(';');
                xml = xml + indention(1) + xmlTagOpen(xmlTagFromFilename) + "\n";
                for (int j = 0; j < colNames.Length; j++) {
                    xml = xml + indention(2) + xmlTagOpen(colNames[j]) + data[j] + xmlTagClose(colNames[j]) + "\n";
                }
                xml = xml + indention(1) + xmlTagClose(xmlTagFromFilename) + "\n";
            }

            xml = xmlTagOpen(rootNodeName) + "\n" + xml + xmlTagClose(rootNodeName);

            Console.WriteLine(xml);

            File.WriteAllText(file.Replace(".csv", ".xml"), xml);

            Console.ReadKey();
        }
    }
}
