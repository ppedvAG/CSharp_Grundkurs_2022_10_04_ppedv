namespace M014;

public class EventComponent
{
	static void Main(string[] args)
	{
		Component c = new Component();
		c.ProcessCompleted += () => Console.WriteLine("Prozess fertig");
		c.ValueChanged += x => Console.WriteLine($"Zähler: {x}");
		c.StartProcess();
	}
}

internal class Component
{
	public event Action<int> ValueChanged; //Action mit einem Parameter

	public event Action ProcessCompleted;

	public void StartProcess()
	{
		for (int i = 0; i < 10; i++)
		{
			Thread.Sleep(200);
			ValueChanged.Invoke(i); //Benachrichtigen wenn Prozess voran geht
		}
		ProcessCompleted(); //Benachrichtigen wenn fertig
	}
}
