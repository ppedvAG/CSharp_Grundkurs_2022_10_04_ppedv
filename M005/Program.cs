namespace M005
{
	internal class Program
	{
		static void Main(string[] args)
		{
			PrintAddiere(10, 5); //Funktionsaufruf über den Namen der Funktion, Parameter müssen mit angegeben werden
			PrintAddiere(2, 5);
			PrintAddiere(5, 5);
			PrintAddiere(8, 5);

			double ergebnis = Addiere(4.3, 6.1); //Ergebnis der Funktion wird in die Variable geschrieben
			int intErgebnis = Addiere(3, 4); //int Methode verwenden
			Addiere(3.0, 3); //double Methode erzwingen
			Addiere(3, 3); //int Methode funktioniert nur wenn ich 2 ints habe

			Addiere(3.4, 2.9, 10, 22.4, 44); //params Overload verwenden
			Addiere(3.4, 4.5); //nicht params Overload sondern (double, double)

			Subtrahiere(3, 2);
			Subtrahiere(5, 2, 1); //z3 überschreiben

			SubtrahiereOderAddiere(5, 2); //Addieren
			SubtrahiereOderAddiere(5, 2, false); //Subtrahieren

			int sub;
			int add = SubtrahiereUndAddiere(4, 2, out sub);
			
			if (int.TryParse("4", out int res)) //Direkte Initialisierung von res
			{
				Console.WriteLine(res);
			}
			else
			{
				Console.WriteLine("Parsen hat nicht funktioniert");
			}

			(int, int) zwei = ZweiReturns();
			Console.WriteLine(zwei.Item1);
			Console.WriteLine(zwei.Item2);

			PrintWochentag(Wochentag.Fr); //Enumwert verwenden um die Sicherheit zu erhöhen
		}

		static void PrintAddiere(int z1, int z2) //Funktion mit void (kein Rückgabewert), Zwei Parameter: z1, z2
		{
			Console.WriteLine($"{z1} + {z2} = {z1 + z2}");
		}

		static double Addiere(double z1, double z2) //double als Rückgabewert statt void
		{
			return z1 + z2; //Ergebnis herausgeben
		}

		static int Addiere(int z1, int z2)
		{
			return z1 + z2;
		}

		static double Addiere(params double[] zahlen)
		{
			return zahlen.Sum();
		}

		static double Subtrahiere(int z1, int z2, int z3 = 0) //z3 ist optional
		{
			return z1 - z2 - z3;
		}

		static int SubtrahiereOderAddiere(int z1, int z2, bool add = true) //optionale Parameter müssen die letzten Parameter sein
		{
			if (add)
				return z1 + z2;
			else
				return z1 - z2;
		}

		static int SubtrahiereUndAddiere(int z1, int z2, out int sub)
		{
			sub = z1 - z2; //out Parameter direkt zuweisen
			return z1 + z2;
		}

		static (int, int) ZweiReturns() //Tupel als Rückgabewert
		{
			return (3, 5); //Mehrere Werte zurückgeben
		}

		static void PrintZahl(int zahl)
		{
			Console.WriteLine(zahl);
			return; //Aus Funktion herausspringen / Funktion beenden
			Console.WriteLine(zahl); //Kann nicht erreicht werden
		}

		static string PrintWochentag(Wochentag w)
		{
			switch (w)
			{
				case Wochentag.Mo: return "Montag"; //Bei einem switch mit return muss kein break verwendet werden
				case Wochentag.Di: return "Dienstag";
				case Wochentag.Mi: return "Mittwoch";
				case Wochentag.Do: return "Donnerstag";
				case Wochentag.Fr: return "Freitag";
				case Wochentag.Sa: return "Samstag";
				case Wochentag.So: return "Sonntag";
				default: return "Fehler"; //Alle Code Pfade müssen einen Wert zurückgeben, daher default notwendig
			}
		}
	}

	public enum Wochentag
	{
		Mo,
		Di,
		Mi,
		Do,
		Fr,
		Sa,
		So
	}
}