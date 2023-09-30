using System;
using System.Collections.Generic;
using System.Text;

namespace Objektorientierung_Teil_3
{
    class Klasse_Lied
    {
        private TimeSpan songLenght;
        private string name;
        public Klasse_Lied(int hour, int min, int second, string name) {
            songLenght = new TimeSpan(hour, min, second);
            this.name = name;
        }

        public Klasse_Lied() {}
        
    }
}
