namespace StrategyPattern;

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
