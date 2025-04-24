namespace DesignPatterns.ObserverPattern;

public sealed class WeatherData : ISubject
{
    private readonly List<IObserver> _observers = [];
    
    private float _temperature;
    private float _humidity;
    private float _pressure;

    public void RegisterObserver(IObserver observer) => _observers.Add(observer);

    public void RemoveObserver(IObserver observer) => _observers.Remove(observer);

    public void MeasurementsChanged() => NotifyObservers();

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update();
        }
    }

    public void SetMeasurements(float temperature, float humidity, float pressure)
    {
        _temperature = temperature;
        _humidity = humidity;
        _pressure = pressure;
        MeasurementsChanged();
    }

    public float GetTemperature() => _temperature;

    public float GetHumidity() => _humidity;
    
    public float GetPressure() => _pressure;
}