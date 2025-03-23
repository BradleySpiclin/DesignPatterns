# Strategy Pattern in C\#

## Overview

This repository demonstrates the **Strategy Pattern** in C#. The Strategy Pattern enables dynamic selection of an algorithm at runtime by defining a set of interchangeable behaviors. It promotes flexibility by separating algorithm implementation from the code that relies on it, allowing for independent modification and extension.

In this example, we model different bird behaviors using the Strategy Pattern. A `Bird` can have different **flying** and **swimming** behaviors, which can be modified at runtime.

## Project Structure

```
StrategyPattern/
│── Strategy.cs         # Entry point to demonstrate the pattern
│── IFlyBehaviour.cs    # Interface for flying behavior
│── ISwimBehaviour.cs   # Interface for swimming behavior
│── Bird.cs             # Abstract base class for birds
│── Eagle.cs            # A specific type of bird
│── Flying.cs           # A behavior representing flying
│── Walking.cs          # A behavior representing walking (for non-flying birds)
│── Swimming.cs         # A behavior representing swimming
│── Drowning.cs         # A behavior representing drowning (for non-swimming birds)
```

## Implementation Details

### Bird Class (Abstract Base)

Birds have dynamic flying and swimming behaviors that can be changed at runtime.

```csharp
public abstract class Bird(string name)
{
    private IFlyBehaviour _flyBehaviour = new Walking();
    private ISwimBehaviour _swimBehaviour = new Drowning();

    public string Name { get; private set; } = name;

    public void DisplayInfo()
    {
        Console.WriteLine($"\nName: {Name}, Type: {GetType().Name}");
        Console.WriteLine($"Fly Behaviour: {_flyBehaviour.GetType().Name}");
        Console.WriteLine($"Swim Behaviour: {_swimBehaviour.GetType().Name}\n");
    }

    public void SetFlyBehaviour(IFlyBehaviour flyBehaviour) => _flyBehaviour = flyBehaviour;

    public void SetSwimBehaviour(ISwimBehaviour swimBehaviour) => _swimBehaviour = swimBehaviour;

    public void Fly()
    {
        Console.Write("Fly: ");
        _flyBehaviour.Fly();
    }

    public void Swim()
    {
        Console.Write("Swim: ");
        _swimBehaviour.Swim();
    }
}
```

### Interfaces

Two interfaces define behaviors:

```csharp
public interface IFlyBehaviour
{
    void Fly();
}

public interface ISwimBehaviour
{
    void Swim();
}
```

### Concrete Behaviors

```csharp
public sealed class Flying : IFlyBehaviour
{
    public void Fly() => Console.WriteLine("Flapping my wings and taking off!");
}

public sealed class Walking : IFlyBehaviour
{
    public void Fly() => Console.WriteLine("Not a chance, I'm walking!");
}

public sealed class Swimming : ISwimBehaviour
{
    public void Swim() => Console.WriteLine("Majestic strokes on the water!");
}

public sealed class Drowning : ISwimBehaviour
{
    public void Swim() => Console.WriteLine("Only bubbles appear on the water's surface...");
}
```

### Example Usage (Strategy.cs)

```csharp
public sealed class Strategy
{
    public static void Run()
    {
        var bird = new Eagle("Garry");
        bird.DisplayInfo();
        bird.Fly();
        bird.Swim();
        
        bird.SetFlyBehaviour(new Flying());
        bird.SetSwimBehaviour(new Swimming());
        
        bird.DisplayInfo();
        bird.Fly();
        bird.Swim();
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
Name: Garry, Type: Eagle
Fly Behaviour: Walking
Swim Behaviour: Drowning

Fly: Not a chance, I'm walking!
Swim: Only bubbles appear on the waters surface...

Name: Garry, Type: Eagle
Fly Behaviour: Flying
Swim Behaviour: Swimming

Fly: Flapping my wings and taking off!
Swim: Majestic strokes on the water!
```

## Key Benefits of the Strategy Pattern

- **Encapsulation of behaviors**: Different behaviors are encapsulated in separate classes, making it easy to extend or modify them.
- **Dynamic behavior change**: Objects can change their behavior at runtime without modifying their code.
- **Follows the Open/Closed Principle**: New behaviors can be added without modifying existing code.

---
