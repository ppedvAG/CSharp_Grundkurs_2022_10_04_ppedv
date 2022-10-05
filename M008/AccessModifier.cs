namespace M008;

class AccessModifier //Klassen/Member ohne Modifier sind internal
{
	public string Name { get; set; } //Kann überall gesehen werden (auch außerhalb vom Projekt)

	private int Groesse { get; set; } //Kann nur in dieser Klasse gesehen werden

	internal string Wohnort { get; set; } //Kann überall aber nur innerhalb des Projekts gesehen werden
}
