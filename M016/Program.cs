using System.Collections;
using System.Timers;

namespace M016;

internal class Program
{
	static void Main(string[] args)
	{
		Wagon w1 = new();
		Wagon w2 = new();
		if (w1 == w2)
		{
			Console.WriteLine("Gleich");
		}

		Zug z = new();
		z++;
		z++;
		z++;
		z++;

		foreach (Wagon w in z)
		{
			//...
		}

		//Console.WriteLine(z[3]);
		//z[1] = new Wagon();
		//Console.WriteLine(z[30, "Rot"]);

		System.Timers.Timer timer = new();
		timer.Interval = 1000; //1s
		timer.Elapsed += (sender, e) =>
		{
			Console.WriteLine("Eine Sekunden");
		};
		timer.Start();

		Console.ReadKey();
	}
}

public class Zug : IEnumerable
{
	private List<Wagon> Wagons = new();

	public Wagon this[int idx]
	{
		get => Wagons[idx];
		set => Wagons[idx] = value;
	}

	public Wagon this[string farbe]
	{
		get => Wagons.First(e => e.Farbe == farbe);
	}

	public Wagon this[int anzSitze, string farbe]
	{
		get => Wagons.First(e => e.AnzSitze == anzSitze && e.Farbe == farbe);
	}

	public IEnumerator GetEnumerator()
	{
		return Wagons.GetEnumerator();
	}

	public static Zug operator ++(Zug z)
	{
		z.Wagons.Add(new Wagon());
		return z;
	}
}

public class Wagon
{
	public int AnzSitze { get; set; }

	public string Farbe { get; set; }

	public static bool operator ==(Wagon w1, Wagon w2)
	{
		return w1.AnzSitze == w2.AnzSitze && w1.Farbe == w2.Farbe;
	}

	public static bool operator !=(Wagon w1, Wagon w2)
	{
		return !(w1 == w2);
	}
}