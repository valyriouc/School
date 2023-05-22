using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConverterProgramKJO
{
	class Program
	{
		//static void Main(string[] args)
		//{
		//	//schreiben Sie bitte hier einen Verzeichnis von Person.csv, wo Sie Person.csv File gespeichert haben.
		//	//z.B. "D:\Person.csv"
		//	string VerzeichnisCSV = @"Schreiben Sie hier einen Verzeichnis. bitte referenzieren Sie die obergeschribene Kommentare.";

		//	//schreiben Sie bitte hier einen Verzeichnis von Person.xml, wo Sie Person.xml File speicheren wollen.
		//	//z.B. "D:\Person.xml"
		//	string VerzeichnisXML = @"Schreiben Sie hier einen Verzeichnis. bitte referenzieren Sie die obergeschribene Kommentare.";

		//	Converter converter = new Converter();

		//	converter.AnmeldenPerson(converter.ReadCSV(VerzeichnisCSV));
		//	converter.MachenXMLFile(VerzeichnisXML, converter.writeXMLNode(converter.Personen));
		//}

		static void Main(string[] args)
		{
			//string PfadOutputOrdner = @"D:\Visual Studio 2015 Repository\Projects\ConverterProgramKJO\ConverterKJO_Output";
			//string PfadInputOrdner = @"D:\Visual Studio 2015 Repository\Projects\ConverterProgramKJO\ConverterKJO_Input";
			string PfadOutputOrdner = @"C:\Users\gogoo\source\repos\ConverterKJO_V1.2\ConverterProgramKJO\ConverterKJO_Output";
			string PfadInputOrdner = @"C:\Users\gogoo\source\repos\ConverterKJO_V1.2\ConverterProgramKJO\ConverterKJO_Input";
			
			//string FileName_Input_XML = "XML_Attributes2.xml";
			//string FileName_Input_XML = "XMl_Kommentar.xml";
			//string FileName_Input_XML = "XML_Attributes_Test.xml";
			//string FileName_Input_XML = "XML_Attributes2_Easy.xml";
			//string FileName_Input_XML = "TestXML_HardCore2.xml";
			string FileName_Input_XML = "TestXML_HardCore3.xml";

			var pfadInput = Path.Combine(PfadInputOrdner, FileName_Input_XML);
			
			Converter converter = new Converter();
			
			converter.ConvertXMLtoCSV(pfadInput, PfadOutputOrdner);
		}
	}
}
