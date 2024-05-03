
internal static class Program
{
    public static void Main()
    {
        Console.WriteLine("Geben sie die Iterationsnummer ein: ");
        int n = int.Parse(Console.ReadLine());
        int summe = 0;

        for (int i = 1; i <= n; i++)
        {
            summe += i;
        }

        Console.WriteLine(summe);
    }
}