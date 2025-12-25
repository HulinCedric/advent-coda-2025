using LanguageExt;
using static LanguageExt.Prelude;

namespace GifFeedbackAudit;

public record Country(string Value)
{
    public static Option<Country> Parse(string input)
        => Optional(input)
            .Map(s => s.Trim())
            .Filter(s => s.Length > 0)
            .Filter(ContainOnlyLetter)
            .Map(s => new Country(s));

    private static bool ContainOnlyLetter(string input) => input.All(char.IsLetter);
}