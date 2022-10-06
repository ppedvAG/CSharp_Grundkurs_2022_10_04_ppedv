using System.Collections;

namespace M010;

internal class Program
{
	static void Main(string[] args)
	{
		Console.OutputEncoding = System.Text.Encoding.UTF8;

		Mensch m = new Mensch();
		m.Gehalt = 3000;
		m.Job = "Softwareentwickler";
		//m.Lohnauszahlung(); nicht mehr möglich, da explizite Implementierung

		IArbeit arbeit = m;
		arbeit.Lohnauszahlung();

		ITeilzeitArbeit arbeit2 = m;
		arbeit2.Lohnauszahlung();

		ITeilzeitArbeit arbeit3 = (ITeilzeitArbeit) arbeit;
		ITeilzeitArbeit arbeit4 = arbeit as ITeilzeitArbeit;

		((ITeilzeitArbeit) arbeit).Lohnauszahlung();
		(arbeit as ITeilzeitArbeit).Lohnauszahlung();

		//IEnumerable bei jedem dieser Objekte -> Linq Funktionen sind bei allen diesen Variablen möglich
		int[] x;
		List<int> y;
		Dictionary<int, int> z;

		Test2(x);
		Test2(y);
		Test2(z);
	}

	public void Test(IArbeit a) //Jedes Objekt möglich das dieses Interface besitzt
	{

	}

	public static void Test2(IEnumerable list)
	{

	}
}

public interface IArbeit //Interfaces fangen per Konvention mit I an
{
	static int Wochenstunden = 40; //Statische Felder müssen keine Properties sein

	int Gehalt { get; set; }

	string Job { get; set; } //Properties werden weitergegeben

	void Lohnauszahlung(); //Methode ohne Body wie bei Abstrakten Methoden

	public void Test()
	{
		//Bad Practice
	}
}

public interface ITeilzeitArbeit : IArbeit //Interfaces aufeinander vererben
{
	static new int Wochenstunden = 20;

	new void Lohnauszahlung();
}

public abstract class Lebewesen { } //: Mensch { } Interfaces werden über Vererbung nicht weiter gegeben

public class Mensch : Lebewesen, IArbeit, ITeilzeitArbeit //Mehrere Interfaces vererben
{
	public int Gehalt { get; set; }

	public string Job { get; set; }

	void IArbeit.Lohnauszahlung()
	{
		Console.WriteLine($"Dieser Mitarbeiter hat ein Gehalt von {Gehalt}€ und arbeitet als {Job}. Er arbeitet {IArbeit.Wochenstunden} Stunden pro Woche."); //Auf statische Variable zugreifen
	}

	void ITeilzeitArbeit.Lohnauszahlung()
	{
		Console.WriteLine($"Dieser Mitarbeiter hat ein Gehalt von {Gehalt}€ und arbeitet als {Job}. Er arbeitet {ITeilzeitArbeit.Wochenstunden} Stunden pro Woche."); //Auf statische Variable zugreifen
	}
}