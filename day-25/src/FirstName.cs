using LanguageExt;

namespace GifFeedbackAudit;

public record FirstName(string Value)
{
    public static Option<FirstName> Parse(string input)
    {
        var trimmedInput = input?.Trim();
        return string.IsNullOrWhiteSpace(trimmedInput) || !trimmedInput.All(char.IsLetter)
            ? Option<FirstName>.None
            : new FirstName(trimmedInput);
    }
}