namespace M014;

internal class Events
{
	static event EventHandler TestEvent;

	static event EventHandler<TestEventArgs> ArgsEvent;

	static void Main(string[] args)
	{
		TestEvent += Events_TestEvent; //Extra Methode anhängen ohne new, Events können nicht instanziert werden
		TestEvent(null, EventArgs.Empty); //Event ausführen

		ArgsEvent += Events_ArgsEvent;
		ArgsEvent(null, new TestEventArgs() { Status = "Erfolg", Message = "Alles gut" });

		TestEvent += (sender, args) => { }; //Anonyme Methode anhängen

		TestEvent(null, new TestEventArgs());
	}

	private static void Events_TestEvent(object? sender, EventArgs e)
	{
		Console.WriteLine("Test");
		if (e is TestEventArgs te)
		{
			te.Test();
		}
	}

	private static void Events_ArgsEvent(object? sender, TestEventArgs e)
	{
		Console.WriteLine(e.Status);
		Console.WriteLine(e.Message);
		e.Test();
	}
}

internal class TestEventArgs : EventArgs
{
	public string Status { get; set; }

	public string Message { get; set; }

	public void Test() => Console.WriteLine($"Status: {Status}, Nachricht: {Message}");
}