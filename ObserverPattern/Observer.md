# Observer Pattern in C#

## Overview

This repository demonstrates the **Observer Pattern** using a **pull-based approach** in C#. The Observer Pattern enables an object (subject) to maintain a list of dependents (observers) and notify them automatically of any state changes.

This pull-based design separates the responsibilities of the `Subject` and `Observer` by allowing observers to pull only the data they care about when notified of a change, offering flexibility and reducing coupling between components. You can implement this on a push based approach, however if we add new properties to the `WeatherStation` then all displays will also get those properties regardless if they use them or not. In this example we retrieve the data we care about.

In this example, we simulate a simple weather station. Different display classes subscribe to `WeatherData`, and when the weather data changes, only the relevant measurements are pulled by each observer.

## Project Structure

```
ObserverPattern/
│── WeatherStation.cs         # Entry point to run the simulation
│── WeatherData.cs            # Subject holding temperature, humidity, and pressure
│── ISubject.cs               # Interface for the subject
│── IObserver.cs              # Interface for observers
│── IDisplayElement.cs        # Interface for displays
│── TemperatureDisplay.cs     # Observer for temperature
│── HumidityDisplay.cs        # Observer for humidity
│── PressureDisplay.cs        # Observer for pressure
```

## Implementation Details

### Subject Interface

```csharp
public interface ISubject
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}
```

### Observer Interface

```csharp
public interface IObserver
{
    void Update();
}
```

### Display Interface

```csharp
public interface IDisplayElement
{
    void Display();
}
```

### WeatherData (Subject)

Holds the current temperature, humidity, and pressure, and notifies registered observers when measurements are updated.

```csharp
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
```

### Concrete Observers

Each observer pulls only the data it needs from the subject.

#### TemperatureDisplay

```csharp
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
        Console.WriteLine("** Temperature Display **");
        Console.WriteLine($"Current: {_temperature} C");
    }
}
```

#### HumidityDisplay

```csharp
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
        Console.WriteLine("** Humidity Display **");
        Console.WriteLine($"Current: {_humidity} %");
    }
}
```

#### PressureDisplay

```csharp
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
        Console.WriteLine("** Pressure Display **");
        Console.WriteLine($"Current: {_pressure} mb");
    }
}
```

### Example Usage (WeatherStation.cs)

```csharp
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
```

## Running the Program

1. Clone the repository.
2. Open the project in Visual Studio or run it using the .NET CLI:
   ```sh
   dotnet run
   ```

## Expected Output

```
** Temperature Display **
Current: 30 C
** Humidity Display **
Current: 65 %
** Pressure Display **
Current: 30.4 mb

** Temperature Display **
Current: 30.3 C
** Humidity Display **
Current: 66 %
** Pressure Display **
Current: 30.6 mb

** Temperature Display **
Current: 31.2 C
** Humidity Display **
Current: 66.3 %
** Pressure Display **
Current: 30.9 mb
```

## Key Benefits of the Observer Pattern (Pull-Based)

- **Decoupling**: Observers don't need to know internal details of the subject; they pull only what they care about.
- **Extensibility**: Easy to add new observers without modifying the subject.
- **Flexibility**: Each observer can behave differently and request only what it needs.

---