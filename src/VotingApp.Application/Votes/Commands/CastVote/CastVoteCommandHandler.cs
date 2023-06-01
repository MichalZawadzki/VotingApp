using MediatR;
using Microsoft.EntityFrameworkCore;
using VotingApp.Application.Common.Exceptions;
using VotingApp.Application.Common.Interfaces;
using VotingApp.Domain.Entities;
using VotingApp.Domain.Events;

namespace VotingApp.Application.Votes.Commands.CreateVote;

public class CastVoteCommandHandler : IRequestHandler<CastVoteCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CastVoteCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CastVoteCommand request, CancellationToken cancellationToken)
    {
        var candidate = await _context.Candidates.FirstOrDefaultAsync(x => x.Id == request.CandidateId, cancellationToken);
        if (candidate is null)
        {
            throw new NotFoundException(nameof(Candidate), request.CandidateId);
        }

        var voter = await _context.Voters.FirstOrDefaultAsync(x => x.Id == request.VoterId, cancellationToken);
        if (voter is null)
        {
            throw new NotFoundException(nameof(Voter), request.VoterId);
        }

        var entity = Vote.Create(candidate, voter);

        entity.AddDomainEvent(new VoteCastedEvent(entity));

        _context.Votes.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
