namespace M004
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region Schleifen
			int a = 0;
			int b = 10;
			while (a < b) //Schleife läuft solange die Bedingung true ist
			{
				Console.WriteLine("while: " + a);
				if (a == 5)
					break; //Break: beendet die Schleife (bei verschachtelten Schleifen springt break aus der inneren Schleife heraus)
				a++;
			}

			int c = 0;
			int d = 10;
			do //Wird mindestens einmal ausgeführt, auch wenn die Bedingung von Anfang an false ist
			{
				c++;
				if (c == 5)
					continue; //springt in den Schleifenkopf zurück (Code darunter wird ausgelassen)
				Console.WriteLine("do-while: " + c);
			}
			while (c < d);

			//while (true) { } //Endlosschleife

			//for + Tab + Tab
			for (int i = 0; i < 10; i++) //Schleife mit integriertem Zähler
			{
				Console.WriteLine("for: " + i);
			}

			//forr + Tab + Tab
			for (int i = 10 - 1; i >= 0; i--) //Herunterzählende Schleife
			{
				Console.WriteLine("forr: " + i);
			}

			int[] ints = { 1, 2, 3, 4, 5, 6, 24, 75, 12, 59 };
			for (int i = 0; i < ints.Length; i++) //Array iterieren
			{
				Console.WriteLine(ints[i]);
			}

			foreach (int zahl in ints) //Kein daneben greifen bei Arrays möglich
			{
				Console.WriteLine(zahl);
			}

			foreach (int zahl in ints) //Einzeilige Schleifen können auch ohne Klammern geschrieben werden
				Console.WriteLine(zahl);
			#endregion

			#region Enums
			string heutigerTag = "Dienstag";
			if (heutigerTag == "dienstag") { } //Fehleranfällig mit Strings

			Wochentag heute = Wochentag.Di; //Variable vom Enum machen
			Wochentag eingabe = Enum.Parse<Wochentag>("Di"); //Eingabe vom User
			if (heute == eingabe) { } //Keine Fehleranfälligkeit

			int x = 2;
			Wochentag wt = (Wochentag) x; //int zu Wochentag casten
			Console.WriteLine(wt);
			Console.WriteLine(Enum.Parse<Wochentag>(x.ToString())); //Enum.Parse kann ints oder strings parsen

			Wochentag[] tage = Enum.GetValues<Wochentag>(); //Alle Enumwerte in ein Array einfügen
			foreach (Wochentag w in tage) //Alle Wochentage durchgehen
			{
				Console.WriteLine(w);
			}
			#endregion

			#region Switch
			int z = 5;
			switch (z)
			{
				case 1: //Sozusagen eine If
					Console.WriteLine("z ist 1");
					break; //Am Ende von jedem Case ein break machen
				case 2:
					Console.WriteLine("z ist 2");
					break;
				case 5:
					Console.WriteLine("z ist 5");
					break;
				default: //Sozusagen das else
					Console.WriteLine("z ist eine andere Zahl");
					break;
			}

			switch (heute)
			{
				case Wochentag.Mo:
					Console.WriteLine("Es ist Montag");
					break;
				case Wochentag.Di: //Di bis Fr zusammengelegt
				case Wochentag.Mi:
				case Wochentag.Do:
				case Wochentag.Fr:
					Console.WriteLine("Es ist ein Werktag");
					break;
				case Wochentag.Sa:
				case Wochentag.So:
					Console.WriteLine("Es ist Wochenende");
					break;
				default:
					Console.WriteLine("Fehler");
					break;
			}

			switch (heute)
			{
				//and/or statt &&/||
				case >= Wochentag.Mo and <= Wochentag.Fr:
					Console.WriteLine("Wochentag");
					break;
				case Wochentag.Sa or Wochentag.So:
					Console.WriteLine("Wochenende");
					break;
			}
			#endregion
		}
	}

	enum Wochentag //Enumdeklaration außerhalb der Main Methode
	{
		Mo = 1, //Startindex setzen
		Di,
		Mi,
		Do = 10, //ab hier neu zählen
		Fr,
		Sa,
		So
	}
}