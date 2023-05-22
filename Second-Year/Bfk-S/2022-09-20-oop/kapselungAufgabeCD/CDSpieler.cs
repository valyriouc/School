using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kapselungAufgabeCD
{
    class CDSpieler
    {        static void Main(string[] args)
        {
            CD1 BMTH = new CD1();
            BMTH.interpret = "Bring me the Horizon";
            BMTH.Album = "amo";
            BMTH.release = 2019;
            BMTH.AddSong("i apologise if you feel somthing");
            BMTH.AddSong("MANTRA");
            BMTH.AddSong("in the dark");
            BMTH.AddSong("mother tongue");
            BMTH.AddSong("nihilist blues");
            Console.WriteLine("Anzahl an liedern: "+BMTH.GetHitListCount());
            Console.WriteLine("HitList: "+BMTH.GetHitList());
            Console.WriteLine(BMTH.GetNameOfSong(2));

            Console.ReadKey();
        }
    }
}
