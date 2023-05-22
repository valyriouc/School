using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConverterProgramKJO
{
	public class Converter
	{
		public void ConvertXMLtoCSV(string VerzeichnisXML, string VerzeichnisOrdner)
		{
			//---------------------------Lesen-------------------------------------------
			//Lesen XML File -> return Type : IEnummerable<string>
			string[] RohXMLStr = ReadXML(VerzeichnisXML);

			//---------------------------Verarbeiten mit der XML zeile-------------------
			//Machen einen Zeil String von der IEnummerabale<string> -> return Type : string
			string EinZeilString = MakeAStringFromStrArr(RohXMLStr);
			//löschen "\n", "\t" in dem string Zeil. -> returng Type : string
			EinZeilString = LoeschenAlleAbsatzmarke(EinZeilString);
			//löschen  alen stringTeile, die mit "<!--" beginnt und "-->" schlusst, in dem string Zeil. -> returng Type : string
			EinZeilString = LoeschenAlleKommentar(EinZeilString);
			//---------------------------Bilden Node Baum mit der XML Knoten--------------
			//Planzen mit der verarbeitete string einen NodeBaum!
			Node nodeTree = PflanzenNodeBaum(EinZeilString);

			//---------------------------Auswählen einen Them(zum Beispiel "Person")------------
			//ZeigenAllenMoeglichenThemUndEinenAuswaehlen(nodeTree)
			string choosedNodeTreeTitel = ZeigenAllenMoeglichenTitelUndEinenAuswaehlen(nodeTree);
			string NameDesAusgewaehleteThem = ZeigenAllenMoeglichenThemUndEinenAuswaehlen(nodeTree, choosedNodeTreeTitel);
			//---------------------------Schreiben CSV File 
			WriteCSV(VerzeichnisOrdner, nodeTree, NameDesAusgewaehleteThem, choosedNodeTreeTitel);
			//1. Nennen File_Name von CSV File mit "ausgewählteter Them"
			//2. Schreiben Einen Kompleten Verzeichnis Fügen nach dem hintere "genohmendeVerzeichnisOrdner" den "ausgewählteter Them" + ".csv"(Erster Parameter in File.WriteAllText(path,TXT)
			//3. Sammeln allen Node,der den title_Node(gleich mit "ausgewählteter Them") hat,in dem NodeBaum.
			//4. Schreiben einen Text für CSV(zweiter Parameter in File.WriteAllText(path,TXT))
			//5. Rufen File.WriteAllText(Verzeichnis,Text) auf.
		}
		private string ZeigenAllenMoeglichenTitelUndEinenAuswaehlen(Node nodeTree)
		{
			//1. lesen den Node Baum und geben allen mogliche Themen.
			List<string> AlleMoeglicheTitel = GebenAllenMoeglichenTitel(nodeTree);

			//2. sortieren diesen Themen.
			AlleMoeglicheTitel = AlleMoeglicheTitel.Distinct().ToList();

			//3. zeigen allen Themen und auswählen einen Them(benutzer. mit console write & switch case)
			string NameDesAusgewaehleteTitel = AuswaehlenEinenTitel(AlleMoeglicheTitel);

			//4. geben "ausgewählteter Them" zurück. -> return "ausgewählteter Them" 
			return NameDesAusgewaehleteTitel;
		}
		private List<string> GebenAllenMoeglichenTitel(Node node)
		{
			List<string> einPlatzFürMoeglichenTitel = new List<string>();
			einPlatzFürMoeglichenTitel = Rekl_GebenAllenMoeglichenTitel(node, einPlatzFürMoeglichenTitel);
			return einPlatzFürMoeglichenTitel;
		}
		private List<string> Rekl_GebenAllenMoeglichenTitel(Node node, List<string> PlatzFürMoeglichenTitel)
		{
			//lesen den Node Baum und sortieren allen mogliche Themen.


			//wenn 'node' minds einen enkelNode hat, rufen Reklusive Funktion
			if (node.info.AnzahlKinderUndInhalts.anzahlDerKinderNode > 0)
			{
				foreach (Node childNode in node.ChildNodes)
				{
					if (childNode.info.AnzahlKinderUndInhalts.anzahlDerKinderNode > 0)
					{
						//fügen den Title_node auf moeglicheThenenList hinzu.
						PlatzFürMoeglichenTitel.Add(node.info.title_Node);
					}
					//arbeiten weiter mit den ChildNodes..
					foreach (Node ChildNode in node.ChildNodes)
					{
						PlatzFürMoeglichenTitel = Rekl_GebenAllenMoeglichenTitel(ChildNode, PlatzFürMoeglichenTitel);
					}
				}
			}
			return PlatzFürMoeglichenTitel;
		}
		private string AuswaehlenEinenTitel(List<string> AlleMoeglicheTitel)
		{
			string NameDesAusgewaehleteTitel = string.Empty;

			//zeigen allen Themen auf CONSOLE
			Console.WriteLine("Mit welchen Titel möchten Sie Einen File Machen?\n");
			for (int i = 0; i < AlleMoeglicheTitel.Count; i++)
			{
				Console.WriteLine(i + "." + AlleMoeglicheTitel[i].ToString() + "\n");
			}
			//Wählen einen Nummer aus auf CONSOLE.
			Console.WriteLine("Bitte Hier Einen Nummer : ");
			int ausgewaehlteteNummer = int.Parse(Console.ReadLine());
			Console.WriteLine("\n");
			//Finden der Them was benutzer ausgewählt.
			//index ist immer 1 weniger. 
			NameDesAusgewaehleteTitel = AlleMoeglicheTitel[ausgewaehlteteNummer].ToString();

			//Console.Clear();
			//Gebe der Them zurück.
			return NameDesAusgewaehleteTitel;
		}
		private string ZeigenAllenMoeglichenThemUndEinenAuswaehlen(Node nodeTree, string choosedNodeTreeTitel)
		{
			Node choosedNodeTree = TakeAllChoosedNodeBranch(nodeTree, choosedNodeTreeTitel)[0];
			//1. lesen den Node Baum und geben allen mogliche Themen.
			List<string> AlleMoeglicheThemen = GebenAllenMoeglichenThemen(choosedNodeTree);
			//2. sortieren diesen Themen.
			AlleMoeglicheThemen = AlleMoeglicheThemen.Distinct().ToList();
			//3. zeigen allen Themen und auswählen einen Them(benutzer. mit console write & switch case)
			string NameDesAusgewaehleteThem = AuswaehlenEinenThem(AlleMoeglicheThemen);
			//4. geben "ausgewählteter Them" zurück. -> return "ausgewählteter Them" 
			return NameDesAusgewaehleteThem;
		}
		private List<Node> TakeAllChoosedNodeBranch(Node NodeTree, string choosedNodeTreeTitel)
		{
			List<Node> ChoosedBranches = new List<Node>();
			ChoosedBranches = Rekl_TakeAllChoosedNodeBranch(NodeTree, choosedNodeTreeTitel, ChoosedBranches);
			return ChoosedBranches;
		}
		private List<Node> Rekl_TakeAllChoosedNodeBranch(Node NodeTree, string choosedNodeTreeTitel, List<Node> ChoosedBranches)
		{
			if (NodeTree.info.title_Node == choosedNodeTreeTitel)
			{
				ChoosedBranches.Add(NodeTree);
			}

			else if (NodeTree.info.AnzahlKinderUndInhalts.anzahlDerKinderNode > 0)
			{
				foreach (Node childNode in NodeTree.ChildNodes)
				{
					ChoosedBranches = Rekl_TakeAllChoosedNodeBranch(childNode, choosedNodeTreeTitel, ChoosedBranches);
				}
			}
			return ChoosedBranches;
		}
		private List<string> GebenAllenMoeglichenThemen(Node node)
		{
			List<string> einPlatzFürMoeglichenThemen = new List<string>();
			einPlatzFürMoeglichenThemen = Rekl_GebenAllenMoeglichenThemen(node, einPlatzFürMoeglichenThemen);
			return einPlatzFürMoeglichenThemen;
		}
		private List<string> Rekl_GebenAllenMoeglichenThemen(Node node, List<string> PlatzMoeglichenThemen)
		{
			//wenn 'node' minds. einen ChildNode hat, rufen Reklusive Funktion
			if (node.info.AnzahlKinderUndInhalts.anzahlDerKinderNode > 0)
			{
				foreach (Node childNode in node.ChildNodes)
				{
					if (childNode.info.AnzahlKinderUndInhalts.anzahlDerKinderNode == 0)
					{
						//fügen den Title_node auf moeglicheThenenList hinzu.
						PlatzMoeglichenThemen.Add(node.info.title_Node);
					}
				}
				//arbeiten weiter mit den ChildNodes..
				foreach (Node ChildNode in node.ChildNodes)
				{
					PlatzMoeglichenThemen = Rekl_GebenAllenMoeglichenThemen(ChildNode, PlatzMoeglichenThemen);
				}
			}
			return PlatzMoeglichenThemen;
		}
		//zeigen allen Themen und auswählen einen Them
		private string AuswaehlenEinenThem(List<string> AlleMoeglicheThemen)
		{
			string NameDesAusgewaehleteThem = string.Empty;
			Console.WriteLine("Üder welchen Them möchten Sie Einen File Machen?\n");
			//zeigen allen Themen auf CONSOLE
			for (int i = 0; i < AlleMoeglicheThemen.Count; i++)
			{
				Console.WriteLine(i + "." + AlleMoeglicheThemen[i].ToString() + "\n");
			}
			Console.WriteLine("Bitte Hier Einen Nummer : ");
			//Wählen einen Nummer aus auf CONSOLE.

			int ausgewaehlteteNummer_Them = int.Parse(Console.ReadLine());
			//Finden der Them was benutzer ausgewählt.
			//index ist immer 1 weniger. 
			NameDesAusgewaehleteThem = AlleMoeglicheThemen[ausgewaehlteteNummer_Them].ToString();

			//Gebe der Them zurück.
			return NameDesAusgewaehleteThem;
		}

		private string[] ReadCSV(string VerzeichnisLesen)
		{
			string[] str = File.ReadAllLines(VerzeichnisLesen);
			return str;
		}
		private string[] ReadXML(string VerzeichnisLesen)
		{
			string[] str = File.ReadAllLines(VerzeichnisLesen);
			return str;
		}

		////이건 희망사항이고...
		//public void WriteCSV(string VerzeichnisSchreiben, Node nodeTree)
		//{
		//	//1.노드트리를 읽는다.

		//	//2. 모든 노드를 보여준다.(중복되지 않도록)

		//	//3. 노드중 한개를 선택하고, 선택된 노드의 이름을 가지고 해당 노드를 전부 기록하는 보조 쓰기 함수에 파라메터로 넣어 호출한다.
		//}

		//1. Nennen File_Name von CSV File mit "ausgewählteter Them"
		//2. Schreiben Einen Kompleten Verzeichnis Fügen nach dem hintere "genohmendeVerzeichnisOrdner" den "ausgewählteter Them" + ".csv"(Erster Parameter in File.WriteAllText(path,TXT)
		//3. Sammeln allen Node,der den title_Node(gleich mit "ausgewählteter Them") hat,in dem NodeBaum.

		private void WriteCSV(string VerzeichnisOrdener, Node nodeTree, string choosedThema, string choosedNodeTreeTitle)
		{
			//1,2. Schreiben Einen Kompleten Verzeichnis Fügen nach dem hintere "genohmendeVerzeichnisOrdner" den "ausgewählteter Them" + ".csv"(Erster Parameter in File.WriteAllText(path,TXT)
			string OutputFileName = MachenOutputFileName(choosedThema, choosedNodeTreeTitle, "csv");
			var KompleteZielPfad = Path.Combine(VerzeichnisOrdener, OutputFileName);

			//3.Schreiben einen Text für CSV(zweiter Parameter in File.WriteAllText(path,TXT))
			string eineZeileTXTCSV = MakeTemporaryEineZeilForCSVFromNodeBaum(nodeTree, choosedThema, choosedNodeTreeTitle);

			//4.Machen einen file
			File.WriteAllText(KompleteZielPfad, eineZeileTXTCSV);
		}
		private string MachenOutputFileName(string choosedThema, string choosedNodeTreeTitle, string OutputFileType)
		{
			return choosedNodeTreeTitle + "_" + choosedThema + "_" + DateTime.Now.ToString("yyyy-MM-dd_HH;mm;ss") + "." + OutputFileType;
		}
		private string MakeTemporaryEineZeilForCSVFromNodeBaum(Node nodeTree, string choosedThema, string choosedNodeTreeTitle)
		{

			//falls Ziel_title_node 'Person' ist,
			//die spaltenCSV sind Name,Vorname,Alter.

			//Sammeln allen Node,der den title_Node(gleich mit "ausgewählteter Them") hat,in dem NodeBaum.
			//die ChildNode der Von Ausgewählteter Them node werden die Spalten der CSV gewesen.
			List<string> PlatzFuerSpaltenCSV = new List<string>();
			PlatzFuerSpaltenCSV = SammelnAllenTitle_ChildNodes(nodeTree, PlatzFuerSpaltenCSV, choosedThema, choosedNodeTreeTitle);
			//sortiertende SpaltenCSV
			List<string> sortierteteSpaltenCSV = PlatzFuerSpaltenCSV.Distinct().ToList();
			//SpaltenCSV[0] = "ersteSpalte;zweiteSpalte;dreiteSpalte;..." 
			//SpaltenCSV[1] = "ersteSpalte;zweiteSpalte;dreiteSpalte;..." ...usw
			//Dies schneidet erneut um das Semikolon herum und rekonstruiert ohne Duplizierung.
			List<string> vollstaedigListSpaltenCSV = rekonstruiertDenSpaltenOhneDuplizierung(sortierteteSpaltenCSV);

			//--------------Schreiben einen Inhalt für CSV-----------
			//모은 자식노드들의 타이틀을 spalte로서 맨위에 쓰고
			List<string> tempStrCSV = new List<string>();
			//schreiben der erste Zeil von Temporary string list->Spalten.
			List<string> tempStrCsvMitErsteZeil = SchreibenTxtForCsvNurErsteZeil_Spalten(vollstaedigListSpaltenCSV, tempStrCSV);
			//fuegen von Zweite bis letzte Zeil hinzu => Contentes.
			List<string> VollstaedigtempStrCSV = SchreibenTxtForCsvAlleNachZweiteZeil_Contents(nodeTree, tempStrCsvMitErsteZeil, choosedThema, choosedNodeTreeTitle, vollstaedigListSpaltenCSV);
			//List<string> VollstaedigtempStrCSV = SchreibenTxtForCsvAlleNachZweiteZeil(nodeTree, tempStrCsvMitErsteZeil, choosedThema, SpaltenCSV?);

			//Verketten Sie die vorbereitete tempStrCSV zu einer einzelnen Zeichenfolge.
			string aStringLineFuerCSV = MakeAStringFromStrArr(VollstaedigtempStrCSV);

			//geben der TXTFuerCSV zurück
			return aStringLineFuerCSV;
		}
		private List<string> SammelnAllenTitle_ChildNodes(Node node, List<string> platzFuerAllenSpalten, string choosedThema, string choosedNodeTreeTitle)
		{
			//if (node.info.AnzahlKinderUndInhalts.anzahlDerKinderNode > 0)
			//{
			//	foreach (Node childNode in node.ChildNodes)
			//	{
			//		//schulerinnenOderSchuler
			if (node.info.title_Node == choosedNodeTreeTitle)
			{
				if (node.info.AnzahlKinderUndInhalts.anzahlDerKinderNode > 0)
				{
					foreach (Node childNode in node.ChildNodes)
					{
						if (childNode.info.title_Node == choosedThema)
						{
							string eineZeil = string.Empty;
							foreach (Node enkelNode in childNode.ChildNodes)
							{
								//spalten
								eineZeil += enkelNode.info.title_Node;
								eineZeil += ";";
							}
							platzFuerAllenSpalten.Add(eineZeil);
						}
					}
				}
			}
			//뭔가 꺼림직한 느낌이 든다.. 추후에 다시 생각해봐야할듯.
			if (node.info.AnzahlKinderUndInhalts.anzahlDerKinderNode > 0)
			{
				foreach (Node childNode in node.ChildNodes)
				{
					SammelnAllenTitle_ChildNodes(childNode, platzFuerAllenSpalten, choosedThema, choosedNodeTreeTitle);
				}
			}
			return platzFuerAllenSpalten;
		}
		private List<string> SchreibenTxtForCsvNurErsteZeil_Spalten(List<string> spaltenCSV, List<string> tempStrCSV)
		{
			string ersteZeil = string.Empty;
			foreach (string NameDesSpalte in spaltenCSV)
			{
				ersteZeil += NameDesSpalte + ";";
			}
			ersteZeil += "\n";
			tempStrCSV.Add(ersteZeil);
			return tempStrCSV;
		}
		private List<string> SchreibenTxtForCsvAlleNachZweiteZeil_Contents(Node nodeTree, List<string> tempStrCSV, string choosedThema, string choosedNodeTreeTitle, List<string> SpaltenCSV)
		{
			//z.B choosedThema is SchulerinnenUndSchuler,
			if (nodeTree.info.title_Node == choosedNodeTreeTitle)
			{
				//prevention "OutOfRangeException"
				if (nodeTree.info.AnzahlKinderUndInhalts.anzahlDerKinderNode > 0)
				{

					//sehen alle ChildNode des 'SchulerinnenUndSchuler' Nodes.
					foreach (Node childNode in nodeTree.ChildNodes)
					{
						string weitereZeile = string.Empty;
						if (childNode.info.title_Node == choosedThema)
						{
							//weitereZeile += childNode.info.element_Node;
							foreach (Node onkelNode in childNode.ChildNodes)
							{
								for (int j = 0; j < SpaltenCSV.Count; j++)
								{
									if (onkelNode.info.title_Node == SpaltenCSV[j])
									{
										weitereZeile += onkelNode.info.element_Node;
										weitereZeile += ";";
									}
								}
							}
							weitereZeile += '\n';
						}
						tempStrCSV.Add(weitereZeile);
					}
				}
			}
			foreach (Node childNode in nodeTree.ChildNodes)
			{
				if (childNode.info.AnzahlKinderUndInhalts.anzahlDerKinderNode > 0)
				{
					SchreibenTxtForCsvAlleNachZweiteZeil_Contents(childNode, tempStrCSV, choosedThema, choosedNodeTreeTitle, SpaltenCSV);
				}
			}
			return tempStrCSV;
		}
		private string MakeAStringFromStrArr(IEnumerable<string> strArr)
		{
			string res = string.Empty;
			foreach (string str in strArr)
			{
				res += str;
			}
			return res;
		}
		private List<string> rekonstruiertDenSpaltenOhneDuplizierung(List<string> sortierteteSpaltenCSV)
		{
			List<string> res = new List<string>();
			foreach (string Spalten_Kette in sortierteteSpaltenCSV)
			{
				string[] einzelSpalten = Spalten_Kette.Split(';');
				for (int i = 0; i < einzelSpalten.Length - 1; i++)
				{
					res.Add(einzelSpalten[i]);
				}
			}
			return res;
		}
		private string LoeschenAlleKommentar(string input)
		{
			string arbeitStr = input;
			bool gibtEsMehrKommentar = true;

			while (gibtEsMehrKommentar)
			{
				//wenn arbeitStr minds. ein Kommentar gehoeren
				if (arbeitStr.IndexOf("<!--") != -1)
				{
					int indexAnfangKommentar0 = arbeitStr.IndexOf("<!--");
					for (int i = indexAnfangKommentar0; i < arbeitStr.Length - indexAnfangKommentar0 - 1; i++)
					{
						if (i == arbeitStr.IndexOf("-->"))
						{
							int indexEndeKommentar0 = i;
							int LengthKommentar0 = indexEndeKommentar0 - indexAnfangKommentar0 + 3;
							string kommentar0 = arbeitStr.Substring(indexAnfangKommentar0, LengthKommentar0);
							arbeitStr = arbeitStr.Replace(kommentar0, "");
							break;
						}
					}
				}
				else gibtEsMehrKommentar = false;
			}
			return arbeitStr;
		}
		private string LoeschenAlleAbsatzmarke(string input)
		{
			input = input.Replace("\n", "");
			input = input.Replace("\t", "");
			return input;
		}
		//*****Funktionsweise***** NodeBaumPlanzen()
		//<Parent>
		//	<Child_1>                      |von hier
		//		<Onkel_1>...</Onkel_1>      |                                                    |von hier
		//		<Onkel_2>...</Onkel_2>      |                                                    |bis hier ist der teil1
		//	</Child_1>                     |
		//	<Child_2>                      |
		//		<Onkel_3>...</Onkel_3>      |                                                    |von hier
		//		<Onkel_4>...</Onkel_4>      |                                                    |bis hier ist der teil2
		//	</Child_2>                     |bis hier ist "Ganze_Satz_der_inhalt_der_string_1".
		//</Parent>
		//
		//1. machen einen Node "node_1" mit Konstruktor der Class Node.
		//2. nehmen den Title"Parent" in der Erste Klammer "<Parent>" und schreiben den Title auf indeNodeTitle.
		//3. wenn es keins "<" oder ">" und nur string gibt, einfach speichern den string als "node_1.NodeInhalt".
		//4. wenn es mindestens ein "<" oder ">" gibt, aufrufen NodeBaumPlanzen(inhalt_der_string).
		//5. Geben "node_1" zurück. 

		private Node PflanzenNodeBaum(string gelesendeneXMLstr)
		{
			//Build NodeTree from Root to all of branches.
			Node TheNode = new Node();

			//2. all of Nodes have "info : InfoOfNode" 
			TheNode.info = Test_AusfuellenInfoOfNode(gelesendeneXMLstr);

			//3. When this Node have contents,
			//prevent NullReferenzeAusnahme
			if (TheNode.info.AnzahlKinderUndInhalts != null)
			{
				// check there is Child in that contents
				//prevent OutOfRangeAusnahme
				if (TheNode.info.AnzahlKinderUndInhalts.anzahlDerKinderNode > 0)
				{
					//wenn Ja, fügen den Kinder hinzu.
					for (int i = 0; i < TheNode.info.AnzahlKinderUndInhalts.schnideteInhalts.Count; i++)
					{
						//Fügen ChildNode. Dafür benutzen wir "rekursive Funktion".(weil ChildNode auch ihre KindNode haben können.)
						//TheNode.ChildNodes.Add(NodeBaumPlanzen(TheNode.info.stringEtwasZwischenNode));
						TheNode.ChildNodes.Add(PflanzenNodeBaum(TheNode.info.AnzahlKinderUndInhalts.schnideteInhalts[i]));
					}
				}
			}
			//5. Geben "TheNode" zurück. 
			return TheNode;
		}


		//private InfoOfNode AusfuellenInfoOfNode(string StringEinNodeDerXML)
		//{
		//	InfoOfNode infoOfNode = new InfoOfNode();

		//	//아마도 처음 받아온 스트링에 노드는 딱 한개여야겠지? <Alle>...</Alle>처럼 말이지.
		//	//받아온 스트링을 처음부터 끝까지 보면서 일하는거지.
		//	//과제는 노드의 시작부분괄호와 끝부분괄호의 위치를 찾는거야.
		//	for (int index = 0; index < StringEinNodeDerXML.Length; index++)
		//	{
		//		//만약에 노드시작을 의미하는 '<'를 만나면
		//		if (StringEinNodeDerXML[index] == '<')
		//		{
		//			//판단할 수 있겠지? 지금 보고있는 스트링에는 적어도 한개의 노드가 있다는것을
		//			infoOfNode.gibtEsNeueNodeInGeradeArbeitendeString = true;

		//			infoOfNode.index_Vor_AnfangNode = index;
		//			//StringGeradeArbeit[index+1]이 바로 '>'이어서는 안된다.
		//			if (StringEinNodeDerXML[index + 1] == '>') { Console.WriteLine("Falsche XML File."); break; }
		//			else
		//			{
		//				for (int index_2 = index + 2; index_2 < StringEinNodeDerXML.Length - index - 2; index_2++)
		//				{
		//					if (StringEinNodeDerXML[index_2] == '>')
		//					{
		//						infoOfNode.index_Hinter_AnfangNode = index_2;
		//						break;
		//					}
		//				}
		//				break;
		//			}
		//		}
		//	}
		//	//지금 일하고 있는 스트링에 새로운 노드가 있다면 작업을 하면돼. 사실 이 조건문이 없어도 상관없지만
		//	//런타임중에 반복문이 시간을 낭비하는것을 방지하고자 이 조건문을 넣은거야
		//	if (infoOfNode.gibtEsNeueNodeInGeradeArbeitendeString)
		//	{
		//		//일단 노드의 이름을 저장하고,
		//		infoOfNode.title_Node = StringEinNodeDerXML.Substring(infoOfNode.index_Vor_AnfangNode + 1, infoOfNode.index_Hinter_AnfangNode - 1);
		//		//그 노드의 이름을 가지고 
		//		//<aa>aa</aa> -> for(int index = 3+1;index<11-1;
		//		for (int index = infoOfNode.index_Hinter_AnfangNode + 1; index < StringEinNodeDerXML.Length - 1; index++)
		//		{
		//			//정확히 </infoOfNode.title_Node>이 나오는곳을 찾으면,
		//			//ex) <aa>aa</aa>, index = 6
		//			//6, 7, substring(8,2), 
		//			string strGerade = string.Empty;
		//			strGerade += StringEinNodeDerXML[index];
		//			strGerade += StringEinNodeDerXML[index + 1];
		//			strGerade += StringEinNodeDerXML.Substring(index + 2, infoOfNode.title_Node.Length);
		//			strGerade += StringEinNodeDerXML[index + infoOfNode.title_Node.Length + 2];
		//			string strZiel = "</" + infoOfNode.title_Node + ">";
		//			if (strGerade == strZiel)
		//			{
		//				//그 위치를 저장하고,
		//				infoOfNode.index_Vor_EndeNode = index;
		//				//</aaaa> 0+4+2 = 6 으로 예상하는데 이 계산은 착오가 있을수 있겠다는 생각이 든다.
		//				infoOfNode.index_Hinter_EndeNode = index + infoOfNode.title_Node.Length + 2;
		//				//뒤에 같은 이름을 가진 쌍둥이자식이 있을 경우 똑같이 생긴 종료문자열이 있을 수 있으므로 일단 종료하기위해 break.
		//				break;
		//			}
		//		}
		//	}
		//	//노드 사이에 뭔가 있는지를 확인하는 과정이다.
		//	//뭔가가 있다면 이것을 infoOfNode.stringEtwasZwischenNode에 저장하는 부분이지.
		//	//<aa></aa>처럼 노드 사이에 아무것도 없는 경우 4-3 = 1 이므로 이렇게 계산한 값이 1보다 크다면 노드 사이에 뭔가가 있다고 판단
		//	if (infoOfNode.index_Vor_EndeNode - infoOfNode.index_Hinter_AnfangNode > 1)
		//	{
		//		infoOfNode.gibtEsEtwasZwischenNode = true;
		//		//Length_stringEtwasZwischenNode =  infoOfNode.index_Vor_EndeNode - infoOfNode.index_Hinter_AnfangNode - 1; ex) <aa>abcd</aa> -> length = 8-3-1 = 4.
		//		//<aa>abcd</aa> -> infoOfNode.index_Hinter_AnfangNode = 3, infoOfNode.index_Vor_EndeNode = 8 -> stringEtwasZwischenNode = Substring( 4, 4)
		//		int Length_stringEtwasZwischenNode = infoOfNode.index_Vor_EndeNode - infoOfNode.index_Hinter_AnfangNode - 1;
		//		infoOfNode.stringEtwasZwischenNode = StringEinNodeDerXML.Substring(infoOfNode.index_Hinter_AnfangNode + 1, Length_stringEtwasZwischenNode);
		//	}

		//	//zahlen wie viel kinder habe ich.
		//	//지금부터 봐야하는 스트링부분이다.

		//	//만약에 노드사이에 뭔가 있다면
		//	if (infoOfNode.gibtEsEtwasZwischenNode == true)
		//	{
		//		string stringEtwasZwischen = infoOfNode.stringEtwasZwischenNode;
		//		//그 뭔가에 자식이 포함되어있는지 확인한다.
		//		infoOfNode.AnzahlKinderUndInhalts = ZaehlenWieVielKinderUndInhaltsVonKinder(stringEtwasZwischen);
		//		//뭔가 있는데 자식이 없다? 그게 빈공간이 아니다? 그럼 뭐다?
		//		if (infoOfNode.AnzahlKinderUndInhalts.anzahlDerKinderNode == 0)
		//		{
		//			//그 뭔가는 해당노드의 원소로 판단
		//			infoOfNode.element_Node = infoOfNode.stringEtwasZwischenNode;
		//			//그럼 여기서 혹시 그 판단 infoOfNode.gibtEsEtwasZwischenNode을 false로 바꿔야하나?
		//		}
		//	}
		//	//	//한 노드 덩어리를 찾는 부분이 캡슐화 될 수 있겠다.

		//	//	//찾아낸 이름에 대한 노드가 끝나는 곳."</title_Child_node>"까지를 하나로 세면 된다. while(gibtEsMehreEtwas)를 사용.
		//	//	//찾아낸 이름에 대한 노드가 끝나는 곳 뒤에 또다른 노드가 그 내용물(부모노드 사이의 무언가)의 끝인것으로 판명되면
		//	//	//gibtEsMehreKinder를 false로 바꾸어서 탈출.
		//	//	//그 위치의 뒤에 같은 이름의 자식이 있는지 확인.

		//	//	//뒤에 나오는 이름이 다른 경우, 이름이 다른 자식으로 간주.
		//	//	//즉 자식은 쌍둥이 일수도 혹은 쌍둥이가 아닐수도 있다.
		//	//	//다시 말해 Alle 는 Person이라는 쌍둥이 자식을 가지지만,
		//	//	//Person은 Name,Vorname,Alter라는 각각다른 자식을 가질 수 도 있다.

		//	//	//부모가 있고, 그의 자식이 또다른 자식을 가질수 있기에
		//	//	//이것이 구현되기 위해서는 부모는 자신의 자식에대해서만 알아야하는 것이다.
		//	//	//즉 부모는 자신의 자녀가 자식(손자)를 낳았는지 여부를 결코 알아서는 안된다는 뜻이다.

		//	return infoOfNode;
		//}
		private InfoOfNode Test_AusfuellenInfoOfNode(string StringEinNodeDerXML)
		{
			//int indexEndeStringEinNodeDerXML = StringEinNodeDerXML.Length - 1;
			InfoOfNode infoOfNode = new InfoOfNode();

			//아마도 처음 받아온 스트링에 노드는 딱 한개여야겠지? <Alle>...</Alle>처럼 말이지.
			//받아온 스트링을 처음부터 끝까지 보면서 일하는거지.
			//과제는 노드의 시작부분괄호와 끝부분괄호의 위치를 찾는거야.

			if (StringEinNodeDerXML.IndexOf('<') != -1)
			{
				infoOfNode.gibtEsNeueNodeInGeradeArbeitendeString = true;
				infoOfNode.index_Vor_AnfangNodeKlammer = StringEinNodeDerXML.IndexOf('<');
				infoOfNode.index_Hinter_AnfangNodeKlammer = StringEinNodeDerXML.IndexOf('>');
			}
			//지금 일하고 있는 스트링에 새로운 노드가 있다면 작업을 하면돼. 사실 이 조건문이 없어도 상관없지만
			//런타임중에 반복문이 시간을 낭비하는것을 방지하고자 이 조건문을 넣은거야
			if (infoOfNode.gibtEsNeueNodeInGeradeArbeitendeString)
			{
				//일단 노드의 이름을 저장하고,
				//<abcde>
				//0123456
				//LengthInhaltDesKlammers : 5
				//infoOfNode.index_Hinter_AnfangNode : 6
				//infoOfNode.index_Vor_AnfangNode :0
				int LengthInhaltDesKlammers = infoOfNode.index_Hinter_AnfangNodeKlammer - infoOfNode.index_Vor_AnfangNodeKlammer - 1;
				string inhaltDesKlammers = StringEinNodeDerXML.Substring(infoOfNode.index_Vor_AnfangNodeKlammer + 1, LengthInhaltDesKlammers);
				TitleOfNodeAndAttruibutes titleOfNodeAndAttruibutes = SpeichernNodeTitelUndAttribute(inhaltDesKlammers);
				infoOfNode.title_Node = titleOfNodeAndAttruibutes.TitleOfNode;
				infoOfNode.Attributes = titleOfNodeAndAttruibutes.attributes;

				string ZielEndeNode = "</" + infoOfNode.title_Node + ">";
				for (int i = infoOfNode.index_Hinter_AnfangNodeKlammer + 1; i < StringEinNodeDerXML.Length; i++)
				{
					//2글자씩 확인한다.
					string tempEndeNodeKlammer = StringEinNodeDerXML[i].ToString() + StringEinNodeDerXML[i + 1].ToString();
					if (tempEndeNodeKlammer == "</")
					{
						string tempEndeNode = StringEinNodeDerXML.Substring(i);
						tempEndeNode = StringEinNodeDerXML.Substring(i, tempEndeNode.IndexOf(">") + 1);

						string tempEndeNode_vergleich = LoeschenAllenLeerZeichenInString(tempEndeNode);
						if (tempEndeNode_vergleich == ZielEndeNode)
						{
							infoOfNode.index_Vor_EndeNode = i + 2;
							infoOfNode.index_Vor_EndeNodeKlammer = i;
							infoOfNode.index_Hinter_EndeNode = tempEndeNode.IndexOf(">") + i - 1;
							infoOfNode.index_Hinter_EndeNodeKlammer = tempEndeNode.IndexOf(">") + i;
							break;
						}
					}
				}
			}
			//노드 사이에 뭔가 있는지를 확인하는 과정이다.
			//뭔가가 있다면 이것을 infoOfNode.stringEtwasZwischenNode에 저장하는 부분이지.
			//<aa></aa>처럼 노드 사이에 아무것도 없는 경우 4-3 = 1 이므로 이렇게 계산한 값이 1보다 크다면 노드 사이에 뭔가가 있다고 판단
			if (infoOfNode.index_Vor_EndeNodeKlammer - infoOfNode.index_Hinter_AnfangNodeKlammer > 1)
			{
				infoOfNode.gibtEsEtwasZwischenNode = true;
				//Length_stringEtwasZwischenNode =  infoOfNode.index_Vor_EndeNode - infoOfNode.index_Hinter_AnfangNode - 1; ex) <aa>abcd</aa> -> length = 8-3-1 = 4.
				//<aa>abcd</aa> -> infoOfNode.index_Hinter_AnfangNode = 3, infoOfNode.index_Vor_EndeNode = 8 -> stringEtwasZwischenNode = Substring( 4, 4)
				int Length_stringEtwasZwischenNode = infoOfNode.index_Vor_EndeNodeKlammer - infoOfNode.index_Hinter_AnfangNodeKlammer - 1;
				infoOfNode.stringEtwasZwischenNode = StringEinNodeDerXML.Substring(infoOfNode.index_Hinter_AnfangNodeKlammer + 1, Length_stringEtwasZwischenNode);
			}

			//zahlen wie viel kinder habe ich.
			//지금부터 봐야하는 스트링부분이다.

			//만약에 노드사이에 뭔가 있다면
			if (infoOfNode.gibtEsEtwasZwischenNode == true)
			{
				string stringEtwasZwischen = infoOfNode.stringEtwasZwischenNode;
				//그 뭔가에 자식이 포함되어있는지 확인한다.
				infoOfNode.AnzahlKinderUndInhalts = ZaehlenWieVielKinderUndInhaltsVonKinder(stringEtwasZwischen);
				//뭔가 있는데 자식이 없다? 그게 빈공간이 아니다? 그럼 뭐다?
				if (infoOfNode.AnzahlKinderUndInhalts.anzahlDerKinderNode == 0)
				{
					//그 뭔가는 해당노드의 원소로 판단
					infoOfNode.element_Node = LoeschenAllenLeerZeichenInString(infoOfNode.stringEtwasZwischenNode);
					//그럼 여기서 혹시 그 판단 infoOfNode.gibtEsEtwasZwischenNode을 false로 바꿔야하나?
				}
			}
			//	//한 노드 덩어리를 찾는 부분이 캡슐화 될 수 있겠다.

			//	//찾아낸 이름에 대한 노드가 끝나는 곳."</title_Child_node>"까지를 하나로 세면 된다. while(gibtEsMehreEtwas)를 사용.
			//	//찾아낸 이름에 대한 노드가 끝나는 곳 뒤에 또다른 노드가 그 내용물(부모노드 사이의 무언가)의 끝인것으로 판명되면
			//	//gibtEsMehreKinder를 false로 바꾸어서 탈출.
			//	//그 위치의 뒤에 같은 이름의 자식이 있는지 확인.

			//	//뒤에 나오는 이름이 다른 경우, 이름이 다른 자식으로 간주.
			//	//즉 자식은 쌍둥이 일수도 혹은 쌍둥이가 아닐수도 있다.
			//	//다시 말해 Alle 는 Person이라는 쌍둥이 자식을 가지지만,
			//	//Person은 Name,Vorname,Alter라는 각각다른 자식을 가질 수 도 있다.

			//	//부모가 있고, 그의 자식이 또다른 자식을 가질수 있기에
			//	//이것이 구현되기 위해서는 부모는 자신의 자식에대해서만 알아야하는 것이다.
			//	//즉 부모는 자신의 자녀가 자식(손자)를 낳았는지 여부를 결코 알아서는 안된다는 뜻이다.

			return infoOfNode;
		}
		private TitleOfNodeAndAttruibutes SpeichernNodeTitelUndAttribute(string inhaltDesKlammers)
		{
			TitleOfNodeAndAttruibutes titleOfNodeAndAttruibutes = new TitleOfNodeAndAttruibutes();
			int indexAnfangNodeTitle = 0;
			int indexEndeNodeTitle = 0;
			bool gibtEsAttribute = false;
			for (int i = 0; i < inhaltDesKlammers.Length; i++)
			{
				if (inhaltDesKlammers[i] != ' ')
				{
					indexAnfangNodeTitle = i;
					break;
				}
			}
			//<inhaltDesKlammers>
			//inhaltDesKlammers = "  Node_Titel Attr1 = "aa" Attr2 = "bb" "
			for (int i = indexAnfangNodeTitle; i < inhaltDesKlammers.Length; i++)
			{
				//빈칸을 만나면 
				if (inhaltDesKlammers[i] == ' ')
				{
					indexEndeNodeTitle = i - 1;
					if (string.IsNullOrWhiteSpace(inhaltDesKlammers.Substring(i))) { gibtEsAttribute = false; }
					else gibtEsAttribute = true;
					break;
				}
				else
				{
					if (i == inhaltDesKlammers.Length - 1)
					{
						indexEndeNodeTitle = i;
						break;
					}
				}
			}

			//Node_Titel ....
			//^        ^
			//indexAnfangNodeTitle = 0, N
			//indexEndeNodeTitle = 9, l
			//Length_Titel = indexEndeNodeTitle - indexAnfangNodeTitle + 1 = 9 - 0 + 1 = 10
			int LengthTitle = indexEndeNodeTitle - indexAnfangNodeTitle + 1;
			string tempTitle = inhaltDesKlammers.Substring(indexAnfangNodeTitle, LengthTitle);
			//빈칸 없에고 타이틀로 저장.
			titleOfNodeAndAttruibutes.TitleOfNode = LoeschenAllenLeerZeichenInString(tempTitle);
			//노드 제목이 끝나는 곳의 바로 다음칸이 >일 경우는 값 반환.
			//그렇지 않은 경우 
			if (indexEndeNodeTitle + 1 < inhaltDesKlammers.Length)
			{
				inhaltDesKlammers = inhaltDesKlammers.Substring(indexEndeNodeTitle + 1);
				//prevent NullReferenzAusnahme.
				if (!String.IsNullOrWhiteSpace(inhaltDesKlammers))
				{
					titleOfNodeAndAttruibutes.attributes = ArbeitFuerAttribute(inhaltDesKlammers);
				}
			}
			return titleOfNodeAndAttruibutes;
		}
		private List<Attribute> ArbeitFuerAttribute(string hinternStringZwischenKlammer)
		{
			List<Attribute> PlatzAttributes = new List<Attribute>();
			PlatzAttributes = Rekl_ArbeitFuerAttribute(hinternStringZwischenKlammer, PlatzAttributes);
			return PlatzAttributes;
		}
		private List<Attribute> Rekl_ArbeitFuerAttribute(string hinternStringZwischenKlammer, List<Attribute> PlatzAttributes)
		{
			//잘라서 키 채우고 ->Add()
			int indexAnfangAttrKey = 0;
			int indexEndeAttrKey = 0;
			int indexGleichheitszeichen = 0;
			Attribute attr = new Attribute();

			for (int i = 0; i < hinternStringZwischenKlammer.Length; i++)
			{
				if (hinternStringZwischenKlammer[i] != ' ')
				{
					indexAnfangAttrKey = i;
					break;
				}
			}
			//<inhaltDesKlammers>
			//inhaltDesKlammers = "  Node_Titel Attr1 = "aa" Attr2 = "bb" "
			for (int i = indexAnfangAttrKey; i < hinternStringZwischenKlammer.Length; i++)
			{
				if (hinternStringZwischenKlammer[i] == '=')
				{
					indexGleichheitszeichen = i;
					indexEndeAttrKey = i - 1;
					break;
				}
			}
			int LengthAttrKey = indexEndeAttrKey - indexAnfangAttrKey + 1;
			string attrKey = hinternStringZwischenKlammer.Substring(indexAnfangAttrKey, LengthAttrKey);
			attrKey = LoeschenAllenLeerZeichenInString(attrKey);

			attr.SetKey(attrKey);

			//indexEndeAttrKey 
			//밸류 채우고
			//inhaltDesKlammers = "  Node_Titel Attr1 = "aa" Attr2 = "bb" "
			//                                       ^
			//                               indexEndeAttrKey
			int indexAnfangAttrValue = 0;
			int indexEndeAttrValue = 0;
			int indexDoppelte_Anführungszeichen_Vor = 0;
			int indexDoppelte_Anführungszeichen_Hintern = 0;
			for (int i = indexGleichheitszeichen + 1; i < hinternStringZwischenKlammer.Length; i++)
			{
				if (hinternStringZwischenKlammer[i] == '"')
				{
					indexDoppelte_Anführungszeichen_Vor = i;
					indexAnfangAttrValue = i + 1;
					break;
				}
			}
			//<inhaltDesKlammers>
			//inhaltDesKlammers = "  Node_Titel Attr1 = "aa" Attr2 = "bb" "
			//                                          ^
			//                                indexAnfangAttrValue
			for (int i = indexAnfangAttrValue; i < hinternStringZwischenKlammer.Length; i++)
			{
				if (hinternStringZwischenKlammer[i] == '"')
				{
					indexDoppelte_Anführungszeichen_Hintern = i;
					indexEndeAttrValue = i - 1;
					break;
				}
			}
			int LengthAttrValue = indexEndeAttrValue - indexAnfangAttrValue + 1;
			attr.SetValue(hinternStringZwischenKlammer.Substring(indexAnfangAttrValue, LengthAttrValue));
			//어트리뷰트 리스트에 키 밸류 추가하고.
			PlatzAttributes.Add(attr);
			//뒤에 뭐가 남아있을 경우에. 예외방지
			if (hinternStringZwischenKlammer.Length > indexDoppelte_Anführungszeichen_Hintern)
			{
				//남은 스트링은 다시 받아서
				hinternStringZwischenKlammer = hinternStringZwischenKlammer.Substring(indexDoppelte_Anführungszeichen_Hintern + 1);
				//받은 스트링이 눌이 아니면
				//재귀
				if (!String.IsNullOrWhiteSpace(hinternStringZwischenKlammer))
				{
					PlatzAttributes = Rekl_ArbeitFuerAttribute(hinternStringZwischenKlammer, PlatzAttributes);
				}
			}
			return PlatzAttributes;
		}
		private string LoeschenAllenLeerZeichenInString(string input)
		{
			bool EsGibtLeerZeichen = true;
			string output = input;
			while (EsGibtLeerZeichen)
			{
				//wenn input minds. einen Leerzeichen hat..
				if (output.IndexOf(' ') != -1)
				{
					output = output.Remove(output.IndexOf(' '),1);
				}
				//wenn input keinen mehre Leerzeichen hat, ESCAPE!
				else
				{
					EsGibtLeerZeichen = false;
				}
			}
			return output;
		}
		private AnzahlDerKinderUndSchnideteInhaltList ZaehlenWieVielKinderUndInhaltsVonKinder(string StringGeradeArbeit)
		{
			AnzahlDerKinderUndSchnideteInhaltList anzahlDerKinderUndSchnideteInhaltList = new AnzahlDerKinderUndSchnideteInhaltList();

			int index_Vor_AnfangChildNodeKlammer = 0;
			int index_Hinter_AnfangChildNodeKlammer = 0;
			//int index_Vor_AnfangChildNode = 0;
			//int index_Hinter_AnfangChildNode = 0;

			int index_Vor_EndeChildNodeKlammer = 0;
			int index_Hinter_EndeChildNodeKlammer = 0;
			int index_Vor_EndeChildNode = 0;
			int index_Hinter_EndeChildNode = 0;

			bool GibtEsLeerRaum = true;
			while (GibtEsLeerRaum)
			{
				if (StringGeradeArbeit[0] == ' ')
				{
					StringGeradeArbeit = StringGeradeArbeit.Substring(1, StringGeradeArbeit.Length - 1);
				}
				else
				{
					//비어있지 않으므로 탈출 후 작업 시작.
					GibtEsLeerRaum = false;
				}
			}
			
			bool gibtEsMehreEtwas = true;
			while (gibtEsMehreEtwas)
			{
				if (StringGeradeArbeit.IndexOf("<") != -1)
				{
					index_Vor_AnfangChildNodeKlammer = StringGeradeArbeit.IndexOf("<");
					index_Hinter_AnfangChildNodeKlammer = StringGeradeArbeit.IndexOf(">");
					int LengthInhaltZwischenChildNodeKlammers = index_Hinter_AnfangChildNodeKlammer - index_Vor_AnfangChildNodeKlammer - 1;
					string InhaltZwischenChildNodeKlammers = StringGeradeArbeit.Substring(index_Vor_AnfangChildNodeKlammer+1, LengthInhaltZwischenChildNodeKlammers);



					TitleOfNodeAndAttruibutes titleOfNodeAndAttruibutes = new TitleOfNodeAndAttruibutes();
					titleOfNodeAndAttruibutes = SpeichernNodeTitelUndAttribute(InhaltZwischenChildNodeKlammers);

					string ZielEndeChildNode = "</" + titleOfNodeAndAttruibutes.TitleOfNode + ">";
					for (int i = index_Hinter_AnfangChildNodeKlammer + 1; i < StringGeradeArbeit.Length; i++)
					{
						//ueberpruefen kontinuierliche zwei char, ob das ist gleich mit "</"
						string tempEndeChildNodeKlammer = StringGeradeArbeit[i].ToString() + StringGeradeArbeit[i + 1].ToString();
						if (tempEndeChildNodeKlammer == "</")
						{
							string tempEndeNode = StringGeradeArbeit.Substring(i);
							tempEndeNode = StringGeradeArbeit.Substring(i, tempEndeNode.IndexOf(">") + 1);

							string tempEndeNode_vergleich = LoeschenAllenLeerZeichenInString(tempEndeNode);
							if (tempEndeNode_vergleich == ZielEndeChildNode)
							{
								index_Vor_EndeChildNode = i + 2;
								index_Vor_EndeChildNodeKlammer = i;
								index_Hinter_EndeChildNode = tempEndeNode.IndexOf(">") + i - 1;
								index_Hinter_EndeChildNodeKlammer = tempEndeNode.IndexOf(">") + i;
								
								anzahlDerKinderUndSchnideteInhaltList.anzahlDerKinderNode++;
								anzahlDerKinderUndSchnideteInhaltList.schnideteInhalts.Add(StringGeradeArbeit.Substring(index_Vor_AnfangChildNodeKlammer, index_Hinter_EndeChildNodeKlammer - index_Vor_AnfangChildNodeKlammer + 1));
								break;
							}
						}
					}
				}
				if(StringGeradeArbeit.Length-index_Hinter_EndeChildNodeKlammer-1>0)
				{
					StringGeradeArbeit = StringGeradeArbeit.Substring(index_Hinter_EndeChildNodeKlammer + 1);
					if (string.IsNullOrWhiteSpace(StringGeradeArbeit))
					{
						//while escape
						gibtEsMehreEtwas = false;
					}
				}
				else
				{
					gibtEsMehreEtwas = false;
				}
			}
			return anzahlDerKinderUndSchnideteInhaltList;
		}
		private AnzahlDerKinderUndSchnideteInhaltList alte(string StringGeradeArbeit)
		{
			AnzahlDerKinderUndSchnideteInhaltList anzahlDerKinderUndSchnideteInhaltList = new AnzahlDerKinderUndSchnideteInhaltList();
			int anzahlDerKinder = 0;

			bool gibtEsMehreEtwas = true;
			while (gibtEsMehreEtwas)
			{
				//준비물들
				int index_Vor_AnfangChildNodeKlammer = 0;
				int index_Hinter_AnfangChildNodeKlammer = 0;
				int index_Vor_AnfangChildNode = 0;
				int index_Hinter_AnfangChildNode = 0;


				int index_Vor_EndeChildNodeKlammer = 0;
				int index_Hinter_EndeChildNodeKlammer = 0;
				int index_Vor_EndeChildNode = 0;
				int index_Hinter_EndeChildNode = 0;

				string title_Child_node = string.Empty;

				//일을 시작하기에 앞서 비어있는 공간 제거.
				bool GibtEsLeerRaum = true;
				while (GibtEsLeerRaum)
				{
					if (StringGeradeArbeit[0] == ' ')
					{
						StringGeradeArbeit = StringGeradeArbeit.Substring(1, StringGeradeArbeit.Length - 1);
					}
					else
					{
						//비어있지 않으므로 탈출 후 작업 시작.
						GibtEsLeerRaum = false;
					}
				}


				//받아온 일거리를 차근히 봅시다.
				for (int index = 0; index < StringGeradeArbeit.Length; index++)
				{
					//노드가 시작되는 부분을 찾았다면 일단 저장하고 나서, 
					if (StringGeradeArbeit[index] == '<')
					{
						index_Vor_AnfangChildNodeKlammer = index;
						//뒤에 이어지는 문자가 바로 '>'가 아니라는 것을 확인한뒤.
						if (StringGeradeArbeit[index + 1] == '>') { Console.WriteLine("Falsche XML File."); break; }
						else
						{
							//노드의 이름이 최소한 한글자라는 것을 가정하고 2칸 뒤부터 계속 검색한다.
							for (int index_2 = index + 2; index_2 < StringGeradeArbeit.Length - index - 2; index_2++)
							{
								if (StringGeradeArbeit[index_2] == '>')
								{
									index_Hinter_AnfangChildNodeKlammer = index_2;
									break;
								}
							}
							break;
						}
					}
				}
				//만약 괄호를 찾았다면 그것은 자녀 노드가 있다는 뜻이고,
				if (index_Hinter_AnfangChildNodeKlammer > 0)
				{
					//일단 찾은 괄호의 위치를 이용해 노드의 이름을 얻고,
					title_Child_node = StringGeradeArbeit.Substring(index_Vor_AnfangChildNodeKlammer + 1, index_Hinter_AnfangChildNodeKlammer - 1);
					//뒤에 반드시 있어야할 닫히는 괄호를 찾는다.
					string ZielEndeNode = "</" + title_Child_node + ">";
					for (int i = index_Hinter_AnfangChildNodeKlammer + 1; i < StringGeradeArbeit.Length; i++)
					{
						//2글자씩 확인한다.
						string tempEndeNodeKlammer = StringGeradeArbeit[i].ToString() + StringGeradeArbeit[i + 1].ToString();
						if (tempEndeNodeKlammer == "</")
						{
							string tempEndeNode = StringGeradeArbeit.Substring(i);
							tempEndeNode = StringGeradeArbeit.Substring(i, tempEndeNode.IndexOf(">") + 1);

							string tempEndeNode_vergleich = LoeschenAllenLeerZeichenInString(tempEndeNode);
							if (tempEndeNode_vergleich == ZielEndeNode)
							{
								index_Vor_EndeChildNode = i + 2;
								index_Vor_EndeChildNodeKlammer = i;
								index_Hinter_EndeChildNode = tempEndeNode.IndexOf(">") + i - 1;
								index_Hinter_EndeChildNodeKlammer = tempEndeNode.IndexOf(">") + i;
								break;
							}
						}
					}
					if (index_Hinter_EndeChildNodeKlammer - index_Vor_AnfangChildNodeKlammer > 5)
					{
						//childNode한개를 확인했으므로 자식노드 한개 추가.
						anzahlDerKinder++;
						//아울러 문자열의 첫번째 부분이 뭔지도 확인했다.
						//<ab>a</ab> -> 9 - 0 + 1 = length 10 
						int LengthDerTeil = index_Hinter_EndeChildNodeKlammer - index_Vor_AnfangChildNodeKlammer + 1;
						anzahlDerKinderUndSchnideteInhaltList.schnideteInhalts.Add(StringGeradeArbeit.Substring(index_Vor_AnfangChildNodeKlammer, LengthDerTeil));
					}
					else { Console.WriteLine("Falsche XML File"); break; }
					//z.B. Kurzste Title Name "a" => <a></a> => index_Hinter_EndeChildNode(6) - index_Vor_AnfangChildNode(0)

					//wenn obergeschriebene bedingung falsch ist, es "<></>" teil.. das ist falsch Format in XML Regeln.

					//뒤에 뭐가 더 있는지 확인하고나서.
					int LengthDerVerbleibendenCharDesStrings = StringGeradeArbeit.Length - index_Hinter_EndeChildNodeKlammer - 1;
					if (LengthDerVerbleibendenCharDesStrings > 0)
					{

						//gibt es etwas mehr in hintern
						//schneiden den Hintersatze und
						//StringGeradeArbeit = StringGeradeArbeit.Substring(index_Hinter_EndeChildNode + 1, StringGeradeArbeit.Length - index_Hinter_EndeChildNode - 1);
						StringGeradeArbeit = StringGeradeArbeit.Substring(index_Hinter_EndeChildNodeKlammer + 1, LengthDerVerbleibendenCharDesStrings);
						//nochmal Arbeit.
					}
					else
					{
						//무한 루프가 발생하면 안되기에 아마도 반복문 첫쨰 행에서 판명해야할 내용들이 많이 있을듯하다.
						//gibt es etwas mehr in hintern
						//ESCAPE!
						gibtEsMehreEtwas = false;
					}
				}
				//만약에 괄호가 없었다면 
				else
				{
					//자식이 없다는 것을 다시한번 확인하고
					anzahlDerKinder = 0;
					//while문에서 탈출.
					gibtEsMehreEtwas = false;
				}
			}//while Ende
			anzahlDerKinderUndSchnideteInhaltList.anzahlDerKinderNode = anzahlDerKinder;
			return anzahlDerKinderUndSchnideteInhaltList;
		}
	}

	public class Node
	{
		public List<Node> ChildNodes = new List<Node>();

		public InfoOfNode info = new InfoOfNode();
	}
	public class Attribute
	{
		private string Key = string.Empty;
		private string Value = string.Empty;
		public void SetKey(string key) { Key = key; }
		public void SetValue(string value) { Value = value; }
	}
	//<Node_Titel attr1="hallo!" attr2="ciao!">
	//		<Child_Node>										|Von hier
	//				<Name>element_Node</Name>				|
	//				<Vorname>element_Node</Name>			|
	//		</Child_Node>										|
	//		<Child_Node>										|
	//				<Name>element_Node</Name>				|
	//				<Vorname>element_Node</Name>			|
	//		</Child_Node>										|bis hier ist 'stringEtwasZwischenNode'
	//</Node_Titel>
	public class InfoOfNode
	{
		public List<Attribute> Attributes = new List<Attribute>();

		public string element_Node = string.Empty;
		public bool gibtEsNeueNodeInGeradeArbeitendeString = false;
		
		public int index_Vor_AnfangNodeKlammer = 0;
		public int index_Hinter_AnfangNodeKlammer = 0;
		public int index_Vor_EndeNodeKlammer = 0;
		public int index_Vor_EndeNode = 0;
		public int index_Hinter_EndeNode = 0;
		public int index_Hinter_EndeNodeKlammer = 0;

		public string title_Node = string.Empty;

		public bool gibtEsEtwasZwischenNode = false;

		public string stringEtwasZwischenNode = string.Empty;

		public AnzahlDerKinderUndSchnideteInhaltList AnzahlKinderUndInhalts;

		////der Parent muss nicht wissen, ob der Kind Kinder hat oder nicht.
		//public bool gibtEsNeueNodeInDerInhalt = false;
	}

	public class AnzahlDerKinderUndSchnideteInhaltList
	{
		public int anzahlDerKinderNode = 0;
		public List<string> schnideteInhalts = new List<string>();
	}
	public class TitleOfNodeAndAttruibutes
	{
		public string TitleOfNode = string.Empty;
		public List<Attribute> attributes = new List<Attribute>();
	}
}