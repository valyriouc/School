namespace Akkustand;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Geben sie die gesamte Ladekapazität ein: ");
        int wattGesamt = int.Parse(Console.ReadLine());

        Console.WriteLine("Geben sie den aktuellen Ladestand ein: ");
        int wattAktuell = int.Parse(Console.ReadLine());

        double prozent = (wattAktuell * 100) / wattGesamt;

        Console.WriteLine($"Aktueller Ladestand: {prozent}%");
    }
}
