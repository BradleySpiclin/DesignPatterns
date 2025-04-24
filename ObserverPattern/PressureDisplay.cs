namespace DesignPatterns.ObserverPattern;

public sealed class PressureDisplay : IObserver, IDisplayElement
{
    private readonly WeatherData _weatherData;
    private float _pressure;

    public PressureDisplay(WeatherData weatherData)
    {
        _weatherData = weatherData;
        _weatherData.RegisterObserver(this);
    }

    public void Update()
    {
        _pressure = _weatherData.GetPressure();
        Display();
    }

    public void Display()
    {
        Console.WriteLine($"** Pressure Display **");
        Console.WriteLine($"Current: {_pressure} mb");
    }
}
