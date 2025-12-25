using System.Reflection;
using FluentAssertions;
using LanguageExt;
using Xunit;
using static System.IO.Path;

namespace GifFeedbackAudit.Tests;

public class GifFeedbackAuditTests
{
    [Fact]
    public void Sample()
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

    [Fact]
    public void Solution()
    {
        var input = ReadReportContent("input");

        var report = BuildReport(input);

        report.Should()
            .BeEquivalentTo(
                """
                === Rapport des Enfants Mécontents ===
                
                Netherlands : 238 mécontents
                Norway : 208 mécontents
                Turkey : 216 mécontents
                Ireland : 234 mécontents
                Italy : 194 mécontents
                Belgium : 229 mécontents
                Switzerland : 232 mécontents
                Germany : 232 mécontents
                Chile : 232 mécontents
                Czechia : 225 mécontents
                Poland : 268 mécontents
                Portugal : 238 mécontents
                Hungary : 226 mécontents
                France : 249 mécontents
                USA : 227 mécontents
                Canada : 238 mécontents
                Brazil : 264 mécontents
                China : 241 mécontents
                Argentina : 237 mécontents
                UK : 241 mécontents
                Sweden : 213 mécontents
                India : 206 mécontents
                Japan : 243 mécontents
                Mexico : 251 mécontents
                Finland : 236 mécontents
                Greece : 227 mécontents
                Denmark : 236 mécontents
                Austria : 243 mécontents
                Australia : 190 mécontents
                Spain : 238 mécontents
                
                Total global : 6952 enfants mécontents
                """);
    }

    private static string BuildReport(string input)
    {
        var feedbacks = input.Split("|").Select(Feedback.Parse).Somes();

        var report = UnhappyChildrenReport.BuildFrom(feedbacks);

        return UnhappyChildrenReportPresenter.Present(report);
    }

    private static string ReadReportContent(string fileName)
        => File.ReadAllText(
            Combine(
                GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,
                fileName));
}