using M008.Raum;

namespace M009
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Fenster f = new Fenster(); //Variablentyp Mensch, Laufzeittyp Mensch

			Bauteil b = new Fenster(); //Laufzeittyp Fenster ist kompatibel mit Variablentyp Bauteil

			b = new Tuere(); //Auch kompatibel, da Vererbungshierarchie

			object o = new Fenster(); //mit object ist jeder Typ kompatibel
			o = new Tisch();
			o = new Program();
			o = new object();
			o = 1;

			Console.WriteLine(f.GetType().Name); //Fenster
			Console.WriteLine(b.GetType().Name); //Fenster (nach b = new Tuere() -> Tuere)
			Console.WriteLine(o.GetType().Name); //Int32

			Type fenster = typeof(Fenster);

			#region Exakter Typvergleich
			if (f.GetType() == typeof(Fenster))
			{
				//true
			}

			if (f.GetType() == typeof(Bauteil))
			{
				//false
			}
			#endregion

			#region Vererbungshierarchie Typvergleich
			if (f is Fenster)
			{
				//true
			}

			if (f is Bauteil)
			{
				//true
			}

			if (f is object)
			{
				//true
			}

			if (f is Tuere)
			{
				//false
			}
			#endregion

			#region Virtual/Override
			Mensch mensch = new Mensch("Max", 23);
			mensch.WasBinIch(); //Ich bin ein Mensch und bin 23 Jahre alt

			Lebewesen l = mensch;
			l.WasBinIch(); //Ich bin ein Mensch und bin 23 Jahre alt
			#endregion

			#region New
			//Verbindung wurde getrennt durch new
			Mensch m2 = new Mensch("Max", 23);
			mensch.WasBinIch(); //Ich bin ein Mensch und bin 23 Jahre alt

			Lebewesen l2 = m2;
			l.WasBinIch(); //Ich bin ein Lebewesen
			#endregion

			//new Lebewesen(); keine Instanz möglich

			Lebewesen[] lebewesens = new Lebewesen[2];
			lebewesens[0] = new Mensch("Max", 23);
			lebewesens[1] = new Hund("Bello");

			foreach (Lebewesen leb in lebewesens)
			{
				leb.WasBinIch();
				if (leb is Mensch)
				{
					((Mensch) leb).MenschMethode();
				}

				if (leb is Hund h)
				{
					h.HundMethode();
				}
			}
		}
	}

	public abstract class Lebewesen //abstract: Strukturklasse, Entwickler muss Methoden die abstract sind selber implementieren
	{
		public string Name { get; set; }

		public Lebewesen(string name) => Name = name;

		public abstract void WasBinIch(); //Methode ohne Body, weil abstract
	}

	public class Mensch : Lebewesen //Mensch ist ein Lebewesen (Vererbung herstellen)
	{
		//Name kommt von oben

		public int Alter { get; set; }

		public Mensch(string name, int alter) : base(name) //base: this bei Vererbung
		{
			Alter = alter;
		}

		public override void WasBinIch()
		{
			Console.WriteLine("Ich bin Mensch und was auch immer");
		}

		public void MenschMethode()
		{

		}
	}

	public class Hund : Lebewesen
	{
		public Hund(string name) : base(name)
		{
		}

		public override void WasBinIch()
		{
			Console.WriteLine("Ich bin ein Hund");
		}

		public void HundMethode()
		{

		}
	}
}