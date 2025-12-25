using LanguageExt;
using static LanguageExt.Prelude;

namespace GifFeedbackAudit;

public record FirstName(string Value)
{
    public static Option<FirstName> Parse(string input)
        => Optional(input)
            .Map(s => s.Trim())
            .Filter(s => s.Length > 0)
            .Filter(ContainOnlyLetter)
            .Map(s => new FirstName(s));

    private static bool ContainOnlyLetter(string input) => input.All(char.IsLetter);
}