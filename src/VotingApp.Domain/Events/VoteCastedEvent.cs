using VotingApp.Domain.Common;

namespace VotingApp.Domain.Events;

public class VoteCastedEvent : BaseEvent
{
    public VoteCastedEvent(Vote vote)
    {
        Vote = vote;
    }

    public Vote Vote { get; }
}
