using LanguageExt;

namespace GifFeedbackAudit;

public record Country(string Value)
{
    public static Option<Country> Parse(string input)
    {
        var trimmedInput = input?.Trim();
        return string.IsNullOrWhiteSpace(trimmedInput) || !trimmedInput.All(char.IsLetter)
            ? Option<Country>.None
            : new Country(trimmedInput);
    }
}