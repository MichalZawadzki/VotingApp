namespace VotingApp.Domain.Exceptions;

public class VoteAlreadyCastException : Exception
{
    public VoteAlreadyCastException(string code)
        : base($"Colour \"{code}\" is unsupported.")
    {
    }
}
