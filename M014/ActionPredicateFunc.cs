namespace M014;

internal class ActionPredicateFunc
{
	static void Main(string[] args)
	{
		Action<int, int> action = Addiere; //Action: Methode mit void und bis zu 16 Parametern
		action += Subtrahiere;
		action(4, 6);
		action?.Invoke(5, 9);

		DoSomething(3, 2, Addiere); //Verhalten von Methoden anpassen ohne den Code anzupassen
		DoSomething(3, 2, Subtrahiere); //Unterschiedliche Actions als Parameter
		DoSomething(3, 2, action); //Action Parameter mit mehreren Methoden

		Predicate<int> predicate = CheckForZero; //Predicate: Methode mit bool als Rückgabewert und genau einem Parameter
		predicate += CheckForOne;
		bool b = predicate(2); //Ergebnis in bool Variable schreiben
		bool? b2 = predicate?.Invoke(2); //Hier bool? weil ?.Invoke könnte null sein wenn Predicate null ist

		DoSomething(3, CheckForZero);
		DoSomething(2, CheckForOne);

		Func<int, int, double> func = Multipliziere; //Func: Methode mit Rückgabewert, bis zu 16 Parameter, Rückgabe muss letztes Generic sein
		func += Dividiere;
		double d = func(8, 3); //Hier auch wieder letztes Ergebnis
		double? d2 = func?.Invoke(2, 8); //Zuweisung wie bei Predicate

		DoSomething(3, 8, Multipliziere);
		DoSomething(3, 8, Dividiere);

		func += delegate (int x, int y) { return x + y; };
		func += (int x, int y) => { return x + y; };
		func += (x, y) => { return x - y; };
		func += (x, y) => (double) x / y;

		DoSomething(4, 2, (x, y) => Console.WriteLine(x + y)); //Anonyme Action
		DoSomething(4, e => e == 0); //Anonymes Predicate
		DoSomething(5, 2, (x, y) => (double) x / y); //Anonyme Func
	}

	private static void Addiere(int arg1, int arg2) => Console.WriteLine(arg1 + arg2);

	private static void Subtrahiere(int arg1, int arg2) => Console.WriteLine(arg1 - arg2);

	public static void DoSomething(int z1, int z2, Action<int, int> action) => action?.Invoke(z1, z2);

	private static bool CheckForZero(int obj) => obj == 0;

	private static bool CheckForOne(int obj) => obj == 1;

	public static bool DoSomething(int z, Predicate<int> predicate) => predicate.Invoke(z);

	private static double Multipliziere(int arg1, int arg2) => arg1 * arg2;

	private static double Dividiere(int arg1, int arg2) => arg1 / arg2;

	public static double DoSomething(int z1, int z2, Func<int, int, double> func) => func.Invoke(z1, z2);
}
