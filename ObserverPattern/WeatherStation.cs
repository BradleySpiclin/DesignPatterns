namespace DesignPatterns.ObserverPattern;

public sealed class WeatherStation
{
    public static void Run()
    {
        var weatherData = new WeatherData();
        var temperatureDisplay = new TemperatureDisplay(weatherData);
        var humidityDisplay = new HumidityDisplay(weatherData);
        var pressureDisplay = new PressureDisplay(weatherData);

        weatherData.SetMeasurements(30, 65, 30.4f);
        weatherData.SetMeasurements(30.3f, 66, 30.6f);
        weatherData.SetMeasurements(31.2f, 66.3f, 30.9f);
    }
}