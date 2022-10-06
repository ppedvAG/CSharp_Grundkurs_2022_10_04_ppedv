using System.Collections.ObjectModel;

namespace M011;

internal class Program
{
	static void Main(string[] args)
	{
		List<int> list = new List<int>(); //Erstellung einer Liste mit einem Generic
		list.Add(1); //T wird ersetzt durch int
		list.Add(2); //T wird ersetzt durch int
		list.Add(2); //T wird ersetzt durch int
		list.Add(1); //T wird ersetzt durch int
		list.Remove(1); //Entferne das erste Element das der Bedingung entspricht

		List<string> list2 = new List<string>();
		list2.Add("Test"); //T wird ersetzt durch string

		Console.WriteLine(list[0]); //Funktioniert genau wie ein Array

		Console.WriteLine(list.Count); //Count statt Length, nicht Count() benutzen

		list[0] = 3; //Zuweisung genau wie beim Array

		list.Sort(); //Liste sortieren

		foreach (int item in list) //Liste iterieren wie beim Array
		{
			Console.WriteLine(item);
		}

		if (list.Contains(2))
		{
			//...
		}

		list.Clear(); //Alle Elemente entfernen

		Stack<string> staedteStack = new Stack<string>();
		staedteStack.Push("Hamburg"); //Elemente hinzufügen
		staedteStack.Push("Wien");
		staedteStack.Push("Köln");
		staedteStack.Push("Berlin"); //Oberstes Element

		Console.WriteLine(staedteStack.Peek()); //Oberstes Element anschauen

		Console.WriteLine(staedteStack.Pop()); //Oberstes Element entfernen und zurückgeben

		Queue<string> queue = new Queue<string>();
		queue.Enqueue("Hamburg"); //Elemente hinzufügen
		queue.Enqueue("Wien");
		queue.Enqueue("Köln");
		queue.Enqueue("Berlin"); //Letztes Element

		Console.WriteLine(queue.Peek()); //Erstes Element anschauen

		Console.WriteLine(queue.Dequeue()); //Erstes Element aus der Queue entfernen und zurückgeben

		Dictionary<string, int> einwohnerzahlen = new Dictionary<string, int>(); //Liste von Key-Value Paaren, Keys müssen eindeutig sein
		einwohnerzahlen.Add("Wien", 2_000_000); //Zwei Parameter (Key und Value)
		//einwohnerzahlen.Add("Wien", 2_000_000); //nicht möglich
		einwohnerzahlen.Add("Berlin", 3_650_000); //Zwei Parameter (Key und Value)
		einwohnerzahlen.Add("Paris", 2_160_000); //Zwei Parameter (Key und Value)

		Console.WriteLine(einwohnerzahlen["Wien"]); //Dictionary mit [] angreifen über den Key (hier string), Value als Ergebnis

		if (einwohnerzahlen.ContainsKey("Wien")) //Überprüfen ob ein Key existiert
			Console.WriteLine(einwohnerzahlen["Wien"]);

		einwohnerzahlen.ContainsValue(2_000_000); //Überprüfen ob ein Value existiert

		foreach (string key in einwohnerzahlen.Keys) //Keys separat anschauen
		{
			Console.WriteLine(key);
		}

		foreach (int value in einwohnerzahlen.Values) //Values separat anschauen
		{
			Console.WriteLine(value);
		}

		foreach (KeyValuePair<string, int> kv in einwohnerzahlen) //Dictionary durchgehen mit KeyValuePair<Key, Value>
		{
			Console.WriteLine(kv.Key + ", " + kv.Value);
		}

		SortedDictionary<string, int> einwohnerzahlenSorted = new(); //Sortiert sich nach jeder Aktion im Dictionary automatisch (Achtung: Performance)
		einwohnerzahlenSorted.Add("Wien", 2_000_000);
		einwohnerzahlenSorted.Add("Berlin", 3_650_000); //Berlin vor Wien
		einwohnerzahlenSorted.Add("Paris", 2_160_000); //Paris zwischen Berlin und Wien

		ObservableCollection<string> str = new(); //Benachrichtigt wenn etwas passiert
		str.CollectionChanged += Str_CollectionChanged; //Event anhängen mit +=
		str.Add("X");
		str.Add("Y");
		str.Add("Z");
		str.Remove("X");
	}

	private static void Str_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
	{
		//Console.WriteLine("Es ist was passiert");
		switch (e.Action)
		{
			case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
				Console.WriteLine($"Ein Element wurde hinzugefügt {e.NewItems[0]}");
				break;
			case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
				Console.WriteLine($"Ein Element wurde entfernt {e.OldItems[0]}");
				break;
		}
	}
}