namespace _01ArbeitsblattStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Aufgabe1();
            //Aufgabe2();
            //Aufgabe3();
            //Aufgabe4();
            //Aufgabe5();
            Aufgabe6();
        }
        private static void Aufgabe1()
        {
            string input = Console.ReadLine();
            Console.WriteLine();
            for (int i = input.Length - 1; i > -1; i--)
            {
                Console.Write(input[i]);
            }
        }
        private static void Aufgabe2()
        {
            string potentialPallendrome = Console.ReadLine().Replace(" ", "").ToLower();

            char[] charArray = potentialPallendrome.ToCharArray();
            Array.Reverse(charArray);
            string reversedString = new string(charArray);
            Console.WriteLine();

            Console.WriteLine(reversedString);
            Console.WriteLine(potentialPallendrome);

            if (reversedString == potentialPallendrome)
            {
                Console.WriteLine("Given String is a Pallendrome");
            }
            else
            {
                Console.WriteLine("Given String is no Pallendrome");
            }
        }
        private static void Aufgabe3()
        {
            string input = Console.ReadLine();
            Console.WriteLine(input);

            int querSumme = 0;
            foreach (char number in input)
            {
                querSumme += Convert.ToInt32(number - '0');
            }
            Console.WriteLine(querSumme);
        }
        private static void Aufgabe4()
        {
            Console.WriteLine("Input:");
            string input = "a#bc#d";
            Console.WriteLine(input);
            Console.WriteLine();

            Console.WriteLine("Expected Output:");
            Console.WriteLine("bd");
            Console.WriteLine();
            string output = String.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] != '#')
                {
                    Console.WriteLine(input[i]);
                    output += input[i];
                }
                else if (input[i] == '#' && i >= 1)
                {
                    output = output.Remove(output.Length -1, 1);
                }
            }

            Console.WriteLine("Actual Output:");
            Console.WriteLine(output);
        }
        public static void Aufgabe5()
        {
            Console.WriteLine("Enter first Word: ");
            string word1 = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Enter Page Number: ");
            string word2 = Console.ReadLine(); ;
            int numberOfPoints = 30 - (word1.Length + word2.Length);
            string output = word1;
            for (int i = 0; i < numberOfPoints; i++)
            {
                output += '.';
            }
            output += word2;
            Console.WriteLine(output);
            Console.WriteLine(output.Length);
        }
        public static void Aufgabe6()
        {

        }
    }
}