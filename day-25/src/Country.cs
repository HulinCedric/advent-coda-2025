using LanguageExt;
using static LanguageExt.Prelude;

namespace GifFeedbackAudit;

public record Country(string Value)
{
    public static Option<Country> Parse(string input)
        => Optional(input)
            .Map(s => s.Trim())
            .Filter(s => s.Length > 0)
            .Filter(s => s.All(char.IsLetter))
            .Map(s => new Country(s));
}