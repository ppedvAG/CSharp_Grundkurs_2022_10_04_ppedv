namespace M008.Raum;

internal class Fenster : Bauteil
{
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

	public int Scheibenanzahl { get; set; } = 2; //Standardwert setzen, wird bei Erstellung des Objekts gesetzt (new)

	public Fenster() //Wie Methode nur ohne Rückgabewert
	{ }

	public Fenster(double laenge, double breite)
	{
		Laenge = laenge; //Mit this nach oben greifen auf die Variable Länge
		Breite = breite;
	}

	public Fenster(double laenge, double breite, int scheiben) : this(laenge, breite) //Mit this Konstruktoren verketten
	{
		Scheibenanzahl = scheiben;
	}
}

enum FensterStatus
{
	Geschlossen,
	Gekippt,
	Offen
}
