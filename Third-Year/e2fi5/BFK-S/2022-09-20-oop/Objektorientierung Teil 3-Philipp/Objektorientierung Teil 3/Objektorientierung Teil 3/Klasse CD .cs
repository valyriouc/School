using System;
using System.Collections.Generic;
using System.Text;

namespace Objektorientierung_Teil_3
{
    class CD
    {
        public string name;
        public string Album;
        public string Erscheinungsjahr;
        public string Interpret;
        public List<Klasse_Lied> songs;

        public CD (){
        }
        public void print()
        {
            Console.WriteLine("Album____:" + Album + ":_:" + "Erscheinungsjahr____:" + Erscheinungsjahr + ":___:" + "Interpret:" + Interpret);

        }
        public void LiedTitel()
        {
            Console.WriteLine();
        }
        
    }
}
