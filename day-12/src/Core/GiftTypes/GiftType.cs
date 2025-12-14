namespace GiftMachine.Core.GiftTypes;

public abstract record GiftType(string Code)
{
    public static readonly GiftType Teddy = new TeddyType();
    public static readonly GiftType Car = new CarType();
    public static readonly GiftType Doll = new DollType();
    public static readonly GiftType Book = new BookType();
    public static readonly GiftType Robot = new RobotType();

    public abstract string BuildFor(string recipient);

    public sealed override string ToString() => Code;
}