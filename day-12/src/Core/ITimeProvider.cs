namespace GiftMachine.Core;

public interface ITimeProvider
{
    DateTime GetCurrentDateTime();
}