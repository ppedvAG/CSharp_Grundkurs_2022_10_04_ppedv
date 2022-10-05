namespace M007;

internal class Fenster
{ 
	#region Variable + Get/Set
	private double laenge; //Felder sollten von aussen nicht angreifbar sein (nur über Methoden)
	#endregion

	#region Properties
	private double breite;

	private FensterStatus status;

	public FensterStatus Status
	{
		get { return status; }
		set { status = value; } //private set: nicht von außen setzbar (nur innerhalb der Klasse)
	}

	public void FensterOeffnen()
	{
		if (Status != FensterStatus.Offen)
			Status = FensterStatus.Offen;
		else
			Console.WriteLine("Fenster ist bereits geöffnet");
		//ZaehleFenster(); funktioniert
	}
	#endregion

	public Fenster() //Wie Methode nur ohne Rückgabewert
	{ }

	public Fenster(double laenge, double breite)
	{
		this.laenge = laenge; //Mit this nach oben greifen auf die Variable Länge
		this.breite = breite;
		//ZaehleFenster();
	}

	~Fenster() //~ + Tab + Tab
	{
		Console.WriteLine($"Fenster wurde eingesammelt {laenge}x{breite}"); //Wird aufgerufen wenn der Garbage Collector das Objekt einsammelt
	}

	#region Static
	public static int Zaehler = 0;

	public static void ZaehleFenster()
	{
		Zaehler++;
		//FensterOeffnen(); nicht möglich
	}
	#endregion
}

enum FensterStatus
{
	Geschlossen,
	Gekippt,
	Offen
}
