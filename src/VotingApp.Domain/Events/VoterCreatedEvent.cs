using VotingApp.Domain.Common;

namespace VotingApp.Domain.Events;

public class VoterCreatedEvent : BaseEvent
{
    public VoterCreatedEvent(Voter voter)
    {
        Voter = voter;
    }

    public Voter Voter { get; }
}
