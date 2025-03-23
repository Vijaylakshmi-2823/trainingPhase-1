using System;
using System.Collections.Generic;

// Singleton Pattern - Logger Class
public sealed class Logger
{
    private static Logger? _instance;
    private static readonly object _lock = new object();

    private Logger() { }

    public static Logger Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Logger();
                }
                return _instance;
            }
        }
    }

    public void Log(string message)
    {
        Console.WriteLine($"Log: {message}");
    }
}

// Factory Pattern - Document Factory
public interface IDocument
{
    void Print();
}

public class PDFDocument : IDocument
{
    public void Print()
    {
        Console.WriteLine("Printing PDF Document");
    }
}

public class WordDocument : IDocument
{
    public void Print()
    {
        Console.WriteLine("Printing Word Document");
    }
}

public class DocumentFactory
{
    public static IDocument CreateDocument(string type)
    {
        return type.ToLower() switch
        {
            "pdf" => new PDFDocument(),
            "word" => new WordDocument(),
            _ => throw new ArgumentException("Invalid document type")
        };
    }
}

// Observer Pattern - Weather Station
public interface IObserver
{
    void Update(float temperature);
}

public class WeatherStation
{
    private List<IObserver> observers = new List<IObserver>();
    private float temperature;

    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void SetTemperature(float temp)
    {
        temperature = temp;
        NotifyObservers();
    }

    private void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(temperature);
        }
    }
}

public class WeatherDisplay : IObserver
{
    private string name;

    public WeatherDisplay(string name)
    {
        this.name = name;
    }

    public void Update(float temperature)
    {
        Console.WriteLine($"{name} received temperature update: {temperature}°C");
    }
}

// Demonstration
class Program
{
    static void Main()
    {
        // Singleton 
        Logger.Instance.Log("Application Started");

        // Factory 
        IDocument doc = DocumentFactory.CreateDocument("pdf");
        doc.Print();

        // Observer 
        WeatherStation weatherStation = new WeatherStation();
        WeatherDisplay display1 = new WeatherDisplay("Display 1");
        WeatherDisplay display2 = new WeatherDisplay("Display 2");

        weatherStation.RegisterObserver(display1);
        weatherStation.RegisterObserver(display2);

        weatherStation.SetTemperature(25.5f);
    }
}
