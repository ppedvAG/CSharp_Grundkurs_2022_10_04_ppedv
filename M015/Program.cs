using Microsoft.VisualBasic.FileIO;
using System.Text.Json;
using System.Xml.Serialization;

namespace M015;

internal class Program
{
	static void Main(string[] args)
	{
		//StreamWriterReader()

		//Json();

		//Xml();

		//CSV();
	}

	public static void StreamWriterReader()
	{
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfad zum Desktop

		string folderPath = Path.Combine(desktop, "Test"); //Test Ordner Pfad

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		string filePath = Path.Combine(folderPath, "Test.txt"); //Dateipfad

		StreamWriter sw = new StreamWriter(filePath);
		sw.WriteLine("Test1"); //Stream füllen
		sw.WriteLine("Test2");
		sw.WriteLine("Test3");
		//sw.Flush(); //Streaminhalt in das File schreiben
		sw.Close(); //Am Ende schließen + Flush

		using (StreamWriter sw2 = new(filePath)) { } //schließt sich automatisch am Ende des Blocks

		using StreamWriter sw3 = new(filePath); //schließt sich automatisch am Ende der Methode

		using StreamReader sr = new StreamReader(filePath);
		string fullFile = sr.ReadToEnd(); //Ganzes File in einen String einlesen
		List<string> lines = fullFile.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList(); //Eingelesenen string in ein Array konvertieren
	}

	public static void Json()
	{
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfad zum Desktop

		string folderPath = Path.Combine(desktop, "Test"); //Test Ordner Pfad

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		string filePath = Path.Combine(folderPath, "Test.txt"); //Dateipfad

		List<Fahrzeug> fahrzeuge = new()
		{
			new Fahrzeug(0, 251, FahrzeugMarke.BMW),
			new Fahrzeug(1, 274, FahrzeugMarke.BMW),
			new Fahrzeug(2, 146, FahrzeugMarke.BMW),
			new Fahrzeug(3, 208, FahrzeugMarke.Audi),
			new Fahrzeug(4, 189, FahrzeugMarke.Audi),
			new Fahrzeug(5, 133, FahrzeugMarke.VW),
			new Fahrzeug(6, 253, FahrzeugMarke.VW),
			new Fahrzeug(7, 304, FahrzeugMarke.BMW),
			new Fahrzeug(8, 151, FahrzeugMarke.VW),
			new Fahrzeug(9, 250, FahrzeugMarke.VW),
			new Fahrzeug(10, 217, FahrzeugMarke.Audi),
			new Fahrzeug(11, 125, FahrzeugMarke.Audi)
		};

		string json = JsonSerializer.Serialize(fahrzeuge);
		File.WriteAllText(filePath, json);

		string readJson = File.ReadAllText(filePath);
		List<Fahrzeug> readFzg = JsonSerializer.Deserialize<List<Fahrzeug>>(readJson);
	}

	public static void Xml()
	{
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfad zum Desktop

		string folderPath = Path.Combine(desktop, "Test"); //Test Ordner Pfad

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		string filePath = Path.Combine(folderPath, "Test.txt"); //Dateipfad

		List<Fahrzeug> fahrzeuge = new()
		{
			new Fahrzeug(0, 251, FahrzeugMarke.BMW),
			new Fahrzeug(1, 274, FahrzeugMarke.BMW),
			new Fahrzeug(2, 146, FahrzeugMarke.BMW),
			new Fahrzeug(3, 208, FahrzeugMarke.Audi),
			new Fahrzeug(4, 189, FahrzeugMarke.Audi),
			new Fahrzeug(5, 133, FahrzeugMarke.VW),
			new Fahrzeug(6, 253, FahrzeugMarke.VW),
			new Fahrzeug(7, 304, FahrzeugMarke.BMW),
			new Fahrzeug(8, 151, FahrzeugMarke.VW),
			new Fahrzeug(9, 250, FahrzeugMarke.VW),
			new Fahrzeug(10, 217, FahrzeugMarke.Audi),
			new Fahrzeug(11, 125, FahrzeugMarke.Audi)
		};

		XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Fahrzeug>));
		using (FileStream fs = new FileStream(filePath, FileMode.Create))
		{
			xmlSerializer.Serialize(fs, fahrzeuge);
		}

		using (FileStream readStream = new FileStream(filePath, FileMode.Open))
		{
			List<Fahrzeug> readFzg = xmlSerializer.Deserialize(readStream) as List<Fahrzeug>;
		}
	}

	public static void CSV()
	{
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfad zum Desktop

		string folderPath = Path.Combine(desktop, "Test"); //Test Ordner Pfad

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		string filePath = Path.Combine(folderPath, "Test.txt"); //Dateipfad

		List<Fahrzeug> fahrzeuge = new()
		{
			new Fahrzeug(0, 251, FahrzeugMarke.BMW),
			new Fahrzeug(1, 274, FahrzeugMarke.BMW),
			new Fahrzeug(2, 146, FahrzeugMarke.BMW),
			new Fahrzeug(3, 208, FahrzeugMarke.Audi),
			new Fahrzeug(4, 189, FahrzeugMarke.Audi),
			new Fahrzeug(5, 133, FahrzeugMarke.VW),
			new Fahrzeug(6, 253, FahrzeugMarke.VW),
			new Fahrzeug(7, 304, FahrzeugMarke.BMW),
			new Fahrzeug(8, 151, FahrzeugMarke.VW),
			new Fahrzeug(9, 250, FahrzeugMarke.VW),
			new Fahrzeug(10, 217, FahrzeugMarke.Audi),
			new Fahrzeug(11, 125, FahrzeugMarke.Audi)
		};

		string str = fahrzeuge.Aggregate("", (agg, fzg) => agg + $"{string.Join(';', fzg.GetType().GetProperties().Select(e => e.GetValue(fzg)))}{Environment.NewLine}");
		File.WriteAllText(filePath, str);

		TextFieldParser tfp = new(filePath);
		tfp.SetDelimiters(";");
		string read = tfp.ReadToEnd();
		List<string> lines = read.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList();
		List<string[]> splitLines = lines.Select(l => l.Split(";")).ToList();
	}
}

public class Fahrzeug
{
	public int ID { get; set; }

	public int MaxGeschwindigkeit { get; set; }

	public FahrzeugMarke Marke { get; set; }

	public Fahrzeug(int id, int v, FahrzeugMarke fm)
	{
		ID = id;
		MaxGeschwindigkeit = v;
		Marke = fm;
	}

	public Fahrzeug()
	{

	}
}

public enum FahrzeugMarke { Audi, BMW, VW }