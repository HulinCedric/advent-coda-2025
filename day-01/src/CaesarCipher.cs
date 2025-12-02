namespace Day01;

public static class CaesarCipher
{
    private const string Alphabet = "abcdefghijklmnopqrstuvwxyz";
    private static readonly int AlphabetLength = Alphabet.Length;

    public static string Decipher(string message, string key)
    {
        var shift = key.Length;

        return Decipher(message, shift);
    }

    private static string Decipher(string message, int shift)
        => message
            .Select(character => Decipher(character, shift))
            .Join();

    private static char Decipher(char character, int shift)
        => char.IsLetter(character)
            ? DecipherLetter(character, shift)
            : character;

    private static char DecipherLetter(char letter, int shift)
    {
        var cipherLetterIndex = Alphabet.IndexOf(letter);

        var decipherLetterIndex = (cipherLetterIndex - shift + AlphabetLength) % AlphabetLength;

        return Alphabet[decipherLetterIndex];
    }
}