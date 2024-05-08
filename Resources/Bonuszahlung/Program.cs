
internal static class Program
{
    public static void Main()
    {
        int jahresgehalt = 12 * 4000;
        string[] vermittelteVertraege = ["P", "S", "S", "P", "P"];

        jahresgehalt += ErmittleBonuszulage(vermittelteVertraege);

        Console.WriteLine(jahresgehalt);
    }

    public static int ErmittleBonuszulage(string[] vermittelteVertraege)
    {
        int zuschlag = 0;

        foreach (string art in vermittelteVertraege)
        {
            if (art == "S")
            {
                zuschlag += 500;
            }
        }

        return zuschlag;
    }
}