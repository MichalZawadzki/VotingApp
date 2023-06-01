namespace VotingApp.Domain.Entities;

public class Candidate : BaseAuditableEntity
{
    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public int VotesNumber { get; private set; }

    public IList<Vote> ObtainedVotes { get; private set; } = new List<Vote>();

    private Candidate()
    {
    }

    private Candidate(Guid id, string firstName, string lastName, int votesNumber, IList<Vote> obtainedVotes)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        VotesNumber = votesNumber;
        ObtainedVotes = obtainedVotes;
    }

    public static Candidate Create(string firstName, string lastName)
    {
        if (string.IsNullOrEmpty(firstName))
        {
            throw new ArgumentNullException(nameof(firstName));
        }

        if (string.IsNullOrEmpty(lastName))
        {
            throw new ArgumentNullException(nameof(firstName));
        }

        return new Candidate(Guid.NewGuid(), firstName, lastName, 0, new List<Vote>());
    }

    public void AddVote()
    {
        VotesNumber++;
    }
}
