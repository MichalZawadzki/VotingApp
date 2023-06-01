using VotingApp.Domain.Common;

namespace VotingApp.Domain.Events;

public class CandidateCreatedEvent : BaseEvent
{
    public CandidateCreatedEvent(Candidate candidate)
    {
        Candidate = candidate;
    }

    public Candidate Candidate { get; }
}
