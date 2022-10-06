using System.Diagnostics;

namespace M012;

internal class Program
{
	static void Main(string[] args)
	{
		#region Einfaches Linq
		List<int> list = Enumerable.Range(0, 100).ToList(); //Erstellt eine Liste von Start mit einer bestimmten Anzahl Elementen

		Console.WriteLine(list.Average());
		Console.WriteLine(list.Min());
		Console.WriteLine(list.Max());
		Console.WriteLine(list.Sum());

		Console.WriteLine(list.First()); //Erstes Element der Liste, Exception wenn Liste leer
		Console.WriteLine(list.FirstOrDefault()); //null wenn Liste leer

		Console.WriteLine(list.Last());
		Console.WriteLine(list.LastOrDefault());

		list.First(e => e % 10 == 0); //Das erste Element das durch 10 teilbar ist
		list.FirstOrDefault(e => e % 10 == 0); //Stürzt nicht ab wenn kein Element gefunden wird
		#endregion

		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new Fahrzeug(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		#region Vergleich Linq Schreibweisen
		//Alle BMWs mit Foreach
		List<Fahrzeug> bmwsForEach = new();
		foreach (Fahrzeug f in fahrzeuge)
			if (f.Marke == FahrzeugMarke.BMW)
				bmwsForEach.Add(f);

		//Standard-Linq: SQL-ähnlich Schreibweise (alt)
		List<Fahrzeug> bmws = (from f in fahrzeuge
							   where f.Marke == FahrzeugMarke.BMW
							   select f).ToList();

		//Methodenkette
		List<Fahrzeug> bmwsNeu = fahrzeuge.Where(f => f.Marke == FahrzeugMarke.BMW).ToList();
		#endregion

		//Alle Fahrzeuge mit MaxV > 200
		fahrzeuge.Where(e => e.MaxV > 200);

		//Alle VWs mit MaxV > 200
		fahrzeuge.Where(e => e.MaxV > 200 && e.Marke == FahrzeugMarke.VW);

		//Alle Geschwindigkeiten extrahieren
		fahrzeuge.Select(e => e.MaxV).ToList();

		var x = fahrzeuge.Select(e => new { e.MaxV, HC = e.GetHashCode() }).ToList();
		Console.WriteLine(x[0].HC);

		fahrzeuge.Select(e => new Schiff(e.MaxV, e.Marke)).ToList();

		//fahrzeuge.Select(e => (Schiff) e).ToList();

		//Alle Automarken herausholen
		List<FahrzeugMarke> marken = fahrzeuge.Select(e => e.Marke).ToList();

		//Automarken einzigartig machen
		marken.Distinct(); //Liste mit den 3 Automarken

		fahrzeuge.DistinctBy(e => e.Marke); //Jeweils das erste Auto pro Marke aus

		//Autos sortieren nach Automarke
		fahrzeuge.OrderBy(e => e.Marke);

		//In die andere Richtung sortieren
		fahrzeuge.OrderByDescending(e => e.Marke);

		//Nach mehreren Kriterien sortieren
		fahrzeuge.OrderBy(e => e.Marke).ThenBy(e => e.MaxV);

		fahrzeuge.OrderBy(e => e.MaxV).First(); //Langsamstes
		fahrzeuge.OrderBy(e => e.MaxV).Last(); //Schnellstes

		//Fahren alle Fahrzeuge schneller als 200?
		fahrzeuge.All(e => e.MaxV > 200); //bool als Ergebnis

		//Gibt es mindestens ein Auto das schneller als 300 fahren kann?
		fahrzeuge.Any(e => e.MaxV > 300);

		//Hat die Sequenz mindestens ein Element?
		fahrzeuge.Any(); //fahrzeuge.Count > 0

		//Wieviele VWs gibt es?
		fahrzeuge.Count(e => e.Marke == FahrzeugMarke.VW);

		fahrzeuge.Where(e => e.Marke == FahrzeugMarke.VW).Count(); //selbiges wie oben

		//Die Geschwindigkeit
		fahrzeuge.Min(e => e.MaxV);

		fahrzeuge.Max(e => e.MaxV);

		//Das kleinste Auto anhand MaxV zurückgeben
		fahrzeuge.MinBy(e => e.MaxV);
		fahrzeuge.Where(e => e.Marke == FahrzeugMarke.BMW).MinBy(e => e.MaxV);

		fahrzeuge.MaxBy(e => e.MaxV);

		//Liste in X große Teile aufteilen
		fahrzeuge.Chunk(5);

		//Überspringen und Nehmen (Mitte einer Liste nehmen)
		fahrzeuge.Skip(3).Take(5);

		#region Erweiterungsmethoden
		38259.Quersumme();
		int z = 382;
		z.Quersumme();

		fahrzeuge.Shuffle(); //neue gemischte Liste
		#endregion
	}
}

[DebuggerDisplay("Marke: {Marke}, Geschwindigkeit: {MaxV} - {typeof(Fahrzeug).FullName}")]
public class Fahrzeug
{
	public int MaxV;

	public FahrzeugMarke Marke;

	public Fahrzeug(int v, FahrzeugMarke fm)
	{
		MaxV = v;
		Marke = fm;
	}
}

public class Schiff : Fahrzeug
{
	public Schiff(int v, FahrzeugMarke fm) : base(v, fm) { }
}

public enum FahrzeugMarke
{
	Audi, BMW, VW
}