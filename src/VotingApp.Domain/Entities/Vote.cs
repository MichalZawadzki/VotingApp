namespace VotingApp.Domain.Entities;

public class Vote : BaseAuditableEntity
{
    public Guid CandidateId { get; private set; }
    public Candidate Candidate { get; private set; } = null!;

    public Guid VoterId { get; private set; }
    public Voter Voter { get; private set; } = null!;

    private Vote()
    {
        
    }

    private Vote(Guid id, Guid candidateId, Candidate candidate, Guid voterId, Voter voter)
    {
        Id = id;
        CandidateId = candidateId;
        Candidate = candidate;
        VoterId = voterId;
        Voter = voter;
    }

    public static Vote Create(Candidate candidate, Voter voter)
    {
        if (candidate is null)
        {
            throw new ArgumentNullException(nameof(candidate));
        }

        if (voter is null)
        {
            throw new ArgumentNullException(nameof(voter));
        }

        return new Vote(Guid.NewGuid(), candidate.Id, candidate, voter.Id, voter);
    }
}
