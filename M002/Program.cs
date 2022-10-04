namespace M002
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region Variablen
			int zahl; //Deklaration
			zahl = 5; //Zuweisung
			//int: Ganze Zahl
			Console.WriteLine(zahl);

			int zahlMitZuweisung = 5; //Deklaration und Zuweisung gemeinsam
			Console.WriteLine(zahlMitZuweisung); //cw + Tab + Tab -> Console.WriteLine(...);

			int zahlMalZwei = zahl * 2; //obere Zahl mal 2 = 10
			Console.WriteLine(zahlMalZwei);

			/*
				Mehrzeiliger
				Kommentar
			*/

			string wort = "Hallo"; //Text mit doppelten Hochkomma
			Console.WriteLine(wort);

			char zeichen = 'A'; //Einzelne Hochkomma statt doppelten
			Console.WriteLine(zeichen);

			double kostenDouble = 48.22; //Punkt statt Beistrich für Kommazahlen

			float kostenFloat = 48.22f; //Kommazahlen standardmäßig double, Konvertierung zum float mit f am Ende

			decimal kostenDecimal = 48.22m; //Geeignet für Geldwerte, Konvertieren zu decimal mit m am Ende

			bool b = true; //bool: Wahr/Falschwert
			b = false; //true oder false
			#endregion

			#region Strings
			string kombination = "Das Wort ist: " + wort; //Stringverknüpfung
			Console.WriteLine(kombination);

			string kombinationInt = "Die Zahl ist: " + zahl; //Stringverknüpfung auch möglich mit Ints (oder anderen Typen)
			Console.WriteLine(kombinationInt);

			string abstand = "Die Werte sind: " + wort + ", " + zahl + ", " + b; //Anstrengend
			Console.WriteLine(abstand);

			string interpolation = $"Die Werte sind: {wort}, {zahl}, {b}"; //Einfacher als obiges mit Interpolation
			Console.WriteLine(interpolation);

			//https://docs.microsoft.com/en-us/cpp/c-language/escape-sequences?view=msvc-170
			Console.WriteLine("Umbruch \n Umbruch"); //\n für Zeilenumbruch

			Console.WriteLine("Tabulator \t Tabulator"); //\t für Tabulator

			Console.WriteLine("C:\\Users\\lk3"); //Doppelter Backslash um einzelnen Backslash zu bekommen

			string verbatim = @"\n\t\"; //Verbatim-String: String der 1:1 so interpretiert wird wie er definiert wurde (keine Escape-Sequenzen)
			Console.WriteLine(verbatim);

			string umbruch = @"Umbruch
Umbruch";
			Console.WriteLine(umbruch);

			string pfad = @"C:\Users\lk3\source\repos\CSharp_Grundkurs_2022_08_23\M002";
			Console.WriteLine(pfad);
			#endregion

			#region Eingabe
			string eingabe = Console.ReadLine(); //Mit Console.ReadLine() eine Eingabe vom Benutzer verlangen, Programm bleibt stehen bis Enter gedrückt wird
			Console.WriteLine(eingabe); //Eingabe vom User steht dann in der eingabe Variable
			Console.WriteLine("Das Wort ist: " + eingabe);

			char eingabeChar = Console.ReadKey().KeyChar; //ReadKey benutzen um einzelnes Zeichen einzulesen, KeyChar
			Console.WriteLine(eingabeChar);

			int parseInt = int.Parse(eingabe); //Umwandlung von string zu int
			Console.WriteLine(parseInt * 5);

			double parseDouble = double.Parse(eingabe);
			Console.WriteLine(parseDouble + 1.5);

			int x = Convert.ToInt32(eingabe); //Convert statt int.Parse (alt)
			Console.WriteLine(x);
			#endregion

			//Strg + K + C: Ganzen Block auskommentieren
			//Strg + K + U: Ganzen Block einkommentieren

			#region Konvertierungen
			double d = 45.22;
			int i = (int) d; //Konvertierung erzwingen mit (int) vor Zuweisung (explizite Konvertierung -> Typecast)
			float f = (float) d; //Konvertierung zu float erzwingen

			Console.WriteLine(i.ToString()); //beliebige Variable zu String konvertieren
			#endregion

			#region Arithmetik
			int zahl1 = 5;
			int zahl2 = 7;
			Console.WriteLine(zahl1 + zahl2); //Originale Werte bleiben unverändert

			zahl1 = zahl1 + zahl2; //Schreibe das Ergebnis von zahl1 + zahl2 in zahl1
			zahl1 += zahl2; //Selber Code wie eine Zeile darüber nur kürzer
			Console.WriteLine(zahl1); //19

			Console.WriteLine(zahl1 % zahl2); //Modulo-Operator: Rest einer Division (5)
			Console.WriteLine(zahl2 % zahl1); //Modulo-Operator: Rest einer Division (7)

			zahl1 %= zahl2;

			zahl1++; //Erhöhe die Zahl um 1
			zahl1--; //Verringere die Zahl um 1

			double zahl3 = 55.3462;
			//Rundungsfunktionen verändern nicht den originalen Wert
			Math.Ceiling(zahl3); //Aufrunden
			Math.Floor(zahl3); //Abrunden
			Math.Round(zahl3); //Rundet auf die nächste Zahl, bei .5 wird auf die nächste gerade Zahl gerundet
			Math.Round(4.5); //4
			Math.Round(5.5); //6

			Math.Round(zahl3, 2); //Auf 2 Kommastellen runden

			Console.WriteLine(8 / 5); //Int-Division, da zwei Ints als Argumente (Ergebnis: 1 statt 1.6)
			Console.WriteLine(8.0 / 5); //Kommadivision erweingen, eine der beiden Zahlen zu einer Kommazahl konvertieren
			Console.WriteLine(8f / 5);
			Console.WriteLine(8d / 5);
			Console.WriteLine((double) zahl1 / zahl2); //Varibale zu double konvertieren mit (double)
			#endregion
		}
	}
}