using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kapselungAufgabeCD
{
    class CD1
    {
        public string interpret;
        public string Album;
        public int release;
        public List<String> hitList = new List<String>();


        public void ShowContent()
        {
            Console.WriteLine("Album name: "+Album+"|| Interprete: "+interpret+"|| Erscheinungsjahr "+release);
        }
        public void AddSong(String songname)
        {
            hitList.Add(songname);
        }

        public String GetHitList()
        {
            String list="";
            for (int i=0;i< hitList.Count();i++)
            {
                list += "\n"+ hitList[i];
            }
            return list;
        }

        public int GetHitListCount()
        {
            return hitList.Count;
        }

        public String GetNameOfSong(int index)
        {
            return hitList[index];
        }
    }
}
