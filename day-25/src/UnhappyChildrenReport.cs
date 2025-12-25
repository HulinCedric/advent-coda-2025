namespace GifFeedbackAudit;

public class UnhappyChildrenReport
{
    private readonly IReadOnlyList<ReportLine> _lines;

    private UnhappyChildrenReport(IEnumerable<ReportLine> lines) => _lines = lines.ToList().AsReadOnly();

    public IReadOnlyList<ReportLine> Lines() => _lines;

    public int TotalNumberOfFeedbacks() => _lines.Sum(line => line.NumberOfFeedback);

    public static UnhappyChildrenReport BuildFrom(IEnumerable<Feedback> feedbacks)
        => new(
            from feedback in feedbacks
            where feedback.IsUnhappy()
            group feedback by feedback.Country
            into countryGroup
            select new ReportLine(
                Country: countryGroup.Key,
                NumberOfFeedback: countryGroup.Count()));

    public static UnhappyChildrenReport Parse(string input)
    {
        var feedbacks = input.Split("|").Select(Feedback.Parse).Somes();

        return BuildFrom(feedbacks);
    }

    public record ReportLine(Country Country, int NumberOfFeedback);
}