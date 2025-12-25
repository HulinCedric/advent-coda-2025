using LanguageExt;

namespace GifFeedbackAudit;

public record Age(int Value)
{
    public static Option<Age> Parse(string input)
        => Prelude.parseInt(input)
            .Filter(age => age > 0)
            .Map(age => new Age(age));
}