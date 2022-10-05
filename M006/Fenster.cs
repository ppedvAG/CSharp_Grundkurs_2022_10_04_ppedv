namespace M006.Bauteile;

internal class Fenster
{ 
	#region Variable + Get/Set
	private double laenge; //Felder sollten von aussen nicht angreifbar sein (nur über Methoden)

	public double GetLaenge()
	{
		return laenge; //Einfach Länge zurückgeben
	}

	public void SetLaenge(double neueLaenge)
	{
		if (neueLaenge < 0.05 || neueLaenge > 50) //Überprüfung des neuen Werts
			Console.WriteLine("Neue Länge ist nicht gültig");
		else
			laenge = neueLaenge; //Wenn der Wert passt, einfach zuweisen
	}
	#endregion

	#region Properties
	private double breite;

	public double Breite
	{
		get { return breite; }
		set //Hier ist auch Überprüfungscode möglich
		{
			if (value < 0.05 || value > 50) //Überprüfung des neuen Werts
				Console.WriteLine("Neue Breite ist nicht gültig");
			else
				breite = value; //Wenn der Wert passt, einfach zuweisen
		} //value kommt von der Zuweisung in der Main Methode (f.Breite = 5 -> value = 5)
	}

	private FensterStatus status;

	public FensterStatus Status
	{
		get { return status; }
		private set { status = value; } //private set: nicht von außen setzbar (nur innerhalb der Klasse)
	}

	public void FensterOeffnen()
	{
		if (Status != FensterStatus.Offen)
			Status = FensterStatus.Offen;
		else
			Console.WriteLine("Fenster ist bereits geöffnet");
	}

	private string farbe = "Grau"; //Standardwert setzen, wird bei Erstellung des Objekts gesetzt (new)

	public string Farbe
	{
		get { return farbe; }
		//Set weglassen
	}

	public int Scheibenanzahl { get; set; } = 2; //Standardwert setzen, wird bei Erstellung des Objekts gesetzt (new)
	#endregion

	public Fenster() //Wie Methode nur ohne Rückgabewert
	{ }

	public Fenster(double laenge, double breite)
	{
		this.laenge = laenge; //Mit this nach oben greifen auf die Variable Länge
		this.breite = breite;
	}

	public Fenster(double laenge, double breite, int scheiben) : this(laenge, breite) //Mit this Konstruktoren verketten
	{
		this.Scheibenanzahl = scheiben;
	}
}

enum FensterStatus
{
	Geschlossen,
	Gekippt,
	Offen
}
