using M006.Bauteile;
using M006.Moebel;

namespace M006;

internal class Raum
{
	public Fenster[] Fenster = new Fenster[5];
	public Tuere Tuer;

	public Tisch[] Tische = new Tisch[10];
	public Sessel[] Sessel = new Sessel[10];

	public double Laenge;
	public double Breite;
}
