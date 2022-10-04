namespace M003
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region Arrays
			int[] zahlen = new int[10]; //Array mit Länge 10 (0-9)
			zahlen[2] = 8; //An die Stelle 2 die Zahl 8 schreiben
			Console.WriteLine(zahlen[2] * 3);

			int[] zahlenDirekt = new int[] { 1, 2, 3, 4, 5 }; //Direkte Initialisierung, Länge automatisch (5)
			int[] zahlenDirektKuerzer = new[] { 1, 2, 3, 4, 5 }; //Kurzschreibweise (wie oben, nur kürzer)
			int[] zahlenDirektNochKuerzer = { 1, 2, 3, 4, 5 }; //Kürzeste Schreibweise

			Console.WriteLine(zahlen.Length); //Größe des Arrays (10)

			Console.WriteLine(zahlen.Contains(3)); //false
			Console.WriteLine(zahlen.Contains(8)); //true

			int[,] zweiDArray = new int[3, 3]; //Matrix (3x3), Deklaration mit Beistrich in der Klammer, Initialisierung mit zwei Größen
			zweiDArray[1, 1] = 3; //Mit zwei Indizes Array ansprechen
			zweiDArray = new[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }; //Direkte Initialisierung bei 2 Dimensionen
			Console.WriteLine(zweiDArray.Length); //Gesamte Felder: 9
			Console.WriteLine(zweiDArray.Rank); //Anzahl Dimensionen: 2
			Console.WriteLine(zweiDArray.GetLength(0)); //Erste Dimension Länge: 3
			Console.WriteLine(zweiDArray.GetLength(1)); //Zweite Dimension Länge: 3

			int[,,] dreiDArray = new int[2, 3, 4]; //beliebig viele Dimensionen möglich
			#endregion

			int zahl1 = 8;
			int zahl2 = 5;

			if (zahl1 == zahl2)
			{
				//...
			}

			bool invert = true;
			invert = !invert; //bool invertieren
			invert ^= true; //bool auch invertieren nur kürzer
			//App.MainWindow.Button.Boolean = !App.MainWindow.Button.Boolean
			//App.MainWindow.Button.Boolean ^= true;

			if (zahl1 < zahl2)
			{
				//...
			}
			else //Größer und Gleich abdecken
			{

			}

			if (zahl1 < zahl2) { }
			else if (zahl1 == zahl2) { }
			else { }

			if (zahl1 < zahl2)
				Console.WriteLine();
			else 
			{ 
				if (zahl1 == zahl2)
				{
				}
				else
				{
				}
			}

			if (zahl1 < zahl2) //Klammern können bei einzeiligen Ifs und Elses weggelassen werden
				zahl1++;
			else
				zahl2++;

			if (zahlen.Contains(3))
			{
				//Zahlen enthält 3
			}
			else
			{
				//Zahlen enthält nicht 3
			}

			if (zahl1 == zahl2)
				Console.WriteLine("Gleich");
			else
				Console.WriteLine("Ungleich");

			//Fragezeichen Operator (?, :) ? ist if, : ist else
			//Braucht immer ein else
			Console.WriteLine(zahl1 == zahl2 ? "Gleich" : "Ungleich");
		}
	}
}