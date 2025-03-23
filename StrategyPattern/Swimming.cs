namespace StrategyPattern;

public sealed class Swimming : ISwimBehaviour
{
    public void Swim() => Console.WriteLine($"Majestic strokes on the water!");
}
