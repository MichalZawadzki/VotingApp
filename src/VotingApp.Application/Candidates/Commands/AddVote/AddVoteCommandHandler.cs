using MediatR;
using Microsoft.EntityFrameworkCore;
using VotingApp.Application.Common.Exceptions;
using VotingApp.Application.Common.Interfaces;
using VotingApp.Application.Votes.Commands.CreateVote;

namespace VotingApp.Application.Candidates.Commands.AddVote;

public class AddVoteHandler : IRequestHandler<AddVoteCommand>
{
    private readonly IApplicationDbContext _context;

    public AddVoteHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(AddVoteCommand request, CancellationToken cancellationToken)
    {
        var candidate = await _context.Candidates.FirstOrDefaultAsync(x => x.Id == request.CandidateId, cancellationToken);
        if (candidate is null)
        {
            throw new NotFoundException(nameof(AddVoteCommand), request.CandidateId);
        }

        candidate.AddVote();

        await _context.SaveChangesAsync(cancellationToken);
    }
}
