namespace Day01;

public static class LetterExtensions
{
    extension(IEnumerable<char> letters)
    {
        public string Join() => letters.Aggregate(string.Empty, (accumulator, character) => accumulator + character);
    }
}