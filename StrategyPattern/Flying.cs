namespace StrategyPattern;

public sealed class Flying : IFlyBehaviour
{
    public void Fly() => Console.WriteLine($"Flapping my wings and taking off!");
}
