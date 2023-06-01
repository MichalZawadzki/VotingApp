using MediatR;
using VotingApp.Application.Common.Interfaces;
using VotingApp.Domain.Entities;
using VotingApp.Domain.Events;

namespace VotingApp.Application.Candidates.Commands.CreateCandidate;

public class CreateCandidateCommandHandler : IRequestHandler<CreateCandidateCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateCandidateCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(CreateCandidateCommand request, CancellationToken cancellationToken)
    {
        var entity = Candidate.Create(request.FirstName, request.LastName);

        _context.Candidates.Add(entity);

        entity.AddDomainEvent(new CandidateCreatedEvent(entity));

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
