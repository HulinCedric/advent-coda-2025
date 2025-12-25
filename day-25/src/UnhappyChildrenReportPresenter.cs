namespace GifFeedbackAudit;

public static class UnhappyChildrenReportPresenter
{
    public static string Present(UnhappyChildrenReport report)
        => $"""
            === Rapport des Enfants Mécontents ===

            {FormLines(report.Lines())}

            {FormatTotal(report.TotalNumberOfFeedbacks())}
            """;

    private static string FormLines(IEnumerable<UnhappyChildrenReport.ReportLine> lines)
        => string.Join(Environment.NewLine, lines
            .OrderByDescending(line => line.NumberOfFeedback)
            .ThenBy(line => line.Country.ToString())
            .Select(FormatLine));

    private static string FormatLine(UnhappyChildrenReport.ReportLine line)
        => $"{line.Country} : {line.NumberOfFeedback} mécontents";

    private static string FormatTotal(int total) => $"Total global : {total} enfants mécontents";
}