using DesignPatterns.ObserverPattern;
using StrategyPattern;

namespace DesignPatterns;

public sealed class Program
{
    public static void Main()
    {
        Console.WriteLine("** Strategy Pattern **");
        Strategy.Run();

        Console.WriteLine("\n** Observer Pattern **");
        WeatherStation.Run();
    }
}
