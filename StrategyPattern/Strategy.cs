namespace StrategyPattern;

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
