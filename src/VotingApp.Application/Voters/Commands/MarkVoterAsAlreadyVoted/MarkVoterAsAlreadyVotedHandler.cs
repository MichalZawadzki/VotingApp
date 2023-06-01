using MediatR;
using Microsoft.EntityFrameworkCore;
using VotingApp.Application.Common.Exceptions;
using VotingApp.Application.Common.Interfaces;
using VotingApp.Application.Votes.Commands.CreateVote;

namespace VotingApp.Application.Voters.Commands.MarkVoterAsAlreadyVoted;

public class AddVoteHandler : IRequestHandler<MarkVoterAsAlreadyVotedCommand>
{
    private readonly IApplicationDbContext _context;

    public AddVoteHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(MarkVoterAsAlreadyVotedCommand request, CancellationToken cancellationToken)
    {
        var voter = await _context.Voters.FirstOrDefaultAsync(x => x.Id == request.VoterId, cancellationToken);
        if (voter is null)
        {
            throw new NotFoundException(nameof(MarkVoterAsAlreadyVotedCommand), request.VoterId);
        }

        voter.MarkAsAlreadyVoted();

        await _context.SaveChangesAsync(cancellationToken);
    }
}
