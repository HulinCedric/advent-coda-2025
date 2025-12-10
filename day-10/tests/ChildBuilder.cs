namespace GiftSelection.Tests;

public class ChildBuilder
{
    private static int _age = 9;
    private Behavior _behavior = Behavior.Nice;
    private readonly List<GiftRequest> _giftRequests = [];

    public static ChildBuilder AChild() => new();

    public static ChildBuilder AYoungChild() => AChild().Young();
    public static ChildBuilder AnOldChild() => AChild().Old();

    public ChildBuilder Nice()
    {
        _behavior = Behavior.Nice;
        return this;
    }

    public ChildBuilder Normal()
    {
        _behavior = Behavior.Normal;
        return this;
    }

    public ChildBuilder Naughty()
    {
        _behavior = Behavior.Naughty;
        return this;
    }
    
    public ChildBuilder Young() => Aged(9);
    public ChildBuilder Old() => Aged(14);

    public ChildBuilder Aged(int age)
    {
        _age = age;
        return this;
    }

    public ChildBuilder RequestingFeasibleGift(string? giftName = null)
    {
        _giftRequests.Add(new GiftRequest(giftName ?? "A feasible gift", true));
        return this;
    }

    public ChildBuilder RequestingInfeasibleGift(string? giftName = null)
    {
        _giftRequests.Add(new GiftRequest(giftName ?? "An infeasible gift", false));
        return this;
    }

    public Child Build() => new("Jane", "Doe", _age, _behavior, _giftRequests);
}