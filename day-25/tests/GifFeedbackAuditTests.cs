using FluentAssertions;
using Xunit;

namespace GifFeedbackAudit.Tests;

public class GifFeedbackAuditTests
{
    [Fact]
    public void Todo()
    {
        const string input =
            "France-Lucie-unhappy-7|Brazil-Antonio-happy-10|Japan-Hiro-unhappy-11|??-??-happy-?|Germany-Lena-unhappy-9|Spain--neutral-8|USA-Mike-happiness-12";

        var report = BuildReport(input);

        report.Should()
            .BeEquivalentTo(
                """
                === Rapport des Enfants Mécontents ===

                France : 12 mécontents
                Brazil : 8 mécontents
                Japan : 3 mécontents
                Germany : 4 mécontents
                Poland : 5 mécontents

                Total global : 32 enfants mécontents
                """);
    }

    private string BuildReport(string input)
        => """
           === Rapport des Enfants Mécontents ===

           France : 12 mécontents
           Brazil : 8 mécontents
           Japan : 3 mécontents
           Germany : 4 mécontents
           Poland : 5 mécontents

           Total global : 32 enfants mécontents
           """;
}