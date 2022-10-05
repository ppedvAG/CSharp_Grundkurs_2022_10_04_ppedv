using M006.Bauteile; //Bauteile importieren (von außen)
using M006.Moebel;

namespace M006
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Fenster f = new Fenster();
			//f.Laenge = 100000; nicht möglich da private
			f.SetLaenge(1);
			f.SetLaenge(100);

			f.Breite = 5; //Set Methode bei einem Property
			Console.WriteLine(f.Breite); //Get Methode bei einem Property

			//f.Status = FensterStatus.Offen; nicht möglich, da private set
			//f.Farbe = "Rot"; nicht möglich, da kein Setter

			Fenster f2 = new Fenster(2, 5, 2); //Standardwerte für mein Fenster über Konstruktor setzen
			Tisch t = new Tisch(); //Mit Strg + . Moebel importieren

			//Console -> System
			//File -> System.IO
			//HttpClient -> System.Net.Http

			Raum r = new Raum();
			r.Fenster[0] = f;
			r.Fenster[1] = f2;
			r.Tische[0] = t;
			r.Tuer = new Tuere();
		}
	}
}