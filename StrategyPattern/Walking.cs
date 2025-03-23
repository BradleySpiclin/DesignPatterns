namespace StrategyPattern;

public sealed class Walking : IFlyBehaviour
{
    public void Fly() => Console.WriteLine($"Not a chance, I'm walking!");
}
