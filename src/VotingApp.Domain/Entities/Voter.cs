namespace VotingApp.Domain.Entities;

public class Voter : BaseAuditableEntity
{
    public string FirstName { get; private set; }

    public string LastName { get; private set; }

    public bool HasAlreadyVoted { get; private set; }

    public IList<Vote> CastVotes { get; private set; } = new List<Vote>();

    private Voter()
    {

    }

    private Voter(Guid id, string firstName, string lastName, IList<Vote> castVotes, bool hasAlreadyVoted = false)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        CastVotes = castVotes;
        HasAlreadyVoted = hasAlreadyVoted;
    }

    public static Voter Create(string firstName, string lastName)
    {
        if (string.IsNullOrEmpty(firstName))
        {
            throw new ArgumentNullException(nameof(firstName));
        }

        if (string.IsNullOrEmpty(lastName))
        {
            throw new ArgumentNullException(nameof(firstName));
        }

        return new Voter(Guid.NewGuid(), firstName, lastName, new List<Vote>(), false);
    }

    public void MarkAsAlreadyVoted()
    {
        HasAlreadyVoted = true;
    }
}
