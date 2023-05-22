namespace _02ArbeitsauftragCSVtoXML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] csvArray = File.ReadAllLines("../../../person.csv");
            //File.Create("../../../person.xml");
            foreach (string line in csvArray)
            {
                Console.WriteLine(line);
            }

            string textToWrite = "<Alle>";
            string[] knots = csvArray[0].Split(';');
            for (int i = 1; i < csvArray.Length; i++)
            {
                textToWrite += "\n\t<Person>";
                //content
                string[] splittedLine = csvArray[i].Split(';');
                for (int j = 0; j < splittedLine.Length; j++)
                {
                    textToWrite += $"\n\t\t<{knots[j]}>{splittedLine[j]}</{knots[j]}>";
                }
                textToWrite += "\n\t</Person>";
            }
            textToWrite += "\n</Alle>";
            Console.WriteLine(textToWrite);
            File.WriteAllText("../../../person.xml", textToWrite);
        }
    }
}