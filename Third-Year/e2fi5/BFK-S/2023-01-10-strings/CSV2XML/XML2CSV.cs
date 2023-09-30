using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSV2XML {
    public class XML2CSV {
        public static void Main1(string[] args) {
            string file0 = "person.xml";
            string file = @"..\..\" + file0;
            string lines = File.ReadAllText(file);
            string linesOrig = lines;

            string tagFromFilename = file0.Replace(".xml", "");

            /*
            // rootNodeName bestimmen
            int begin0 = lines.IndexOf("<");
            int end0 = lines.IndexOf(">");
            begin0++;
            string rootNodeName1 = lines.Substring(begin0,end0-begin0);
            Console.WriteLine(rootNodeName1);
            begin0 = lines.IndexOf("<",end0+1);
            end0 = lines.IndexOf(">",end0+1);
            begin0++;
            string nodeName2 = lines.Substring(begin0, end0 - begin0);
            Console.WriteLine(nodeName2);
            */



            /*

            Console.ReadKey();
            Console.ReadKey();
            Console.ReadKey();
            Console.ReadKey();
            */

            /*
            // Tags bestimmen
            int begin = lines.IndexOf("<");
            int end = lines.IndexOf(">");
            while (begin!=-1) {
              string tagName = lines.Substring(begin+1, end - begin-1);
              Console.WriteLine(tagName);
              lines = lines.Substring(end+1);
              begin = lines.IndexOf("<");
              end = lines.IndexOf(">");
            }
            

            
            // bestimme colNames
            List<string> colNames = new List<string>();
            int begin = lines.IndexOf("<");
            int end = lines.IndexOf(">");
            while (begin != -1) {
                string tagName = lines.Substring(begin + 1, end - begin - 1);
                Console.WriteLine(tagName);
                if (!tagName.StartsWith("/") && !colNames.Contains(tagName))
                    colNames.Add(tagName);
                lines = lines.Substring(end + 1);
                begin = lines.IndexOf("<");
                end = lines.IndexOf(">");
            }
            Console.WriteLine(string.Join(" ",colNames));
            */


            string xml = "";

            // rootNodeName bestimmen
            int begin = lines.IndexOf("<");
            int end = lines.IndexOf(">");
            string rootNodeName = lines.Substring(begin + 1, end - begin - 1);
            Console.WriteLine("RootNodeName:"+rootNodeName);
            lines = lines.Substring(end + 1);

            //TagFromFilename checken
            begin = lines.IndexOf("<");
            end = lines.IndexOf(">");
            string currentTagFromFilename = lines.Substring(begin + 1, end - begin - 1);
            Console.WriteLine("CurrentTagFromFile:"+currentTagFromFilename);
            lines = lines.Substring(end + 1);


            // bestimme colNames
            List<string> colNames = new List<string>();
            begin = lines.IndexOf("<");
            end = lines.IndexOf(">");
            while (begin != -1) {
                string tagName = lines.Substring(begin + 1, end - begin - 1);
                //Console.WriteLine(tagName);
                if (!tagName.StartsWith("/") && !colNames.Contains(tagName) && tagName!=tagFromFilename)
                    colNames.Add(tagName);
                lines = lines.Substring(end + 1);
                begin = lines.IndexOf("<");
                end = lines.IndexOf(">");
            }
            Console.WriteLine("Cols:"+string.Join(" ", colNames));

            for (int i = 0; i < colNames.Count; i++) {
                xml = xml + colNames[i] + ";";
            }
            xml = xml.Substring(0,xml.Length-1) + "\n";


            /*
            //bestimme Daten
            lines = linesOrig;
            //find tagFromFilename
            string beginTag = "<" + tagFromFilename + ">";
            string endTag = "</" + tagFromFilename + ">";
            begin = lines.IndexOf(beginTag);
            end = lines.IndexOf(endTag);
            while(begin!=-1) { 
               string dataLine = lines.Substring(begin+beginTag.Length,end-begin-beginTag.Length);
               Console.WriteLine(dataLine);
               Console.WriteLine("----");
               lines = lines.Substring(end+endTag.Length);
               begin = lines.IndexOf(beginTag);
               end = lines.IndexOf(endTag);

            }
            */

            //bestimme Daten
            lines = linesOrig;
            //find tagFromFilename
            string beginTag = "<" + tagFromFilename + ">";
            string endTag = "</" + tagFromFilename + ">";
            begin = lines.IndexOf(beginTag);
            end = lines.IndexOf(endTag);
            while (begin != -1) {
                string dataLine = lines.Substring(begin + beginTag.Length, end - begin - beginTag.Length);
                Console.WriteLine(dataLine);
                for (int i = 0; i < colNames.Count; i++) {
                    string beginTag1 = "<" + colNames[i] + ">";
                    string endTag1 = "</" + colNames[i] + ">";
                    int begin1 = dataLine.IndexOf(beginTag1);
                    if (begin1 != -1) {
                    int end1 = dataLine.IndexOf(endTag1);
                    string data = dataLine.Substring(begin1+beginTag1.Length, end1-begin1-endTag1.Length+1);
                    //Console.WriteLine("***DATA:"+data);
                    xml = xml + data + ";";
                    } 
                }
                xml = xml.Substring(0, xml.Length - 2);
                xml = xml + "\n";
                Console.WriteLine("----");
                lines = lines.Substring(end + endTag.Length);
                begin = lines.IndexOf(beginTag);
                end = lines.IndexOf(endTag);

            }

            Console.WriteLine("XML:");
            Console.WriteLine(xml);

            Console.ReadKey();
        }
}
}
