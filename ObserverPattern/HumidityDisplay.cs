namespace DesignPatterns.ObserverPattern;

public sealed class HumidityDisplay : IObserver, IDisplayElement
{
    private readonly WeatherData _weatherData;
    private float _humidity;

    public HumidityDisplay(WeatherData weatherData)
    {
        _weatherData = weatherData;
        _weatherData.RegisterObserver(this);
    }

    public void Update()
    {
        _humidity = _weatherData.GetHumidity();
        Display();
    }

    public void Display()
    {
        Console.WriteLine($"** Humidity Display **");
        Console.WriteLine($"Current: {_humidity} mb");
    }
}