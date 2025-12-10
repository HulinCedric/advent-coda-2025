namespace Day09.Tests;

public static class FunctionalExtensions
{
    public static TResult Do<TSource, TResult>(
        this TSource source,
        Func<TSource, TResult> func)
        => func(source);
}