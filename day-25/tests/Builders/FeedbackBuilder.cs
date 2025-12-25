namespace GifFeedbackAudit.Tests.Builders;

public class FeedbackBuilder
{
    private int _age = 7;
    private string _country = "France";
    private string _firstName = "Lucie";
    private string _satisfaction = "unhappy";

    public static FeedbackBuilder AFeedback() => new();

    public FeedbackBuilder From(string country)
    {
        _country = country;
        return this;
    }

    public FeedbackBuilder IssuedBy(string firstName)
    {
        _firstName = firstName;
        return this;
    }

    public FeedbackBuilder Satisfied(string satisfaction)
    {
        _satisfaction = satisfaction;
        return this;
    }

    public FeedbackBuilder Aged(int age)
    {
        _age = age;
        return this;
    }

    public Feedback Build() => new(_country, _firstName, _satisfaction, _age);
}