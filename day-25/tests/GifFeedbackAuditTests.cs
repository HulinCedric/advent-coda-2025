using FluentAssertions;
using LanguageExt;
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

                France : 1 mécontents
                Japan : 1 mécontents
                Germany : 1 mécontents

                Total global : 3 enfants mécontents
                """);
    }

    private string BuildReport(string input)
    {
        var feedbacks = input.Split("|").Select(Feedback.Parse).Somes();

        var report = UnhappyChildrenReport.BuildFrom(feedbacks);

        return UnhappyChildrenReportPresenter.Present(report);
    }
}