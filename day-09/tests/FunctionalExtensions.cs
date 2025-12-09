namespace Day09.Tests;

public static class FunctionalExtensions
{
    public static TResult Pipe<TSource, TResult>(
        this TSource source,
        Func<TSource, TResult> func)
        => func(source);
}