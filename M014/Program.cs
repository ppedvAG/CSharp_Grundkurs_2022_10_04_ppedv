namespace M014;

internal class Program
{
	public delegate void Vorstellung(string name); //Definition von Delegate, speichert Referenzen zu Methoden, können zur Laufzeit hinzugefügt und weggenommen werden

	static void Main(string[] args)
	{
		Vorstellung vorstellungen; //Variable
		vorstellungen = new Vorstellung(VorstellungDE); //Delegate erstellen mit new und Methodenzeiger
		vorstellungen("Max"); //Delegate ausführen mit <Name>(<Parameter>)

		vorstellungen += new Vorstellung(VorstellungEN); //Methode anhängen (lang)
		vorstellungen += VorstellungEN; //Kurzform, Methoden können mehrmals angehängt werden
		vorstellungen("Max"); //Alle Methoden werden sequentiell ausgeführt

		vorstellungen -= VorstellungDE; //Methode abhängen mit -=
		vorstellungen -= VorstellungDE;
		vorstellungen -= VorstellungDE;
		vorstellungen -= VorstellungDE; //Methode die nicht dranhängt abnehmen bringt keine Fehlermeldung
		vorstellungen("Max");

		vorstellungen -= VorstellungEN;
		vorstellungen -= VorstellungEN; //Wenn alle Methoden abgehängt werden wird das Delegate null
		vorstellungen("Max"); //Exception

		if (vorstellungen is not null) //Null-Check
			vorstellungen("Max");

		vorstellungen.Invoke("Max"); //Ausführen wie zwei Zeilen darüber
		vorstellungen?.Invoke("Max"); //? vor . ist ein einfacher Null-Check (Methode wird nicht ausgeführt wenn null)

		vorstellungen = null; //Delegate entleeren

		foreach (Delegate dg in vorstellungen.GetInvocationList()) //Delegate iterieren
		{
			Console.WriteLine(dg.Method.Name); //mit dg.Method in die Methode reinschauen
		}
	}

	public static void VorstellungDE(string name) => Console.WriteLine($"Hallo mein Name ist {name}");

	public static void VorstellungEN(string name) => Console.WriteLine($"Hello my name is {name}");
}