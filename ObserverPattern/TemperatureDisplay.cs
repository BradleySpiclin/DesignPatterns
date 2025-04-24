namespace DesignPatterns.ObserverPattern;

public sealed class TemperatureDisplay : IObserver, IDisplayElement
{
    private readonly WeatherData _weatherData;
    private float _temperature;

    public TemperatureDisplay(WeatherData weatherData)
    {
        _weatherData = weatherData;
        _weatherData.RegisterObserver(this);
    }

    public void Update()
    {
        _temperature = _weatherData.GetTemperature();
        Display();
    }

    public void Display()
    {
        Console.WriteLine($"** Temperature Display **");
        Console.WriteLine($"Current: {_temperature} C");
    }
}
