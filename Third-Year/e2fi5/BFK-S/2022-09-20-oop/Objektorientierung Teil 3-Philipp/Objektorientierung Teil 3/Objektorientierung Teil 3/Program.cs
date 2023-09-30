using System;
using System.Collections.Generic;

namespace Objektorientierung_Teil_3
{
    class Program
    {
        
        static void Main(string[] args)
        {
            CD c1 = new CD();

            c1.Interpret = "Imagine Dragones";
            c1.name = "Album1";
            c1.Album = "Night Vision";
            c1.Erscheinungsjahr = "2011";
            c1.print();
            c1.LiedTitel();

            List<Klasse_Lied> songs = new List<Klasse_Lied>();
            Klasse_Lied song = new Klasse_Lied(0, 3, 42, "Radioaktiv");
            songs.Add(song);
            song = new Klasse_Lied(0, 3, 42, "Radioaktiv");
            songs.Add(song);
            c1.songs = songs;



        }
    }
}
