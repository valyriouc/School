using AufgabeWinter;

internal class Program
{
    private static void Main(string[] args)
    {
        Tablettenform tablette = new Tablettenform(2, 8, 3, 1508, 200);

        Medikament[] medikament = new Medikament[60];

        for (int i = 0; i <= 59; i++)
        {
            medikament[i] = new Medikament("15.08.2025", "Eucaliptum", "Zur Schmerzlinderung bei Bronchialbeschwerden", tablette);
        }

        Blister blister = new Blister(9, 9, 2015, medikament);

        blister.entnehmen(2, 4);
        blister.entnehmen(1, 1);
        blister.druckeBestandInfo();
    }
}