namespace M007
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region GC
			for (int i = 0; i < 25; i++)
			{
				Fenster f = new Fenster(i * 2, i * 5);
			}

			GC.Collect(); //Hier GC erzwingen
			GC.WaitForPendingFinalizers(); //Warte auf alle Destruktoren
			#endregion

			#region Static
			//Statische Member müssen ohne Objekt arbeiten
			//Program p = new Program();
			//p.Main(null); Statische Methoden können nicht über das Objekt sondern nur über den Klassennamen aufgerufen werden
			//Program.Main(args);

			Fenster.ZaehleFenster();
			Console.WriteLine(Fenster.Zaehler); //Zaehler ist nicht auf Objekten sondern auf der Klasse selbst
			#endregion

			#region Werte/Referenztyp
			//Wertetyp
			int original = 5;
			int x = original; //Kopie von 5
			original = 10;

			//Referenztyp
			Fenster f1 = new Fenster();
			Fenster f2 = f1; //Referenz zwischen f1 und f2
			f1.Status = FensterStatus.Offen;

			//class: Referenztyp, struct: Wertetyp
			#endregion

			#region Null
			Fenster f3; //Standardwert: null
			f3 = null;

			//f3.FensterOeffnen(); //Nicht vorhandenes Fenster kann nicht geöffnet werden
			if (f3 == null) //Wenn mein Fenster nicht existiert, erstelle ich eines
			{
				f3 = new Fenster();
			}

			if (f3 != null) //Vorher schauen ob mein Fenster existiert
			{
				f3.FensterOeffnen();
			}
			#endregion
		}
	}
}