namespace M013;

internal class Program
{
	static void Main(string[] args)
	{
		AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException; //Exceptions die nicht gefangen wurden loggen
		//throw new Exception();

		try //Codeblock markieren -> Rechtsklick -> Surround With -> try(f)
		{
			string eingabe = Console.ReadLine(); //Maus über Methode -> Exceptions sind die Fehler die auftreten können
			int x = int.Parse(eingabe); //3 mögliche Exceptions: ArgumentNullException, FormatException, OverflowException

			if (x == 0)
				throw new TestException("Die angegebene Zahl ist 0.", "Fehler"); //Eine Exception werfen mit throw
		}
		catch (FormatException e) //Keine Zahl eingegeben (Buchstaben)
		{
			Console.WriteLine("Keine Zahl eingegeben");
			Console.WriteLine(e.Message); //Die Nachricht der Exception (hier Input string was not in a correct Format)
			Console.WriteLine(e.StackTrace); //Wo ist meine Exception im Code aufgetreten?
		}
		catch (OverflowException e) //Zahl zu klein/groß
		{
			Console.WriteLine($"Zahl ist außerhalb des gültigen Bereichs. Gültiger Bereich: {int.MinValue} bis {int.MaxValue}");
			Console.WriteLine(e.Message);
		}
		catch (TestException e)
		{
			Console.WriteLine(e.Status);
			e.Test(); //Methode in meiner TestException Klasse aufrufen
			throw; //Fataler Fehler
		}
		catch (ArithmeticException e) //Fängt alle Exceptions die von ArithmeticException erben (z.B.: OverflowException, DivideByZeroException, ...)
		{
			Console.WriteLine($"Ein Fehler bei einer Rechenoperation ist aufgetreten: {e.Message}");
		}
		catch (Exception e) //Alle anderen Fehler abhandeln
		{
			Console.WriteLine($"Anderer Fehler: {e.Message}");
		}
		finally //Wird immer ausgeführt, auch wenn keine Exception
		{
			Console.WriteLine("Parsen abgeschlossen");
		}
	}

	private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
	{
		Exception ex = e.ExceptionObject as Exception;
		File.WriteAllText("Exception.txt", ex.Message + "\n" + ex.StackTrace);
	}
}

public class TestException : Exception //Eigene Exception muss von einer Exception Klasse erben
{
	public string Status { get; set; }

	public TestException(string? message, string status) : base(message) => Status = status;

	public void Test() => Console.WriteLine($"TestException ist aufgetreten: {Message}");
}