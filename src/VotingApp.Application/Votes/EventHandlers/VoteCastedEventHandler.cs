using MediatR;
using Microsoft.Extensions.Logging;
using VotingApp.Application.Candidates.Commands.AddVote;
using VotingApp.Application.Voters.Commands.MarkVoterAsAlreadyVoted;
using VotingApp.Domain.Events;

namespace VotingApp.Application.Votes.EventHandlers;

public class VoteCastedEventHandler : INotificationHandler<VoteCastedEvent>
{
    private readonly ILogger<VoteCastedEventHandler> _logger;
    private readonly ISender _mediator;

    public VoteCastedEventHandler(ILogger<VoteCastedEventHandler> logger, ISender mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    public async Task Handle(VoteCastedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("VoteApp Domain Event: {DomainEvent}", notification.GetType().Name);

        if (notification?.Vote is null)
        {
            throw new ArgumentException(nameof(VoteCastedEvent));
        }

        // When vote is casted mark voter as already voteted
        await _mediator.Send(new MarkVoterAsAlreadyVotedCommand(notification.Vote.VoterId), cancellationToken);

        // When vote is casted increase number of votes for the candidate
        await _mediator.Send(new AddVoteCommand(notification.Vote.CandidateId), cancellationToken);

        return;
    }
}
