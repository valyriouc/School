using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConverterProgramKJO
{
	class Converter
	{
		public List<Person> Personen = new List<Person>();
		public string[] ReadCSV(string Verzeichnis)
		{
			string[] str = File.ReadAllLines(Verzeichnis);
			return str;
		}

		public void AnmeldenPerson(string[] strArr)
		{
			//erste zeile der strArr ist immer der spalteName
			foreach (string strEl in strArr)
			{
				Person person = new Person();
				string[] res = strEl.Split(';');
				person.name = res[0];
				person.vorname = res[1];
				person.alt = res[2];
				Personen.Add(person);
			}
		}

		public string writeXMLNode(IEnumerable<Person> personen)
		{
			string el_1 = "<" + personen.ElementAt(0).name + ">";
			string ende_el_1 = "</" + personen.ElementAt(0).name + ">";

			string el_2 = "<" + personen.ElementAt(0).vorname + ">";
			string ende_el_2 = "</" + personen.ElementAt(0).vorname + ">";

			string el_3 = "<" + personen.ElementAt(0).alt + ">";
			string ende_el_3 = "</" + personen.ElementAt(0).alt + ">";


			string res = "<Alle>";
			for(int i = 1; i<personen.Count(); i++)
			{
				res += "<Person>";

				res += el_1;
				res += personen.ElementAt(i).name;
				res += ende_el_1;

				res += el_2;
				res += personen.ElementAt(i).vorname;
				res += ende_el_2;

				res += el_3;
				res += personen.ElementAt(i).alt;
				res += ende_el_3;

				res += "</Person>";
			}
			res += "</Alle>";
			return res;
		}
		public void MachenXMLFile(string path, string XMLNode)
		{
			File.WriteAllText(path, XMLNode);
		}
	}

	public class Person
	{
		public string name;
		public string vorname;
		public string alt;
	}
}
