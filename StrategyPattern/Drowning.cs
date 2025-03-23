namespace StrategyPattern;

public sealed class Drowning : ISwimBehaviour
{
    public void Swim() => Console.WriteLine($"Only bubbles appear on the waters surface...");
}
