using M008.Raum;

namespace M008;

internal class Program
{
	static void Main(string[] args)
	{
		Lebewesen l = new Lebewesen("Max");
		l.Name = "Test";
		//l.Alter = 23; nicht möglich
		l.WasBinIch();

		Mensch m = new Mensch("Max", 23);
		m.Name = "Max"; //Wird von Lebewesen vererbt
		m.Alter = 23;
		m.WasBinIch(); //Kommt von oben

		Raum2 r = new Raum2();
		r.Bauteile[0] = new Fenster();
		r.Bauteile[1] = new Fenster();
		r.Bauteile[2] = new Tuere();

		r.Moebel[0] = new Tisch();
		r.Moebel[1] = new Tisch();
		r.Moebel[2] = new Tisch();
		r.Moebel[3] = new Tisch();
		r.Moebel[4] = new Sessel();
		r.Moebel[5] = new Sessel();
		r.Moebel[6] = new Sessel();
	}
}

public class Lebewesen //Basisklasse
{
	public string Name { get; set; }

	public Lebewesen(string name)
	{
		Name = name;
	}

	//Wird auch nach unten vererbt
	public virtual void WasBinIch() //virtual: kann überschrieben werden, muss aber nicht überschrieben werden
	{
		Console.WriteLine("Ich bin ein Lebewesen");
	}
}

public sealed class Mensch : Lebewesen //Mensch ist ein Lebewesen (Vererbung herstellen)
{
	//Name kommt von oben

	public int Alter { get; set; }

	public Mensch(string name, int alter) : base(name) //base: this bei Vererbung
	{
		Alter = alter;
	}

	public sealed override void WasBinIch() //override: Überschreibe die Methode von oben, obere Methode muss virtual sein
	{
		//base.WasBinIch(); //Ruf die obere Methode auf
		Console.WriteLine($"Ich bin ein Mensch und bin {Alter} Jahre alt");
	}

	//public new void WasBinIch() { } //new: neue Methode statt Überschreibung
}

//public class Kind : Mensch //nicht möglich, da sealed
//{
//	public Kind(string name, int alter) : base(name, alter) { }

//	public override void WasBinIch() { } //nicht möglich, da sealed
//}